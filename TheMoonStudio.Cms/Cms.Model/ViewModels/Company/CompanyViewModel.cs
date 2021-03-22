using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Model.ViewModels
{
  public class CompanyViewModel
  {
    public int Id { get; set; }
    public Guid TenantId { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }

    public TenantViewModel Tenant { get; set; }
  }
}
