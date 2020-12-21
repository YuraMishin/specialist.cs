using EFPostgrsql.App.Core.Models;
using EFPostgrsql.App.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EFPostgrsql.App.Persistence.Repositories
{
  public class BookRepository : Repository<Book>, IBookRepository
  {
    /// <summary>
    /// ApplicationDbContext
    /// </summary>
    public ApplicationDbContext ApplicationDbContext
    {
      get { return Context as ApplicationDbContext; }
    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="context">ApplicationDbContext</param>
    public BookRepository(ApplicationDbContext context)
        : base(context)
    {
    }

    /// <summary>
    /// Method gets topselling books
    /// </summary>
    /// <param name="count">Count</param>
    /// <returns>IEnumerable&lt;Book&gt;</returns>
    public IEnumerable<Book> GetTopSellingBooks(int count)
    {
      return ApplicationDbContext.Books.OrderByDescending(c => c.FullPrice).Take(count).ToList();
    }

    /// <summary>
    /// Method gets books with authors
    /// </summary>
    /// <param name="pageIndex">PageIndex</param>
    /// <param name="pageSize">PageSize</param>
    /// <returns></returns>
    public IEnumerable<Book> GetBooksWithAuthors(int pageIndex, int pageSize = 10)
    {
      return ApplicationDbContext.Books
          .Include(c => c.Author)
          .OrderBy(c => c.Name)
          .Skip((pageIndex - 1) * pageSize)
          .Take(pageSize)
          .ToList();
    }
  }
}
