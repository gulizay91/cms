using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cms.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cms.WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MasterController : ControllerBase
  {
    public ClientUserViewModel CurrentUser
    {
      get
      {
        var claims = Request.HttpContext.User.Identities.Select(r => r.Claims).FirstOrDefault().ToList();

        int id = 0;
        Guid tenantId = new Guid();
        int companyId = 0;
        int userTypeId = 0;

        ClientUserViewModel clientUserserModel = new ClientUserViewModel();

        foreach (var claim in claims)
        {
          switch (claim.Type)
          {
            case "TenantId":
              Guid.TryParse(claim.Value, out tenantId);
              break;
            case "UserId":
              Int32.TryParse(claim.Value, out id);
              break;
            case "UserName":
              clientUserserModel.UserName = claim.Value;
              break;
            case "FullName":
              clientUserserModel.FullName = claim.Value;
              break;
            case "Email":
              clientUserserModel.Email = claim.Value;
              break;
            case "CompanyId":
              Int32.TryParse(claim.Value, out companyId);
              break;
            case "UserTypeId":
              Int32.TryParse(claim.Value, out userTypeId);
              break;
            default:
              break;
          }
        }

        clientUserserModel.TenantId = tenantId;
        clientUserserModel.Id = id;
        clientUserserModel.CompanyId = companyId;
        clientUserserModel.UserTypeId = userTypeId;

        return clientUserserModel;
      }
    }

  }
}