using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Cms.Repository.Interface.EntityFramework
{
  public interface IGenericRepository<TEntity>
  {
    /// <summary>
    /// Insert entity to db
    /// </summary>
    /// <param name="entity"></param>
    TEntity Insert(TEntity entity, int userId);

    /// <summary>
    /// Update entity in db
    /// </summary>
    /// <param name="entity"></param>
    TEntity Update(TEntity entity, int userId);

    /// <summary>
    /// Delete entity from db by primary key
    /// </summary>
    /// <param name="id"></param>
    void Delete(object id);

    /// <summary>
    /// Get single entity by primary key
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    TEntity GetById(object id);

    /// <summary>
    /// Find entity with expression and includes
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="includes"></param>
    /// <returns></returns>
    TEntity Find(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes);

    /// <summary>
    /// Get all entities from db
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="orderBy"></param>
    /// <param name="includes"></param>
    /// <returns></returns>
    List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes);

    /// <summary>
    /// Get query for entity
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="includes"></param>
    /// <returns></returns>
    IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);
  }
}
