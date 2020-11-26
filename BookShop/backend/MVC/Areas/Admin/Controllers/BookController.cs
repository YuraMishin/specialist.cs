using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Data;

namespace MVC.Areas.Admin.Controllers
{
  /// <summary>
  /// Class implements Book Controller
  /// </summary>
  public class BookController : Controller
  {
    /// <summary>
    /// DbContext
    /// </summary>
    private readonly ApplicationDbContext _db;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="db">Db Context</param>
    public BookController(ApplicationDbContext db)
    {
      _db = db;
    }

    /// <summary>
    /// Method retrieves all subcategories.
    /// GET: /admin/book/
    /// </summary>
    /// <returns>IActionResult</returns>
    [Area("Admin")]
    public async Task<IActionResult> Index()
    {
      var books = await _db.Books
        .Include(m => m.Category)
        .Include(m => m.SubCategory)
        .ToListAsync();

      return View(books);
    }
  }
}
