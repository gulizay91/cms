using Cms.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Model.Exchanges.Tenant
{
  public class GetTenantResponse : BaseResponse
  {
    public TenantViewModel Tenant { get; set; }
  }
}
