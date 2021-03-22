using Cms.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Model.Exchanges.Tenant
{
  public class GetTenantsResponse : BaseResponse
  {
    public List<TenantViewModel> TenantList { get; set; }

  }
}
