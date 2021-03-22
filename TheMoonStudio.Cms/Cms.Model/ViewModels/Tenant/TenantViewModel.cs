using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Model.ViewModels
{
  public class TenantViewModel
  {
    public int Id { get; set; }
    public Guid TenantId { get; set; }
    public string ApiKey { get; set; }
    public string Name { get; set; }
    public string Theme { get; set; }
    public bool? IsFrozen { get; set; }
    public bool IsActive { get; set; }
  }
}
