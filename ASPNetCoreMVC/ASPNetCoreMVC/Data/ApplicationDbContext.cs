using ASPNetCoreMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreMVC.Data
{
  /// <summary>
  /// Class implements DbContext
  /// </summary>
  public class ApplicationDbContext : IdentityDbContext
  {
    /// <summary>
    /// Categories table
    /// </summary>
    public DbSet<Category> Categories { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="options">DbContext</param>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
    {
    }
  }
}
