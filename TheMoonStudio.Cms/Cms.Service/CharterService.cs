using AutoMapper;
using Cms.Repository.Interface.EntityFramework;
using Cms.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Service
{
  public class CharterService : BaseService, ICharterService
  {
    public CharterService(IUnitOfWork uof, IMapper mapper) : base(uof, mapper)
    {

    }
  }
}

