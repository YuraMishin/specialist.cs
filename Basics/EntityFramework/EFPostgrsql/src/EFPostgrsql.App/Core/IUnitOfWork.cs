using EFPostgrsql.App.Core.Repositories;
using System;

namespace EFPostgrsql.App.Core
{
  /// <summary>
  /// Interface IUnitOfWork.
  ///  Declares method for a transaction
  /// </summary>
  public interface IUnitOfWork : IDisposable
  {
    /// <summary>
    /// Books
    /// </summary>
    IBookRepository Books { get; }

    /// <summary>
    /// Method completes the transaction
    /// </summary>
    /// <returns>int</returns>
    int Complete();
  }
}
