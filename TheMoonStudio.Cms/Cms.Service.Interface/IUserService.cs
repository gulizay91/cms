using Cms.Model.Exchanges;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Service.Interface
{
  public interface IUserService
  {
    GetUserResponse LoginUserControl(LoginUserRequest Request);
    BaseResponse InsertRefreshToken(InsertUserRefreshTokenRequest Request);
    GetUserRefreshTokenResponse GetTokenRefresh(GetUserRefreshTokenRequest Request);
    BaseResponse RevokeTokenRefresh(UpdateUserRefreshTokenRequest Request);

    GetUserResponse ChangePassword(ChangePasswordRequest Request);
    BaseResponse ResetPassword(ResetPasswordRequest Request);

    GetUserResponse Get(GetUserRequest Request);
  }
}
