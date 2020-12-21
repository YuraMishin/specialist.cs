using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EFPostgrsql.App.Core.Repositories
{
  /// <summary>
  /// Interface IRepository.
  /// Declares IRepository methods
  /// </summary>
  /// <typeparam name="TEntity">TEntity</typeparam>
  public interface IRepository<TEntity> where TEntity : class
  {
    /// <summary>
    /// Method gets TEntity by id
    /// </summary>
    /// <param name="id">Id</param>
    /// <returns>TEntity</returns>
    TEntity Get(int id);

    /// <summary>
    /// Method gets all TEntities
    /// </summary>
    /// <returns>IEnumerable&lt;TEntity&gt;</returns>
    IEnumerable<TEntity> GetAll();

    /// <summary>
    /// Method finds TEntity
    /// </summary>
    /// <param name="predicate">predicate</param>
    /// <returns>TEntity</returns>
    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

    /// <summary>
    /// Method get TEntity
    /// </summary>
    /// <param name="predicate">Predicate</param>
    /// <returns></returns>
    TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

    /// <summary>
    /// Method adds TEntity
    /// </summary>
    /// <param name="entity">TEntity</param>
    void Add(TEntity entity);

    /// <summary>
    /// Method adds range of TEntities
    /// </summary>
    /// <param name="entities">IEnumerable&lt;TEntity&gt;</param>
    void AddRange(IEnumerable<TEntity> entities);

    /// <summary>
    /// Method removes TEntity
    /// </summary>
    /// <param name="entity">TEntity</param>
    void Remove(TEntity entity);

    /// <summary>
    /// Method removes range of TEntities
    /// </summary>
    /// <param name="entities">IEnumerable&lt;TEntity&gt;</param>
    void RemoveRange(IEnumerable<TEntity> entities);
  }
}
