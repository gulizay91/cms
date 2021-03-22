using AutoMapper;
using Cms.Repository.Interface.EntityFramework;
using Cms.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Service
{
  public class UserTypeService : BaseService, IUserTypeService
  {
    public UserTypeService(IUnitOfWork uof, IMapper mapper) : base(uof, mapper)
    {

    }
  }
}

