using ASPNetCoreMVC.Data;
using ASPNetCoreMVC.Models;
using ASPNetCoreMVC.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMVC.Areas.Customer.Controllers
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
    public HomeController(ILogger<HomeController> logger,
      ApplicationDbContext db)
    {
      _logger = logger;
      _db = db;
    }

    /// <summary>
    /// Method displays index Customer UI
    /// </summary>
    /// <returns></returns>
    public async Task<IActionResult> Index()
    {
      var IndexVM = new IndexViewModel()
      {
        MenuItems = await _db.MenuItems
          .Include(m => m.Category)
          .Include(m => m.SubCategory)
          .ToListAsync(),
        Categories = await _db.Categories.ToListAsync(),
        Coupons = await _db.Coupons
          .Where(c => c.isActive == true)
          .ToListAsync()
      };
      return View(IndexVM);
    }

    public IActionResult Privacy()
    {
      return View();
    }

    /// <summary>
    /// Method displays shopping cart details UI
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [Authorize]
    public async Task<IActionResult> Details(int id)
    {
      var menuItemFromDb = await _db.MenuItems
        .Include(m => m.Category)
        .Include(m => m.SubCategory)
        .Where(m => m.Id == id)
        .FirstOrDefaultAsync();

      ShoppingCart cartObj = new ShoppingCart()
      {
        MenuItem = menuItemFromDb,
        MenuItemId = menuItemFromDb.Id
      };

      return View(cartObj);
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
