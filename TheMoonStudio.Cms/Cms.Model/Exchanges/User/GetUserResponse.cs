using Cms.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Model.Exchanges
{
  public class GetUserResponse : BaseResponse
  {
    public UserViewModel User { get; set; }
  }
}
