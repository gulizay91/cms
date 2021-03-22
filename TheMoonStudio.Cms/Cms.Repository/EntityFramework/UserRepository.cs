using Cms.Data.Entity;
using Cms.Repository.Configuration;
using Cms.Repository.Interface.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cms.Repository.EntityFramework
{
  public class UserRepository : GenericRepository<User>, IUserRepository
  {
    private AppDbContext _context;

    public UserRepository(AppDbContext dbContext) : base(dbContext)
    {
      _context = dbContext;
    }

    public User GetUserByUsername(string Username, Nullable<Guid> TenantId = null, Nullable<int> CompanyId = null)
    {
      User entity = new User();

      try
      {
        System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        System.Text.RegularExpressions.Match match = regex.Match(Username);

        if (match.Success) // username mail adresi ise mail ile useri getir
          entity = _context.User
                    .Include(r => r.Company)
                      .ThenInclude(r => r.Tenant)
                    .Include(r => r.UserType)
                  .SingleOrDefault(r => r.IsActive && r.Email == Username.Trim()
                                      && (!TenantId.HasValue || r.Company.TenantId == TenantId)
                                      && (!CompanyId.HasValue || r.CompanyId == CompanyId));
        else
          entity = _context.User
                    .Include(r => r.Company)
                      .ThenInclude(r => r.Tenant)
                    .Include(r => r.UserType)
                  .SingleOrDefault(r => r.IsActive && r.Username == Username.Trim()
                                      && (!TenantId.HasValue || r.Company.TenantId == TenantId)
                                      && (!CompanyId.HasValue || r.CompanyId == CompanyId));
      }
      catch (Exception ex)
      {
        entity = null;
        //NLogLogger.Log(ex, "INFRASTRUCTURE_Repo", LogPriorityEnum.High);
      }


      return entity;
    }
  }
}
