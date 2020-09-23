using ASPNetCoreMVC.Data;
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
  }
}
