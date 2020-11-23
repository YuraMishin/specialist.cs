using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Data;
using MVC.Models;
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
    /// DbContext
    /// </summary>
    private readonly ApplicationDbContext _db;

    /// <summary>
    /// Category Repository
    /// </summary>
    private readonly ICategoryService _categoryService;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="categoryService">Category Service</param>
    /// <param name="db">DbContext</param>
    public CategoryController(
      ICategoryService categoryService,
      ApplicationDbContext db
    )
    {
      _categoryService = categoryService;
      _db = db;
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

    /// <summary>
    /// Method displays Create UI.
    /// GET: /admin/category/create
    /// </summary>
    /// <returns></returns>
    public IActionResult Create()
    {
      return View();
    }

    /// <summary>
    /// Method saves category.
    /// POST: /admin/category/store
    /// </summary>
    /// <param name="category">Category</param>
    /// <returns>IActionResult</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Store(Category category)
    {
      if (ModelState.IsValid)
      {
        _db.Categories.Add(category);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }

      return View("Create", category);
    }
  }
}
