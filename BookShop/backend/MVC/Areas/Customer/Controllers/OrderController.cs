using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;
using MVC.ViewModels;

namespace MVC.Areas.Customer.Controllers
{
  /// <summary>
  /// Class implements Order controller
  /// </summary>
  [Area("Customer")]
  public class OrderController : Controller
  {
    /// <summary>
    /// Db Context
    /// </summary>
    private ApplicationDbContext _db;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="db">DbContext</param>
    public OrderController(ApplicationDbContext db)
    {
      _db = db;
    }

    /// <summary>
    /// Method displays order confirm UI.
    /// GET: /customer/confirm/id
    /// </summary>
    /// <param name="id">Id</param>
    /// <returns>IActionResult</returns>
    [Authorize]
    public async Task<IActionResult> Confirm(int id)
    {
      var claimsIdentity = (ClaimsIdentity) User.Identity;
      var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

      OrderDetailsViewModel orderDetailsViewModel = new OrderDetailsViewModel()
      {
        OrderHeader = await _db.OrderHeaders
          .Include(o => o.ApplicationUser)
          .FirstOrDefaultAsync(o => o.Id == id && o.UserId == claim.Value),
        OrderDetails = await _db.OrderDetails
          .Where(o => o.OrderId == id)
          .ToListAsync()
      };

      return View(orderDetailsViewModel);
    }

    /// <summary>
    /// Method displays order history UI.
    /// GET: /customer/order/orderhistory
    /// </summary>
    /// <returns>IActionResult</returns>
    [Authorize]
    public async Task<IActionResult> OrderHistory()
    {
      var claimsIdentity = (ClaimsIdentity) User.Identity;
      var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

      List<OrderDetailsViewModel> orderList = new List<OrderDetailsViewModel>();

      List<OrderHeader> OrderHeaderList = await _db.OrderHeaders
        .Include(o => o.ApplicationUser)
        .Where(u => u.UserId == claim.Value)
        .ToListAsync();

      foreach (OrderHeader item in OrderHeaderList)
      {
        OrderDetailsViewModel individual = new OrderDetailsViewModel
        {
          OrderHeader = item,
          OrderDetails = await _db.OrderDetails
            .Where(o => o.OrderId == item.Id)
            .ToListAsync()
        };
        orderList.Add(individual);
      }

      return View(orderList);
    }
  }
}
