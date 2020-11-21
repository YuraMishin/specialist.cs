using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Data.Repositories;

namespace MVC.Areas.Admin.Controllers
{
  /// <summary>
  /// Class implements Category Controller
  /// </summary>
  [Area("Admin")]
  public class CategoryController : Controller
  {
    /// <summary>
    /// Category Repository
    /// </summary>
    private readonly ICategoryRepository _categoryRepository;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="categoryRepository">Category Repository</param>
    public CategoryController(ICategoryRepository categoryRepository)
    {
      _categoryRepository = categoryRepository;
    }

    /// <summary>
    /// Method retrieves all categories.
    /// GET: /admin/category/
    /// </summary>
    /// <returns>IActionResult</returns>
    public async Task<IActionResult> Index()
    {
      var categories = await _categoryRepository.RetrieveAllCategories();

      return View(categories);
    }
  }
}
