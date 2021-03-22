using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Model.Exchanges
{
  public class ChangePasswordRequest : BaseRequest
  {
    public Nullable<int> CompanyId { get; set; }
    public int UserId { get; set; }
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
  }
}
