using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Model.Exchanges
{
  public class GetUserRequest : BaseRequest
  {
    public int? Id { get; set; }
    public string Username { get; set; }
  }
}
