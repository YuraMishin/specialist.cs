using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVC.Data;
using MVC.Models;
using MVC.Utility;
using MVC.ViewModels;

namespace MVC.Areas.Customer.Controllers
{
  /// <summary>
  /// Class implements Customer controller
  /// </summary>
  [Area("Customer")]
  public class HomeController : Controller
  {
    /// <summary>
    /// Logger
    /// </summary>
    private readonly ILogger<HomeController> _logger;

    /// <summary>
    /// Db Context
    /// </summary>
    private readonly ApplicationDbContext _db;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="logger">ILogger</param>
    /// <param name="db">DbContext</param>
    public HomeController(ILogger<HomeController> logger,
      ApplicationDbContext db)
    {
      _logger = logger;
      _db = db;
    }

    /// <summary>
    /// Method displays index Customer UI.
    /// GET: /customer/home/
    /// </summary>
    /// <returns>IActionResult</returns>
    public async Task<IActionResult> Index()
    {
      var IndexVM = new IndexViewModel()
      {
        Books = await _db.Books
          .Include(m => m.Category)
          .Include(m => m.SubCategory)
          .ToListAsync(),
        Categories = await _db.Categories.ToListAsync(),
        Coupons = await _db.Coupons
          .Where(c => c.IsActive == true)
          .ToListAsync()
      };

      var claimsIdentity = (ClaimsIdentity) User.Identity;
      var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

      if (claim != null)
      {
        var cnt = _db.ShoppingCarts
          .Where(u => u.ApplicationUserId == claim.Value)
          .ToList()
          .Count;
        HttpContext.Session.SetInt32(SD.ssShoppingCartCount, cnt);
      }

      return View(IndexVM);
    }

    /// <summary>
    /// Method displays Book Details UI.
    /// GET: /customer/home/details/id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [Authorize]
    public async Task<IActionResult> Details(int id)
    {
      var bookFromDb = await _db.Books
        .Include(m => m.Category)
        .Include(m => m.SubCategory)
        .Where(m => m.Id == id)
        .FirstOrDefaultAsync();

      ShoppingCart cartObj = new ShoppingCart()
      {
        Book = bookFromDb,
        BookId = bookFromDb.Id
      };

      return View(cartObj);
    }

    /// <summary>
    /// Method add book to shopping cart.
    /// POST: /customer/home/details/id
    /// </summary>
    /// <param name="CartObject">CartObject</param>
    /// <returns>IActionResult</returns>
    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Details(ShoppingCart CartObject)
    {
      CartObject.Id = 0;
      if (ModelState.IsValid)
      {
        var claimsIdentity = (ClaimsIdentity) this.User.Identity;
        var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        CartObject.ApplicationUserId = claim.Value;

        ShoppingCart cartFromDb = await _db.ShoppingCarts
          .Where(c => c.ApplicationUserId == CartObject.ApplicationUserId
                      && c.BookId == CartObject.BookId)
          .FirstOrDefaultAsync();

        if (cartFromDb == null)
        {
          await _db.ShoppingCarts.AddAsync(CartObject);
        }
        else
        {
          cartFromDb.Count = cartFromDb.Count + CartObject.Count;
        }

        await _db.SaveChangesAsync();

        var count = _db.ShoppingCarts
          .Where(c => c.ApplicationUserId == CartObject.ApplicationUserId)
          .ToList()
          .Count();
        HttpContext.Session.SetInt32(SD.ssShoppingCartCount, count);

        return RedirectToAction("Index");
      }
      else
      {
        var bookItemFromDb = await _db.Books
          .Include(m => m.Category)
          .Include(m => m.SubCategory)
          .Where(m => m.Id == CartObject.BookId)
          .FirstOrDefaultAsync();

        ShoppingCart cartObj = new ShoppingCart()
        {
          Book = bookItemFromDb,
          BookId = bookItemFromDb.Id
        };

        return View(cartObj);
      }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None,
      NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel
        {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
  }
}
