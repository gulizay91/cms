using AutoMapper;
using Cms.Data.Entity;
using Cms.Mail;
using Cms.Model.Exchanges;
using Cms.Model.ViewModels;
using Cms.Repository.Interface.EntityFramework;
using Cms.Service.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Cms.Service
{
  public class UserService : BaseService, IUserService
  {
    public UserService(IUnitOfWork uof, IMapper mapper) : base(uof, mapper)
    {

    }

    #region LoginAndToken

    /// <summary>
    /// Change Password with UserId
    /// </summary>
    /// <param name="Request"></param>
    /// <returns></returns>
    public GetUserResponse ChangePassword(ChangePasswordRequest Request)
    {
      return base.ExecuteWithExceptionHandledOperation(() =>
      {
        GetUserResponse response = new GetUserResponse();
        User user = _uof.UserRepository.GetById(Request.UserId);

        if (user == null)
        {
          response.IsSucceed = false;
          response.ResultCode = (int)HttpStatusCode.NotFound;
          response.Message = "Kullanıcı bulunamadı.";

          return response;
        }

        if (user.Password != Request.OldPassword)
        {
          response.IsSucceed = false;
          response.ResultCode = (int)HttpStatusCode.NotFound;
          response.Message = "Eski şifrenizi yanlış girdiniz!";

          return response;
        }

        if (Request.NewPassword.Length > 30)
        {
          response.IsSucceed = false;
          response.ResultCode = (int)HttpStatusCode.NotFound;
          response.Message = "Şifre uzunluğu 30 karakterden fazla olamaz!";

          return response;
        }

        user.Password = Request.NewPassword;

        var resultUpdate = _uof.UserRepository.Update(user, Request.ClientUserId);
        if (resultUpdate == null)
        {
          response.IsSucceed = false;
          response.Message = "Yeni şifre değiştirilirken bir hata oluştu. İşlem Başarısız!";
          response.ResultCode = (int)HttpStatusCode.ExpectationFailed;

          return response;
        }

        // Commit changes
        _uof.Commit();
        response.User = _mapper.Map<UserViewModel>(user);

        bool? resultMail = SendInfoMailForUser(user);
        if (!resultMail.HasValue || !resultMail.Value)
        {
          response.IsSucceed = false;
          response.Message = "Şifreniz değiştirildi, fakat mail gönderilirken bir hata oluştu!";
          response.ResultCode = (int)HttpStatusCode.ExpectationFailed;

          return response;
        }

        return response;
      });
    }

    /// <summary>
    /// Reset Password with email
    /// </summary>
    /// <param name="Request"></param>
    /// <returns></returns>
    public BaseResponse ResetPassword(ResetPasswordRequest Request)
    {
      return base.ExecuteWithExceptionHandledOperation(() =>
      {
        BaseResponse response = new BaseResponse
        {
          Message = "Yeni şifreniz mail adresinize gönderilmiştir."
        };

        User user = _uof.UserRepository.GetUserByUsername(Request.Email);
        if (user == null)
        {
          response.IsSucceed = false;
          response.ResultCode = (int)HttpStatusCode.NotFound;
          response.Message = Request.Email + " mail adresine tanımlı kullanıcı bulunamadı.";

          return response;
        }

        user.Password = GeneratePassword();

        var resultUpdate = _uof.UserRepository.Update(user, Request.ClientUserId);
        if (resultUpdate == null)
        {
          response.IsSucceed = false;
          response.Message = "Yeni şifre değiştirilirken bir hata oluştu. İşlem Başarısız!";
          response.ResultCode = (int)HttpStatusCode.ExpectationFailed;

          return response;
        }

        // Commit changes
        _uof.Commit();

        bool? resultMail = SendInfoMailForUser(user);
        if (!resultMail.HasValue || !resultMail.Value)
        {
          response.IsSucceed = false;
          response.Message = "Şifreniz resetlendi, fakat mail gönderilirken bir hata oluştu!";
          response.ResultCode = (int)HttpStatusCode.ExpectationFailed;

          return response;
        }

        return response;
      });
    }

    /// <summary>
    /// AccountController AllowAnonymous, login
    /// </summary>
    /// <param name="Request"></param>
    /// <returns></returns>
    public GetUserResponse LoginUserControl(LoginUserRequest Request)
    {
      return base.ExecuteWithExceptionHandledOperation(() =>
      {
        GetUserResponse response = new GetUserResponse();

        User user = _uof.UserRepository.GetUserByUsername(Request.Username);

        response = new GetUserResponse
        {
          User = _mapper.Map<UserViewModel>(user),
          IsSucceed = true,
          ResultCode = (int)HttpStatusCode.OK,
          Message = "Kullanıcı başarılı bir şekilde giriş yaptı."
        };

        if (user == null)
        {
          response.IsSucceed = false;
          response.ResultCode = (int)HttpStatusCode.NotFound;
          response.Message = "Kullanıcı bulunamadı.";

          return response;
        }

        bool validatePass = false;
        if (user.Password == Request.Password)
          validatePass = true;

        if (!validatePass || !user.IsActive)
        {
          if (validatePass && !user.IsActive)
          {
            response.IsSucceed = false;
            response.ResultCode = (int)HttpStatusCode.Forbidden;
            response.Message = "Kullanıcı pasif. Giriş yapamaz!";
          }
          else if (!validatePass && user.IsActive)
          {
            response.IsSucceed = false;
            response.ResultCode = (int)HttpStatusCode.Unauthorized;
            response.Message = "Şifre hatalı!";
          }
          else // hem sifre hatali hem kullanici pasif
          {
            response.IsSucceed = false;
            response.ResultCode = (int)HttpStatusCode.NotFound;
            response.Message = "Giriş başarısız! Kullanıcı pasif ve Şifre hatalı.";
          }

          return response;
        }

        return response;
      });
    }

    /// <summary>
    /// RefreshToken Kaydet
    /// </summary>
    /// <param name="Request"></param>
    /// <returns></returns>
    public BaseResponse InsertRefreshToken(InsertUserRefreshTokenRequest Request)
    {
      return base.ExecuteWithExceptionHandledOperation(() =>
      {
        BaseResponse response = new BaseResponse();
        UserRefreshToken entity = _mapper.Map<UserRefreshToken>(Request.UserRefreshToken);

        UserRefreshToken resultInsert = _uof.UserRefreshTokenRepository.Insert(entity, Request.ClientUserId);
        if (resultInsert == null)
        {
          response.IsSucceed = false;
          response.Message = "Refresh Token ekleme işlemi başarısız.";
          response.ResultCode = (int)HttpStatusCode.ExpectationFailed;

          return response;
        }

        // Commit changes
        _uof.Commit();

        return response;
      });
    }

    /// <summary>
    /// RefreshToken guncelle
    /// </summary>
    /// <param name="Request"></param>
    /// <returns></returns>
    public GetUserRefreshTokenResponse GetTokenRefresh(GetUserRefreshTokenRequest Request)
    {
      return base.ExecuteWithExceptionHandledOperation(() =>
      {
        GetUserRefreshTokenResponse response = new GetUserRefreshTokenResponse();

        UserRefreshToken token = _uof.UserRefreshTokenRepository.GetRefreshTokenByToken(Request.RefreshToken);
        response.UserRefreshToken = _mapper.Map<UserRefreshTokenViewModel>(token);

        return response;
      });
    }

    /// <summary>
    /// RefreshToken revoke
    /// </summary>
    /// <param name="Request"></param>
    /// <returns></returns>
    public BaseResponse RevokeTokenRefresh(UpdateUserRefreshTokenRequest Request)
    {
      return base.ExecuteWithExceptionHandledOperation(() =>
      {
        BaseResponse response = new BaseResponse();
        UserRefreshToken entity = _uof.UserRefreshTokenRepository.Find(x => x.Id == Request.Id && x.IsActive);
        if (entity == null)
        {
          response.IsSucceed = false;
          response.Message = "Güncellenecek refresh token bulunamadı.";
          response.ResultCode = (int)HttpStatusCode.NotFound;

          return response;
        }

        entity.IsActive = false;
        var resultUpdate = _uof.UserRefreshTokenRepository.Update(entity, Request.ClientUserId);
        if (resultUpdate == null)
        {
          response.IsSucceed = false;
          response.Message = "Refresh Token güncelleme işlemi başarısız.";
          response.ResultCode = (int)HttpStatusCode.NotFound;

          return response;
        }

        // Commit changes
        _uof.Commit();

        return response;
      });
    }

    #endregion

    public GetUserResponse Get(GetUserRequest Request)
    {
      return base.ExecuteWithExceptionHandledOperation(() =>
      {
        GetUserResponse response = new GetUserResponse();

        User entity = _uof.UserRepository.Find(r => r.IsActive == true 
                                                && (Request.Id == null || r.Id == Request.Id)
                                                && (string.IsNullOrEmpty(Request.Username) || r.Username == Request.Username)
                                                && r.Company.Tenant.TenantId == Request.ClientTenantId, null);

        if (entity == null)
        {
          response.IsSucceed = false;
          response.Message = "İşlem başarısız!";
          response.ResultCode = (int)HttpStatusCode.ExpectationFailed;

          return response;
        }

        response.User = _mapper.Map<UserViewModel>(entity);

        return response;
      });
    }

    #region private

    private string GeneratePassword()
    {
      int size = 5;
      Random rSize = new Random();
      size = rSize.Next(5, 15); // 5<size<15

      //char[] crAll = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
      char[] crAll = "0123456789abcdefghijklmnopqrstuvwxyz".ToCharArray();
      char[] crNumber = "0123456789".ToCharArray();
      //char[] crUppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
      char[] crLowercase = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

      string randomPassword = "123456";
      Random rChar = new Random();
      randomPassword += crLowercase[rChar.Next(0, crLowercase.Length)]; // at least one lowercase
      randomPassword += crNumber[rChar.Next(0, crNumber.Length)]; // at least one number
      for (int i = 0; i < size - 2; i++)
      {
        randomPassword += crAll[rChar.Next(0, crAll.Length - 1)].ToString();
      }

      return randomPassword;
    }

    private bool? SendInfoMailForUser(User userEntity)
    {
      bool? result = null;

      try
      {
        StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + "\\wwwroot\\MailTemplate\\DynamicMail.html", System.Text.Encoding.GetEncoding("iso-8859-9"));
        StringBuilder builderTable = new StringBuilder();
        builderTable.Append("<table border='1' class=\"table\">");

        builderTable.Append("<thead>");
        builderTable.Append("<tr>");
        builderTable.Append("<th scope=\"col\">Kullanıcı Adı</th>");
        builderTable.Append("<th scope=\"col\">Şifre</th>");
        builderTable.Append("</tr>");
        builderTable.Append("</thead>");

        builderTable.Append("<tbody>");
        builderTable.Append("<tr>");
        builderTable.AppendFormat("<td>{0}</td>", userEntity.Username);
        builderTable.AppendFormat("<td>{0}</td>", userEntity.Password);
        builderTable.Append("</tr>");
        builderTable.Append("</tbody>");
        builderTable.Append("</table>");

        List<string> sentToMailAddress = new List<string>();
        sentToMailAddress.Add(userEntity.Email);

        string subject = "CMS - Kullanıcı Bilgileri";
        var content = "Charter Yönetim Sistemine ait kullanıcı adınız ve parolanız belirlenmiştir, Linkten giriş yapabilirsiniz. <br/>";
        string body = sr.ReadToEnd();

        body = body.Replace("{dear}", "Sayın " + userEntity.FirstName + " " + userEntity.LastName + ",");
        body = body.Replace("{content}", content);
        body = body.Replace("{contentTable}", builderTable.ToString());
        body = body.Replace("{gorunsunMU}", "block");
        body = body.Replace("{footer}", "Charter Managament System");

        var setting = _uof.SettingsRepository.Find(r => r.IsActive && r.Tenant.TenantId == userEntity.Company.Tenant.TenantId
                                                                  && r.CompanyId == userEntity.CompanyId && r.Key == "BaseUrl");

        body = body.Replace("{url}", (setting.Value + "#/login"));

        List<string> sendAddressList = new List<string>()
         {
           userEntity.Email
         };

        MailSettingModel mail = new MailSettingModel()
        {
          Subject = subject,
          Body = body,
          To = sendAddressList
        };
        
        result = base.SendMail(mail, _mapper.Map<UserViewModel>(userEntity));

      }
      catch (Exception ex)
      {
        return false;
      }

      return result;
    }

    #endregion

  }
}
