using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cms.WebApi.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class BaseController : MasterController
  {
    #region GetCurrentUserInfoForRequest
    protected T RequestInitialization<T>(T request)
    {
      var Instance = Activator.CreateInstance<T>();
      Instance = request;

      try
      {
        // baserequest
        Instance.GetType().GetProperty("ClientTenantId").SetValue(Instance, CurrentUser.TenantId, null);
        Instance.GetType().GetProperty("ClientUserId").SetValue(Instance, CurrentUser.Id, null);
        Instance.GetType().GetProperty("ClientUserName").SetValue(Instance, CurrentUser.UserName, null);

        // optional
        if (Instance.GetType().GetProperty("ClientUserTypeId") != null)
          Instance.GetType().GetProperty("ClientUserTypeId").SetValue(Instance, CurrentUser.UserTypeId, null);
        if (Instance.GetType().GetProperty("CompanyId") != null)
          Instance.GetType().GetProperty("CompanyId").SetValue(Instance, CurrentUser.CompanyId, null);
      }
      catch (Exception ex)
      {

      }

      return Instance;
    }
    #endregion
  }
}