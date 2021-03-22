using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Model.Exchanges
{
  public class ResetPasswordRequest : BaseRequest
  {
    public Nullable<int> CompanyId { get; set; }
    public Nullable<Guid> TenantId { get; set; }
    public string Email { get; set; }
  }
}
