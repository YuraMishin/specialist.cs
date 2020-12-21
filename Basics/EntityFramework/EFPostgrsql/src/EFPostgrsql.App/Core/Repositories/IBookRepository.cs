using EFPostgrsql.App.Core.Models;
using System.Collections.Generic;

namespace EFPostgrsql.App.Core.Repositories
{
  /// <summary>
  /// Interface IBookRepository.
  /// Derives IRepository
  /// </summary>
  public interface IBookRepository : IRepository<Book>
  {
    /// <summary>
    /// Method gets topselling books
    /// </summary>
    /// <param name="count">Count</param>
    /// <returns>IEnumerable&lt;Book&gt;</returns>
    IEnumerable<Book> GetTopSellingBooks(int count);

    /// <summary>
    /// Method gets books with authors
    /// </summary>
    /// <param name="pageIndex">PageIndex</param>
    /// <param name="pageSize">PageSize</param>
    /// <returns></returns>
    IEnumerable<Book> GetBooksWithAuthors(int pageIndex, int pageSize);
  }
}
