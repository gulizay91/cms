using Cms.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Repository.Interface.EntityFramework
{
  public interface IUserRepository : IGenericRepository<User>
  {
    User GetUserByUsername(string Username, Nullable<Guid> TenantId = null, Nullable<int> CompanyId = null);
  }
}
