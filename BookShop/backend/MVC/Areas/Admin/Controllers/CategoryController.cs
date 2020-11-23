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

    /// <summary>
    /// Method shows UI to edit category.
    /// GET: /admin/category/edit?id=foo
    /// </summary>
    /// <param name="id">Id</param>
    /// <returns>IActionResult</returns>
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var category = await _db.Categories.FindAsync(id);
      if (category == null)
      {
        return NotFound();
      }

      return View(category);
    }

    /// <summary>
    /// Method updates category.
    /// /// POST: /admin/category/edit
    /// </summary>
    /// <param name="category">Category</param>
    /// <returns>IActionResult</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Category category)
    {
      if (ModelState.IsValid)
      {
        _db.Categories.Update(category);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }

      return View(category);
    }

    /// <summary>
    /// Method shows UI to delete category.
    /// GET: /admin/category/delete?id=foo
    /// </summary>
    /// <param name="id">Id</param>
    /// <returns>IActionResult</returns>
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var category = await _db.Categories.FindAsync(id);
      if (category == null)
      {
        return NotFound();
      }

      return View(category);
    }

    /// <summary>
    /// Method deletes category.
    /// POST: /admin/category/delete?id=foo
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var category = await _db.Categories.FindAsync(id);
      if (category == null)
      {
        return View();
      }

      _db.Categories.Remove(category);
      await _db.SaveChangesAsync();

      return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Method shows UI to read category details.
    /// GET: /admin/category/details?id=foo
    /// </summary>
    /// <param name="id">Id</param>
    /// <returns>IActionResult</returns>
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var category = await _db.Categories.FindAsync(id);
      if (category == null)
      {
        return NotFound();
      }

      return View(category);
    }
  }
}
