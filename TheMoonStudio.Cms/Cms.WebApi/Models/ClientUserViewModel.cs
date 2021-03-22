using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cms.WebApi.Models
{
  public class ClientUserViewModel
  {
    public int Id { get; set; }

    public Guid TenantId { get; set; }

    public int CompanyId { get; set; }

    public int UserTypeId { get; set; }

    public string UserName { get; set; }

    public string FullName { get; set; }

    public string Email { get; set; }
  }
}
