using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Cms.Model.Exchanges;
using Cms.Service.Interface;
using Cms.WebApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cms.WebApi.Models;
using Cms.Model.ViewModels;

namespace Cms.WebApi.Controllers
{
  [Route("api/[controller]/[action]")]
  [ApiController]
  public class AccountController : MasterController
  {
    private IUserService _userService;

    public AccountController(IUserService userService)
    {
      _userService = userService;
    }

    /// <summary>
    /// Login and generate token
    /// </summary>
    /// <remarks>
    /// request.Username => username or email
    /// </remarks>
    /// <param name="Request"></param>
    /// <returns></returns>
    [HttpPost]
    [AllowAnonymous]
    public ServiceResponse<string> Login([FromBody] LoginUserRequest Request)
    {
      ServiceResponse<string> response = new ServiceResponse<string>();
      GetUserResponse userResponse = _userService.LoginUserControl(Request);

      if (userResponse.ResultCode == (int)HttpStatusCode.OK)
      {
        TokenModel model = new TokenModel
        {
          TenantId = userResponse.User.Company.Tenant.TenantId,
          CompanyId = userResponse.User.CompanyId,
          UserId = userResponse.User.Id,
          UserTypeId = userResponse.User.UserTypeId,
          Username = userResponse.User.Username,
          FullName = userResponse.User.FullName,
          Email = userResponse.User.Email
        };
        Tuple<string, string> token = JwtManager.CreateToken(model, JWTModel._jwtTimeMinute);
        if (string.IsNullOrEmpty(token.Item1))
        {
          response.IsSuccessful = false;
          response.Message = "Token oluşturulamadı!";
          response.ResultCode = (int)HttpStatusCode.Unauthorized;

          return response;
        }

        response.Data = token.Item1;
        string refreshToken = token.Item2;
        if (!string.IsNullOrEmpty(refreshToken))
        {
          // verilen refresh token db e yazilir
          BaseResponse resultInsert = InsertTokenRefresh(refreshToken, userResponse.User.Id);
          if (resultInsert == null || !resultInsert.IsSucceed)
          {
            response.IsSuccessful = false;
            response.Message = "Refresh Token eklenemedi!";
            response.ResultCode = (int)HttpStatusCode.NotFound;

            return response;
          }
        }
      }

      return response;
    }

    /// <summary>
    /// Reset Password
    /// </summary>
    /// <param name="Request"></param>
    /// <returns></returns>
    [HttpPost]
    [AllowAnonymous]
    public BaseResponse ResetPassword([FromBody] ResetPasswordRequest Request)
    {
      BaseResponse response = _userService.ResetPassword(Request);

      return response;
    }

    /// <summary>
    /// Change password and login again
    /// </summary>
    /// <param name="Request"></param>
    /// <returns></returns>
    [Authorize]
    [HttpPost]
    public ServiceResponse<bool> ChangePassword([FromBody] ChangePasswordRequest Request)
    {
      Request.ClientUserId = CurrentUser.Id;
      ServiceResponse<bool> response = new ServiceResponse<bool>();
      GetUserResponse userResponse = _userService.ChangePassword(Request);
      if (userResponse == null || !userResponse.IsSucceed)
      {
        response.IsSuccessful = userResponse.IsSucceed;
        response.Message = userResponse.Message;
        response.ResultCode = userResponse.ResultCode;

        return response;
      }

      LoginUserRequest login = new LoginUserRequest
      {
        Username = userResponse.User.Username,
        Password = Request.NewPassword
      };

      Login(login);

      return response;
    }

    /// <summary>
    /// Refresh token when access token expiry
    /// </summary>
    /// <param name="Request"></param>
    /// <returns></returns>
    [HttpPost]
    [AllowAnonymous]
    public RefreshTokenResponse RefreshToken([FromBody] RefreshTokenRequest Request)
    {
      RefreshTokenResponse response = new RefreshTokenResponse();

      int jwtTimeMinute = JWTModel._jwtTimeMinute;

      GetUserRefreshTokenResponse refreshToken = GetRefreshToken(Request.RefreshToken);
      if (refreshToken == null)
      {
        response.IsSucceed = false;
        response.Message = "Refresh Token bulunamadı!";
        response.ResultCode = (int)HttpStatusCode.NotFound;

        return response;
      }

      if (!refreshToken.UserRefreshToken.IsActive)
      {
        response.IsSucceed = false;
        response.Message = "Refresh Token kullanım dışı!";
        response.ResultCode = (int)HttpStatusCode.NotFound;

        return response;
      }

      GetUserRequest request = new GetUserRequest { Id = refreshToken.UserRefreshToken.UserId };
      UserViewModel user = _userService.Get(request).User;

      // yeni access token ve refresh token uretilir
      TokenModel tokenModel = new TokenModel() 
      {
        TenantId = user.Company.Tenant.TenantId,
        CompanyId = user.CompanyId,
        UserId = user.Id,
        UserTypeId = user.UserTypeId,
        Username = user.Username,
        Email = user.Email,
        FullName = user.FullName
      };
      Tuple<string, string> token = JwtManager.CreateToken(tokenModel, jwtTimeMinute);
      response.Token = token.Item1;

      // eski refresh token pasife alinir
      BaseResponse resultUpdate = RevokeTokenRefresh(refreshToken.UserRefreshToken.Id);
      if (resultUpdate == null || !resultUpdate.IsSucceed)
      {
        response.IsSucceed = false;
        response.Message = "Refresh Token pasife alınamadı!";
        response.ResultCode = (int)HttpStatusCode.NotFound;

        return response;
      }

      // yeni uretilen refresh token db e yazilir
      string newRefreshToken = token.Item2;
      //response.RefreshToken = newRefreshToken;
      BaseResponse resultInsert = InsertTokenRefresh(newRefreshToken, refreshToken.UserRefreshToken.UserId);
      if (resultInsert == null || !resultInsert.IsSucceed)
      {
        response.IsSucceed = false;
        response.Message = "Refresh Token eklenemedi!";
        response.ResultCode = (int)HttpStatusCode.NotFound;

        return response;
      }

      return response;
    }

    /// <summary>
    /// Refresh token revoke for logout
    /// </summary>
    /// <param name="refreshToken"></param>
    /// <returns></returns>
    [HttpPost]
    [AllowAnonymous]
    public BaseResponse RevokeRefreshToken(string refreshToken)
    {
      BaseResponse response = new BaseResponse();
      if (string.IsNullOrEmpty(refreshToken))
      {
        response.IsSucceed = false;
        response.Message = "Refresh Token bulunamadı!";
        response.ResultCode = (int)HttpStatusCode.NotFound;

        return response;
      }

      // eski refresh token pasife alinir
      UserRefreshTokenViewModel entityRefreshToken = GetRefreshToken(refreshToken).UserRefreshToken;
      response = RevokeTokenRefresh(entityRefreshToken.Id);

      return response;
    }

    #region private

    private BaseResponse RevokeTokenRefresh(int Id)
    {
      // eski refresh token pasife alinir
      UpdateUserRefreshTokenRequest Request = new UpdateUserRefreshTokenRequest() { Id = Id, ClientUserId = CurrentUser.Id };
      BaseResponse response = _userService.RevokeTokenRefresh(Request);

      return response;
    }

    private BaseResponse InsertTokenRefresh(string RefreshToken, int UserId)
    {
      BaseResponse response = new BaseResponse();

      // verilen refresh token db e yazilir
      UserRefreshTokenViewModel newUserRefreshToken = new UserRefreshTokenViewModel()
      {
        RefreshToken = RefreshToken,
        UserId = UserId,
        IsActive = true
      };

      InsertUserRefreshTokenRequest insertRequest = new InsertUserRefreshTokenRequest()
      {
        UserRefreshToken = newUserRefreshToken,
        ClientUserId = UserId
      };

      response = _userService.InsertRefreshToken(insertRequest);

      return response;
    }

    private GetUserRefreshTokenResponse GetRefreshToken(string refreshToken)
    {
      GetUserRefreshTokenResponse response = new GetUserRefreshTokenResponse();
      GetUserRefreshTokenRequest request = new GetUserRefreshTokenRequest { RefreshToken = refreshToken };
      response.UserRefreshToken = _userService.GetTokenRefresh(request).UserRefreshToken;

      return response;
    }

    #endregion

    /// <summary>
    /// test connection web api as Anonymous
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [AllowAnonymous]
    public string Test()
    {
      return "Anonymous connection success.";
    }

    /// <summary>
    /// test connection web api with JWT Authorize bearer token
    /// </summary>
    /// <returns></returns>
    [Authorize]
    [HttpGet]
    public string TestJWT()
    {
      return "Authorize barrier overrun. Well Done.";
    }

  }
}