using Cms.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cms.WebApi.Models
{
  public class TokenModel
  {
    public Guid TenantId { get; set; }
    public int UserId { get; set; }
    public int CompanyId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public int UserTypeId { get; set; }
    public string FullName { get; set; }
    //public string RefreshToken { get; set; }

    public List<SettingsViewModel> Settings { get; set; }
  }
}
