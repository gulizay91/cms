using Cms.Model.Exchanges.Tenant;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Service.Interface
{
  public interface ITenantService
  {
    GetTenantResponse Get(GetTenantRequest Request);
    GetTenantsResponse GetList();
    GetTenantResponse SaveTenant(SaveTenantRequest Request);
  }
}
