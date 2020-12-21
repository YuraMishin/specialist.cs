using EFPostgrsql.App.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace EFPostgrsql.App.Persistence
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
    public virtual DbSet<Book> Books { get; set; }

    /// <summary>
    /// Authors table
    /// </summary>
    public virtual DbSet<Author> Authors { get; set; }

    /// <summary>
    /// Tags table
    /// </summary>
    public virtual DbSet<Tag> Tags { get; set; }

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

    /// <summary>
    /// Method applies configuration using Fluent API
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
  }
}
