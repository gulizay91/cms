using Cms.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Model.Exchanges
{
  public class GetUserRefreshTokenResponse : BaseResponse
  {
    public UserRefreshTokenViewModel UserRefreshToken { get; set; }
  }
}
