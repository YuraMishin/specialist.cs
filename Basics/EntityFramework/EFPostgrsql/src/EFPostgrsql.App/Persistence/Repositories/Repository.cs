using EFPostgrsql.App.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EFPostgrsql.App.Persistence.Repositories
{
  /// <summary>
  /// Class Repository.
  /// Implements IRepository
  /// </summary>
  /// <typeparam name="TEntity">TEntity</typeparam>
  public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
  {
    /// <summary>
    /// DbContext
    /// </summary>
    protected readonly DbContext Context;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="context"></param>
    public Repository(DbContext context)
    {
      Context = context;
    }

    /// <summary>
    /// Method gets TEntity by id
    /// </summary>
    /// <param name="id">Id</param>
    /// <returns>TEntity</returns>
    public TEntity Get(int id)
    {
      return Context.Set<TEntity>().Find(id);
    }

    /// <summary>
    /// Method gets all TEntities
    /// </summary>
    /// <returns>IEnumerable&lt;TEntity&gt;</returns>
    public IEnumerable<TEntity> GetAll()
    {
      return Context.Set<TEntity>().ToList();
    }

    // <summary>
    /// Method finds TEntity
    /// </summary>
    /// <param name="predicate">predicate</param>
    /// <returns>TEntity</returns>
    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
      return Context.Set<TEntity>().Where(predicate);
    }

    /// <summary>
    /// Method get TEntity
    /// </summary>
    /// <param name="predicate">Predicate</param>
    /// <returns></returns>
    public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
    {
      return Context.Set<TEntity>().SingleOrDefault(predicate);
    }

    /// <summary>
    /// Method adds TEntity
    /// </summary>
    /// <param name="entity">TEntity</param>
    public void Add(TEntity entity)
    {
      Context.Set<TEntity>().Add(entity);
    }

    /// <summary>
    /// Method adds range of TEntities
    /// </summary>
    /// <param name="entities">IEnumerable&lt;TEntity&gt;</param>
    public void AddRange(IEnumerable<TEntity> entities)
    {
      Context.Set<TEntity>().AddRange(entities);
    }

    /// <summary>
    /// Method removes TEntity
    /// </summary>
    /// <param name="entity">TEntity</param>
    public void Remove(TEntity entity)
    {
      Context.Set<TEntity>().Remove(entity);
    }

    /// <summary>
    /// Method removes range of TEntities
    /// </summary>
    /// <param name="entities">IEnumerable&lt;TEntity&gt;</param>
    public void RemoveRange(IEnumerable<TEntity> entities)
    {
      Context.Set<TEntity>().RemoveRange(entities);
    }
  }
}
