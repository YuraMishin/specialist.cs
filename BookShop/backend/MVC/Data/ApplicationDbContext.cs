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

    /// <summary>
    /// SubCategories table
    /// </summary>
    public DbSet<SubCategory> SubCategories { get; set; }

    /// <summary>
    /// Books table
    /// </summary>
    public DbSet<Book> Books { get; set; }

    /// <summary>
    /// Coupons table
    /// </summary>
    public DbSet<Coupon> Coupons { get; set; }

    /// <summary>
    /// Extends AspNetUsers table
    /// </summary>
    public DbSet<ApplicationUser> ApplicationUser { get; set; }

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
