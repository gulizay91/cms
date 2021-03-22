using Cms.Data.Entity;
using Cms.Repository.Configuration;
using Cms.Repository.Interface.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Repository.EntityFramework
{
  public class CharterRepository : GenericRepository<Charter>, ICharterRepository
  {
    private AppDbContext _context;

    public CharterRepository(AppDbContext dbContext) : base(dbContext)
    {
      _context = dbContext;
    }
  }
}
