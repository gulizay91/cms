using AutoMapper;
using Cms.Repository.Interface.EntityFramework;
using Cms.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Service
{
  public class ExpenseTypeService : BaseService, IExpenseTypeService
  {
    public ExpenseTypeService(IUnitOfWork uof, IMapper mapper) : base(uof, mapper)
    {

    }
  }
}
