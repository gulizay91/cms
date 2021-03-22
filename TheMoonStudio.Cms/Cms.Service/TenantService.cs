using AutoMapper;
using Cms.Data.Entity;
using Cms.Model.Exchanges.Tenant;
using Cms.Model.ViewModels;
using Cms.Repository.Interface.EntityFramework;
using Cms.Service.Interface;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Cms.Service
{
  public class TenantService : BaseService, ITenantService
  {
    public TenantService(IUnitOfWork uof, IMapper mapper) : base(uof, mapper)
    {

    }

    public GetTenantResponse Get(GetTenantRequest Request)
    {
      GetTenantResponse response = new GetTenantResponse();

      Tenant tenant = new Tenant();
      if(Request.Id.HasValue)
        tenant = _uof.TenantRepository.GetById(Request.Id);
      else if(Request.TenantId.HasValue)
        tenant = _uof.TenantRepository.Find(r => r.TenantId == Request.TenantId.Value);

      if (tenant == null)
      {
        response.IsSucceed = false;
        response.ResultCode = (int)HttpStatusCode.NotFound;
        response.Message = "Tenant bulunamadı.";

        return response;
      }

      response.Tenant = _mapper.Map<Tenant, TenantViewModel>(tenant);

      return response;
    }

    public GetTenantsResponse GetList()
    {
      GetTenantsResponse response = new GetTenantsResponse();

      List<Tenant> tenantList = new List<Tenant>();
      tenantList = _uof.TenantRepository.GetAll(r => r.IsActive);

      if (tenantList == null)
      {
        response.IsSucceed = false;
        response.ResultCode = (int)HttpStatusCode.NotFound;
        response.Message = "Tenantlar bulunamadı.";

        return response;
      }

      response.TenantList = _mapper.Map<List<Tenant>, List<TenantViewModel>>(tenantList);

      return response;
    }

    public GetTenantResponse SaveTenant(SaveTenantRequest Request)
    {
      GetTenantResponse response = new GetTenantResponse();
      Tenant entity = _mapper.Map<TenantViewModel, Tenant>(Request.Tenant);
      var result = _uof.TenantRepository.Insert(entity, Request.ClientUserId);
      if (result == null)
      {
        response.Fail((int)HttpStatusCode.BadRequest, "İşlem Başarısız!");
        return response;
      }
      return response;
    }
  }
}
