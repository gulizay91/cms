using AutoMapper;
using Cms.Repository.Interface.EntityFramework;
using Cms.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Service
{
  public class ExpenseService : BaseService, IExpenseService
  {
    public ExpenseService(IUnitOfWork uof, IMapper mapper) : base(uof, mapper)
    {

    }
  }
}
