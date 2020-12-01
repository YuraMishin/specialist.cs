﻿using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVC.Data;
using MVC.Models;
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
    public HomeController(ILogger<HomeController> logger,
      ApplicationDbContext db)
    {
      _logger = logger;
      _db = db;
    }

    /// <summary>
    /// Method displays index Customer UI.
    /// GET: /customer/
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

      return View(IndexVM);
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
