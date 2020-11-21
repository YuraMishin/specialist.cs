using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Data.Repositories;
using MVC.Services;

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
    private readonly ICategoryService _categoryService;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="categoryService">Category Service</param>
    public CategoryController(ICategoryService categoryService)
    {
      _categoryService = categoryService;
    }

    /// <summary>
    /// Method retrieves all categories.
    /// GET: /admin/category/
    /// </summary>
    /// <returns>IActionResult</returns>
    public async Task<IActionResult> Index()
    {
      var categories = await _categoryService.RetrieveAllCategories();
      if (categories == null)
      {
        return NotFound();
      }

      return View(categories);
    }
  }
}
