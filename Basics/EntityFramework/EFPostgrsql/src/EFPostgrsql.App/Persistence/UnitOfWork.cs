using EFPostgrsql.App.Core;
using EFPostgrsql.App.Core.Repositories;
using EFPostgrsql.App.Persistence.Repositories;

namespace EFPostgrsql.App.Persistence
{
  /// <summary>
  /// Class UnitOfWork.
  /// Implements IUnitOfWork
  /// </summary>
  public class UnitOfWork : IUnitOfWork
  {
    /// <summary>
    /// ApplicationDbContext
    /// </summary>
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// Books
    /// </summary>
    public IBookRepository Books { get; private set; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="context">ApplicationDbContext</param>
    public UnitOfWork(ApplicationDbContext context)
    {
      _context = context;
      Books = new BookRepository(_context);
    }

    /// <summary>
    /// Method completes the transaction
    /// </summary>
    /// <returns>int</returns>
    public int Complete()
    {
      return _context.SaveChanges();
    }

    /// <summary>
    /// Method disposes the resource
    /// </summary>
    public void Dispose()
    {
      _context.Dispose();
    }
  }
}
