using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Model.Exchanges
{
  public class GetUserRefreshTokenRequest : BaseRequest
  {
    public string RefreshToken { get; set; }
  }
}
