using Cms.Data.Entity;
using Cms.Repository.Configuration;
using Cms.Repository.Interface.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Repository.EntityFramework
{
  public class ExpenseRepository : GenericRepository<Expense>, IExpenseRepository
  {
    private AppDbContext _context;

    public ExpenseRepository(AppDbContext dbContext) : base(dbContext)
    {
      _context = dbContext;
    }
  }
}
