using ASPNetCoreMVC.Data;
using ASPNetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ASPNetCoreMVC.Utility;
using Microsoft.AspNetCore.Authorization;

namespace ASPNetCoreMVC.Areas.Admin.Controllers
{
  /// <summary>
  /// Class implements Category Controller
  /// </summary>
  [Authorize(Roles = SD.ManagerUser)]
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

    /// <summary>
    /// Method shows UI to edit category
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
    /// Method updates category
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
    /// Method shows UI to delete category
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
    /// Method shows UI to read category details
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
