using Cms.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Repository.Interface.EntityFramework
{
  public interface IUserRefreshTokenRepository : IGenericRepository<UserRefreshToken>
  {
    UserRefreshToken GetRefreshTokenByToken(string RefreshToken);
  }
}
