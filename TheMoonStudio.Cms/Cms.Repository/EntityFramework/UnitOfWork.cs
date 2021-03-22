using Cms.Repository.Configuration;
using Cms.Repository.Interface.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cms.Repository.EntityFramework
{
  public class UnitOfWork : IUnitOfWork
  {
    private bool disposed = false;
    private readonly AppDbContext _context;

    private Dictionary<Type, object> _repositories;

    public UnitOfWork(AppDbContext context)
    {
      _context = context;
    }

    public IGenericRepository<TEntity> GetRepository<TEntity>()
        where TEntity : class
    {
      if (_repositories == null)
      {
        _repositories = new Dictionary<System.Type, object>();
      }

      var type = typeof(TEntity);
      if (!_repositories.ContainsKey(type))
      {
        _repositories[type] = new GenericRepository<TEntity>(_context);
      }

      return (IGenericRepository<TEntity>)_repositories[type];
    }

    public void Commit()
    {
      _context.SaveChanges();
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!this.disposed)
      {
        if (disposing)
        {
          _context.Dispose();
        }
      }
      this.disposed = true;
    }

    public void Dispose()
    {
      Dispose(true);
      System.GC.SuppressFinalize(this);
    }

    private readonly ITenantRepository _tenantRepository;
    public ITenantRepository TenantRepository => _tenantRepository ?? new TenantRepository(_context);


    private readonly ITenantHistoryRepository _tenantHistoryRepository;
    public ITenantHistoryRepository TenantHistoryRepository => _tenantHistoryRepository ?? new TenantHistoryRepository(_context);


    private readonly ICompanyRepository _companyRepository;
    public ICompanyRepository CompanyRepository => _companyRepository ?? new CompanyRepository(_context);


    private readonly IUserRepository _userRepository;
    public IUserRepository UserRepository => _userRepository ?? new UserRepository(_context);

    private readonly IUserRefreshTokenRepository _userRefreshTokenRepository;
    public IUserRefreshTokenRepository UserRefreshTokenRepository => _userRefreshTokenRepository ?? new UserRefreshTokenRepository(_context);

    private readonly IUserTypeRepository _userTypeRepository;
    public IUserTypeRepository UserTypeRepository => _userTypeRepository ?? new UserTypeRepository(_context);


    private readonly IBoatRepository _boatRepository;
    public IBoatRepository BoatRepository => _boatRepository ?? new BoatRepository(_context);


    private readonly IBoatHistoryRepository _boatHistoryRepository;
    public IBoatHistoryRepository BoatHistoryRepository => _boatHistoryRepository ?? new BoatHistoryRepository(_context);


    private readonly IBoatCrewRepository _boatCrewRepository;
    public IBoatCrewRepository BoatCrewRepository => _boatCrewRepository ?? new BoatCrewRepository(_context);


    private readonly ICrewRepository _crewRepository;
    public ICrewRepository CrewRepository => _crewRepository ?? new CrewRepository(_context);


    private readonly ICharterRepository _charterRepository;
    public ICharterRepository CharterRepository => _charterRepository ?? new CharterRepository(_context);


    private readonly IMarinaRepository _marinaRepository;
    public IMarinaRepository MarinaRepository => _marinaRepository ?? new MarinaRepository(_context);


    private readonly IFixtureRepository _fixtureRepository;
    public IFixtureRepository FixtureRepository => _fixtureRepository ?? new FixtureRepository(_context);


    private readonly IExpenseRepository _expenseRepository;
    public IExpenseRepository ExpenseRepository => _expenseRepository ?? new ExpenseRepository(_context);


    private readonly IExpenseTypeRepository _expenseTypeRepository;
    public IExpenseTypeRepository ExpenseTypeRepository => _expenseTypeRepository ?? new ExpenseTypeRepository(_context);


    private readonly ISettingsRepository _settingsRepository;
    public ISettingsRepository SettingsRepository => _settingsRepository ?? new SettingsRepository(_context);

  }
}
