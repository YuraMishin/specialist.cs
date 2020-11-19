using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Data
{
  /// <summary>
  /// Class implements DbContext
  /// </summary>
  public class ApplicationDbContext : IdentityDbContext
  {
    #region DB Tables

    /// <summary>
    /// Categories table
    /// </summary>
    public DbSet<Category> Categories { get; set; }

    #endregion

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
