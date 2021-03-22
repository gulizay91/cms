using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Model.Exchanges.Tenant
{
  public class GetTenantRequest : BaseRequest
  {
    public int? Id { get; set; }
    public Guid? TenantId { get; set; }
  }
}
