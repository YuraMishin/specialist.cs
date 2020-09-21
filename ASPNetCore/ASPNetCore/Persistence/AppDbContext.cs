using ASPNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCore.Persistence
{
  /// <summary>
  /// Database context class
  /// </summary>
  public class AppDbContext : DbContext
  {
    // Data Model
    public DbSet<Book> Book { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="options">DB context class</param>
    public AppDbContext(DbContextOptions<AppDbContext> options)
      : base(options)
    {
    }
  }
}
