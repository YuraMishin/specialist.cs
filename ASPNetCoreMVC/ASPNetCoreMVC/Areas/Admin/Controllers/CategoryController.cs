using ASPNetCoreMVC.Data;
using ASPNetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ASPNetCoreMVC.Areas.Admin.Controllers
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
    /// Constructor
    /// </summary>
    /// <param name="_db">Db Context</param>
    public CategoryController(ApplicationDbContext _db)
    {
      this._db = _db;
    }

    /// <summary>
    /// Method gets all categories
    /// </summary>
    /// <returns></returns>
    public async Task<IActionResult> Index()
    {
      return View(await _db.Categories.ToListAsync());
    }

    /// <summary>
    /// Method displays Create UI
    /// </summary>
    /// <returns></returns>
    public IActionResult Create()
    {
      return View();
    }

    /// <summary>
    /// Method saves category
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