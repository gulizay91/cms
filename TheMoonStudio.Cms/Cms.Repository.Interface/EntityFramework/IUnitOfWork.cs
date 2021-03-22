using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Repository.Interface.EntityFramework
{
  public interface IUnitOfWork : IDisposable
  {
    /// <summary>
    /// Gets the repository.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <returns>Repository</returns>
    IGenericRepository<TEntity> GetRepository<TEntity>()
        where TEntity : class;

    void Commit();

    ITenantRepository TenantRepository { get; }
    ITenantHistoryRepository TenantHistoryRepository { get; }
    ICompanyRepository CompanyRepository { get; }
    IUserRepository UserRepository { get; }
    IUserRefreshTokenRepository UserRefreshTokenRepository { get; }
    IUserTypeRepository UserTypeRepository { get; }
    IBoatRepository BoatRepository { get; }
    IBoatHistoryRepository BoatHistoryRepository { get; }
    IBoatCrewRepository BoatCrewRepository { get; }
    ICrewRepository CrewRepository { get; }
    ICharterRepository CharterRepository { get; }
    IMarinaRepository MarinaRepository { get; }
    IFixtureRepository FixtureRepository { get; }
    IExpenseRepository ExpenseRepository { get; }
    IExpenseTypeRepository ExpenseTypeRepository { get; }
    ISettingsRepository SettingsRepository { get; }

  }
}
