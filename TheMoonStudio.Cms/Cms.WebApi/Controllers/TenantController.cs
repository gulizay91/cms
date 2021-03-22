using Cms.Model.Exchanges.Tenant;
using Cms.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Cms.WebApi.Controllers
{
  [Route("api/[controller]/[action]")]
  [ApiController]
  public class TenantController : BaseController
  {
    private ITenantService _tenantService;

    public TenantController(ITenantService tenantService)
    {
      _tenantService = tenantService;
    }

    /// <summary>
    /// Get Entity
    /// </summary>
    /// <param name="Request"></param>
    /// <returns></returns>
    [HttpPost]
    public GetTenantResponse Get([FromBody] GetTenantRequest Request)
    {
      RequestInitialization(Request);
      GetTenantResponse response = _tenantService.Get(Request);

      return response;
    }

    /// <summary>
    /// Get Entities
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public GetTenantsResponse GetList()
    {
      //RequestInitialization(Request);
      GetTenantsResponse response = _tenantService.GetList();

      return response;
    }

    /// <summary>
    /// Save Entity
    /// </summary>
    /// <param name="Request"></param>
    /// <returns></returns>
    [HttpPost]
    public GetTenantResponse Save([FromBody] SaveTenantRequest Request)
    {
      RequestInitialization(Request);
      GetTenantResponse response = _tenantService.SaveTenant(Request);

      return response;
    }

  }
}