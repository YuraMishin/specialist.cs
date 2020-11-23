using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVC.Models;

namespace MVC.Data.Repositories
{
  /// <summary>
  /// Class CategoryRepository.
  /// Implements ICategoryRepository
  /// </summary>
  public class CategoryRepository : ICategoryRepository
  {
    /// <summary>
    /// DbContext
    /// </summary>
    private readonly ApplicationDbContext _db;

    /// <summary>
    /// Logger
    /// </summary>
    private readonly ILogger<CategoryRepository> _logger;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="db"></param>
    /// <param name="logger"></param>
    public CategoryRepository(
      ApplicationDbContext db,
      ILogger<CategoryRepository> logger)
    {
      _db = db;
      _logger = logger;
    }

    /// <summary>
    /// Method retrieves all categories
    /// </summary>
    /// <returns>IEnumerable&lt;Category&gt;</returns>
    public async Task<IEnumerable<Category>> RetrieveAllCategories()
    {
      try
      {
        return await _db.Categories
          .OrderBy(category => category.Name)
          .ToListAsync();
      }
      catch (Exception ex)
      {
        _logger.LogError($"Failed to retrieve all categories: {ex.Message}");
        return null;
      }
    }
  }
}
