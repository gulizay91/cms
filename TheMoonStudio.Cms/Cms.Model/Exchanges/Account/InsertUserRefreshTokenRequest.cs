using Cms.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Model.Exchanges
{
  public class InsertUserRefreshTokenRequest : BaseRequest
  {
    public UserRefreshTokenViewModel UserRefreshToken { get; set; }
    //public string Username { get; set; }
  }
}
