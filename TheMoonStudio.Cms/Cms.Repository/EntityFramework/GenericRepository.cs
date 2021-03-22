using Cms.Repository.Interface.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Cms.Repository.EntityFramework
{
  public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
  {
    private readonly DbContext _dbContext;
    private DbSet<TEntity> _dbSet;

    public DbSet<TEntity> Table
    {
      get
      {
        if (_dbSet == null)
          _dbSet = _dbContext.Set<TEntity>();

        return _dbSet;
      }
    }

    public GenericRepository(DbContext dbContext)
    {
      //dbContext.Configuration.LazyLoadingEnabled = false;
      _dbContext = dbContext;
      _dbSet = _dbContext.Set<TEntity>();
    }

    public TEntity Insert(TEntity entity, int userId)
    {
      try
      {
        if (entity.GetType().GetProperty("CreateUser") != null)
          entity.GetType().GetProperty("CreateUser").SetValue(entity, userId, null);
        if (entity.GetType().GetProperty("CreateDate") != null)
          entity.GetType().GetProperty("CreateDate").SetValue(entity, DateTime.Now, null);
        if (entity.GetType().GetProperty("IsActive") != null)
          entity.GetType().GetProperty("IsActive").SetValue(entity, true, null);

        _dbSet.Add(entity);

        return entity;
      }
      catch (Exception ex)
      {
        // TODO : Logger eklenecek.
        return null;
        throw new NotImplementedException("Logger eklenmedi");
      }
    }

    public TEntity Update(TEntity entity, int userId)
    {
      try
      {
        if (entity.GetType().GetProperty("UpdateUser") != null)
          entity.GetType().GetProperty("UpdateUser").SetValue(entity, userId, null);
        if (entity.GetType().GetProperty("UpdateDate") != null)
          entity.GetType().GetProperty("UpdateDate").SetValue(entity, DateTime.Now, null);

        //_dbSet.Attach(entity);
        //_dbContext.Entry(entity).State = EntityState.Modified;
        _dbSet.Update(entity);

        return entity;
      }
      catch (Exception ex)
      {
        // TODO : Logger eklenecek.
        return null;
        throw new NotImplementedException("Logger eklenmedi");
      }
    }

    public void Delete(object id)
    {
      TEntity entityToDelete = _dbSet.Find(id);
      if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
      {
        _dbSet.Attach(entityToDelete);
      }
      _dbSet.Remove(entityToDelete);
    }

    public TEntity GetById(object id)
    {
      return _dbSet.Find(id);
    }

    public TEntity Find(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
    {
      try
      {
        IQueryable<TEntity> query = _dbSet;

        if (includes != null)
        {
          foreach (Expression<Func<TEntity, object>> include in includes)
            query = query.Include(include);
        }

        if (filter != null)
          query = query.Where(filter);

        return query.FirstOrDefault();
      }
      catch (Exception ex)
      {
        return null;
        // TODO : Logger eklenecek.
        throw new NotImplementedException("Logger eklenmedi");
      }
    }

    public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
    {
      IQueryable<TEntity> query = _dbSet;

      foreach (Expression<Func<TEntity, object>> include in includes)
        query = query.Include(include);

      if (filter != null)
        query = query.Where(filter);

      if (orderBy != null)
        query = orderBy(query);

      return query.ToList();
    }

    public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
    {
      IQueryable<TEntity> query = _dbSet;

      foreach (Expression<Func<TEntity, object>> include in includes)
        query = query.Include(include);

      if (filter != null)
        query = query.Where(filter);

      return query;
    }
  }
}
