using Cms.Data.Entity;
using Cms.Repository.Configuration;
using Cms.Repository.Interface.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cms.Repository.EntityFramework
{
  public class UserRefreshTokenRepository : GenericRepository<UserRefreshToken>, IUserRefreshTokenRepository
  {
    private readonly AppDbContext _context;
    public UserRefreshTokenRepository(AppDbContext dbContext) : base(dbContext)
    {
      _context = dbContext;
    }

    public UserRefreshToken GetRefreshTokenByToken(string RefreshToken)
    {
      UserRefreshToken entity = new UserRefreshToken();

      try
      {
        entity = _context.UserRefreshToken.SingleOrDefault(r => r.RefreshToken == RefreshToken && r.IsActive);

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
