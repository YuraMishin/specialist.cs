using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;
using MVC.ViewModels;

namespace MVC.Areas.Admin.Controllers
{
  /// <summary>
  /// Class implements Book Controller
  /// </summary>
  [Area("Admin")]
  public class BookController : Controller
  {
    /// <summary>
    /// DbContext
    /// </summary>
    private readonly ApplicationDbContext _db;

    /// <summary>
    /// Book View Model
    /// </summary>
    [BindProperty]
    public BookViewModel BookVM { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="db">Db Context</param>
    public BookController(ApplicationDbContext db)
    {
      _db = db;

      BookVM = new BookViewModel()
      {
        Categories = _db.Categories,
        Book = new Book()
      };
    }

    /// <summary>
    /// Method retrieves all subcategories.
    /// GET: /admin/book/
    /// </summary>
    /// <returns>IActionResult</returns>
    public async Task<IActionResult> Index()
    {
      var books = await _db.Books
        .Include(m => m.Category)
        .Include(m => m.SubCategory)
        .ToListAsync();

      return View(books);
    }

    /// <summary>
    /// Method shows create book UI.
    /// GET: /admin/book/create
    /// </summary>
    /// <returns>IActionResult</returns>
    public IActionResult Create()
    {
      return View(BookVM);
    }
  }
}
