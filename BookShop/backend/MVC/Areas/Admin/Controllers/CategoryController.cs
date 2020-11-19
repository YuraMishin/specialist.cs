using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVC.Controllers;
using MVC.Data;

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
    /// Constructor
    /// </summary>
    /// <param name="db">Db Context</param>
    public CategoryController(ApplicationDbContext db)
    {
      this._db = db;
    }

    /// <summary>
    /// Method retrieves all categories
    /// </summary>
    /// <returns>IActionResult</returns>
    public async Task<IActionResult> Index()
    {
      var categories = await _db.Categories.ToListAsync();

      return Json(categories);
    }
  }
}
