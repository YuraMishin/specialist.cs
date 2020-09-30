using ASPNetCoreMVC.Data;
using ASPNetCoreMVC.Models;
using ASPNetCoreMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMVC.Areas.Admin.Controllers
{
  /// <summary>
  /// Class implements SubCategory Controller
  /// </summary>
  [Area("Admin")]
  public class SubCategoryController : Controller
  {
    /// <summary>
    /// DbContext
    /// </summary>
    private readonly ApplicationDbContext _db;

    /// <summary>
    /// Status message
    /// </summary>
    [TempData]
    public string StatusMessage { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="_db">Db Context</param>
    public SubCategoryController(ApplicationDbContext _db)
    {
      this._db = _db;
    }

    /// <summary>
    /// Method gets all subcategories
    /// </summary>
    /// <returns></returns>
    public async Task<IActionResult> Index()
    {
      var subCategories = await _db.SubCategories
        .Include(s => s.Category)
        .ToListAsync();
      return View(subCategories);
    }

    /// <summary>
    /// Method displays Create SubCategory UI
    /// </summary>
    /// <returns></returns>
    public async Task<IActionResult> Create()
    {
      var model = new SubCategoryAndCategoryViewModel
      {
        CategoryList = await _db.Categories.ToListAsync(),
        SubCategory = new SubCategory(),
        SubCategoryList = await _db.SubCategories
          .OrderBy(p => p.Name)
          .Select(p => p.Name)
          .Distinct()
          .ToListAsync()
      };

      return View(model);
    }

    /// <summary>
    /// Method creates Subcategory
    /// </summary>
    /// <param name="model">Model</param>
    /// <returns>IActionResult</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Store(
      SubCategoryAndCategoryViewModel model)
    {
      if (ModelState.IsValid)
      {
        var doesSCExists = _db.SubCategories.Include(s => s.Category)
          .Where(s =>
            s.Name == model.SubCategory.Name &&
            s.Category.Id == model.SubCategory.CategoryId);
        if (doesSCExists.Any())
        {
          var categoryName = doesSCExists.First().Category.Name;
          StatusMessage =
            String.Format(
              $"Error: Sub Category exists under {categoryName} category. Please use another name.");
        }
        else
        {
          _db.SubCategories.Add(model.SubCategory);
          await _db.SaveChangesAsync();
          return RedirectToAction(nameof(Index));
        }
      }

      var modelVM = new SubCategoryAndCategoryViewModel()
      {
        CategoryList = await _db.Categories.ToListAsync(),
        SubCategory = model.SubCategory,
        SubCategoryList = await _db.SubCategories.OrderBy(p => p.Name)
          .Select(p => p.Name)
          .ToListAsync(),
        StatusMessage = StatusMessage
      };
      return View("Create", modelVM);
    }

    /// <summary>
    /// Method retrieves sub categories
    /// </summary>
    /// <param name="id">Category Id</param>
    /// <returns>JSON</returns>
    [ActionName("GetSubCategory")]
    public async Task<IActionResult> GetSubCategory(int id)
    {
      var subCategories = new List<SubCategory>();
      subCategories = await (from subCategory in _db.SubCategories
                             where subCategory.CategoryId == id
                             select subCategory).ToListAsync();
      return Json(new SelectList(subCategories, "Id", "Name"));
    }

    /// <summary>
    /// Method displays Edit subcategory UI
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var subCategory =
        await _db.SubCategories.SingleOrDefaultAsync(m => m.Id == id);
      if (subCategory == null)
      {
        return NotFound();
      }

      var model = new SubCategoryAndCategoryViewModel
      {
        CategoryList = await _db.Categories.ToListAsync(),
        SubCategory = subCategory,
        SubCategoryList = await _db.SubCategories
          .OrderBy(p => p.Name)
          .Select(p => p.Name)
          .Distinct()
          .ToListAsync()
      };

      return View(model);
    }

    /// <summary>
    /// Method edits subcategory
    /// </summary>
    /// <param name="model">SubCategoryAndCategoryViewModel</param>
    /// <returns>IActionResult</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(SubCategoryAndCategoryViewModel model)
    {
      if (ModelState.IsValid)
      {
        var doesSCExists = _db.SubCategories.Include(s => s.Category)
          .Where(s =>
            s.Name == model.SubCategory.Name &&
            s.Category.Id == model.SubCategory.CategoryId);
        if (doesSCExists.Any())
        {
          var categoryName = doesSCExists.First().Category.Name;
          StatusMessage =
            String.Format(
              $"Error: Sub Category exists under {categoryName} category. Please use another name.");
        }
        else
        {
          var subCatFromDb =
            await _db.SubCategories.FindAsync(model.SubCategory.Id);
          subCatFromDb.Name = model.SubCategory.Name;
          await _db.SaveChangesAsync();
          return RedirectToAction(nameof(Index));
        }
      }

      var modelVM = new SubCategoryAndCategoryViewModel()
      {
        CategoryList = await _db.Categories.ToListAsync(),
        SubCategory = model.SubCategory,
        SubCategoryList = await _db.SubCategories.OrderBy(p => p.Name)
          .Select(p => p.Name)
          .ToListAsync(),
        StatusMessage = StatusMessage
      };
      return View("Edit", modelVM);
    }

    /// <summary>
    /// Method displays subcategory details UI 
    /// </summary>
    /// <param name="id">Id</param>
    /// <returns>IActionResult</returns>
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var subCategory = await _db.SubCategories
        .Include(s => s.Category)
        .SingleOrDefaultAsync(m => m.Id == id);
      if (subCategory == null)
      {
        return NotFound();
      }

      return View(subCategory);
    }

    /// <summary>
    /// Method displays subcategory delete UI
    /// </summary>
    /// <param name="id">Id</param>
    /// <returns>IActionResult</returns>
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var subCategory = await _db.SubCategories.Include(s => s.Category)
        .SingleOrDefaultAsync(m => m.Id == id);
      if (subCategory == null)
      {
        return NotFound();
      }

      return View(subCategory);
    }

    /// <summary>
    /// Method deletes subcategory
    /// </summary>
    /// <param name="id">Id</param>
    /// <returns>IActionResult</returns>
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var subCategory = await _db.SubCategories
        .SingleOrDefaultAsync(m => m.Id == id);
      _db.SubCategories.Remove(subCategory);
      await _db.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }
  }
}