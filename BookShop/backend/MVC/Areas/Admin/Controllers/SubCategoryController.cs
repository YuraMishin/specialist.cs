using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Data;

namespace MVC.Areas.Admin.Controllers
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
    /// Constructor
    /// </summary>
    /// <param name="db">DbContext</param>
    public SubCategoryController(ApplicationDbContext db)
    {
      _db = db;
    }

    /// <summary>
    /// Method retrieves all subcategories.
    /// GET: /admin/subcategory/
    /// </summary>
    /// <returns>IActionResult</returns>
    public async Task<IActionResult> Index()
    {
      var subCategories = await _db.SubCategories
        .Include(s => s.Category)
        .ToListAsync();

      return View(subCategories);
    }
  }
}
