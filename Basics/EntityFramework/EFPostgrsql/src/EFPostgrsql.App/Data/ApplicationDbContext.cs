using EFPostgrsql.App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace EFPostgrsql.App.Data
{
  /// <summary>
  /// Class ApplicationDbContext.
  /// Implements DbContext
  /// </summary>
  public class ApplicationDbContext : DbContext
  {
    #region DB Tables

    /// <summary>
    /// Books table
    /// </summary>
    public DbSet<Book> Books { get; set; }

    /// <summary>
    /// Authors table
    /// </summary>
    public DbSet<Author> Authors { get; set; }

    #endregion

    /// <summary>
    /// Method configures the database
    /// </summary>
    /// <param name="optionsBuilder">OptionsBuilder</param>
    protected override void OnConfiguring(
      DbContextOptionsBuilder optionsBuilder)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json")
        .Build();
      optionsBuilder.UseNpgsql(
        configuration.GetConnectionString("DefaultConnection"));
    }
  }
}
