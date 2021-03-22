using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Model.ViewModels
{
  public class SettingsViewModel
  {
    public int Id { get; set; }
    public int TenantId { get; set; }
    public int? CompanyId { get; set; }
    public string Code { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }

    public TenantViewModel Tenant { get; set; }
  }
}
