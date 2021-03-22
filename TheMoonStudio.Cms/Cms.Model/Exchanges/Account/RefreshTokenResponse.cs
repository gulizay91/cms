using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Model.Exchanges
{
  public class RefreshTokenResponse : BaseResponse
  {
    public string Token { get; set; }
    public string RefreshToken { get; set; }
  }
}
