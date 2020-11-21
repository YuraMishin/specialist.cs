using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MVC.Data.Repositories;
using MVC.Models;

namespace MVC.Services
{
  /// <summary>
  /// Class CategoryService.
  /// Implements ICategoryService
  /// </summary>
  public class CategoryService : ICategoryService
  {
    /// <summary>
    /// Category Repository
    /// </summary>
    private readonly ICategoryRepository _categoryRepository;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="categoryRepository">Category Repository</param>
    public CategoryService(ICategoryRepository categoryRepository)
    {
      _categoryRepository = categoryRepository;
    }

    /// <summary>
    /// Method retrieves all categories
    /// </summary>
    /// <returns>IEnumerable&lt;Category&gt;</returns>
    public Task<IEnumerable<Category>> RetrieveAllCategories()
    {
      var retrieveAllCategories = _categoryRepository.RetrieveAllCategories();

      return retrieveAllCategories;
    }
  }
}
