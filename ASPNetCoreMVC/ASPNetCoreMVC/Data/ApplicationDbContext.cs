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
    #region DbTables

    /// <summary>
    /// Categories table
    /// </summary>
    public DbSet<Category> Categories { get; set; }

    /// <summary>
    /// SubCategories table
    /// </summary>
    public DbSet<SubCategory> SubCategories { get; set; }

    /// <summary>
    /// MenuItems table
    /// </summary>
    public DbSet<MenuItem> MenuItems { get; set; }

    /// <summary>
    /// Coupons table
    /// </summary>
    public DbSet<Coupon> Coupons { get; set; }

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
