using Cms.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Model.Exchanges.Tenant
{
  public class SaveTenantRequest : BaseRequest
  {
    public TenantViewModel Tenant { get; set; }

  }
}
