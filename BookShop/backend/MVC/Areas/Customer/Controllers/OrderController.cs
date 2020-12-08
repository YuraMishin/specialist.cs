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
    /// Page size for pagination
    /// </summary>
    private int PageSize = 10;

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
    /// GET: /customer/order/orderhistory/productPage
    /// </summary>
    /// <param name="productPage">Product page</param>
    /// <returns>IActionResult</returns>
    [Authorize]
    public async Task<IActionResult> OrderHistory(int productPage=1)
    {
      var claimsIdentity = (ClaimsIdentity) User.Identity;
      var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

      OrderListViewModel orderListVM = new OrderListViewModel()
      {
        Orders = new List<OrderDetailsViewModel>()
      };

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
        orderListVM.Orders.Add(individual);
      }

      var count = orderListVM.Orders.Count;
      orderListVM.Orders = orderListVM.Orders.OrderByDescending(p => p.OrderHeader.Id)
        .Skip((productPage - 1) * PageSize)
        .Take(PageSize).ToList();

      orderListVM.PagingInfo = new PagingInfo
      {
        CurrentPage = productPage,
        ItemsPerPage = PageSize,
        TotalItem = count,
        urlParam = "/Customer/Order/OrderHistory?productPage=:"
      };

      return View(orderListVM);
    }

    /// <summary>
    /// Method displays get order details UI.
    /// GET: /customer/order/getorderdetails/id
    /// </summary>
    /// <param name="Id">Id</param>
    /// <returns></returns>
    public async Task<IActionResult> GetOrderDetails(int Id)
    {
      OrderDetailsViewModel orderDetailsViewModel = new OrderDetailsViewModel()
      {
        OrderHeader =
          await _db.OrderHeaders.FirstOrDefaultAsync(m => m.Id == Id),
        OrderDetails = await _db.OrderDetails
          .Where(m => m.OrderId == Id)
          .ToListAsync()
      };
      orderDetailsViewModel.OrderHeader.ApplicationUser =
        await _db.ApplicationUser.FirstOrDefaultAsync(u =>
          u.Id == orderDetailsViewModel.OrderHeader.UserId);

      return PartialView("_IndividualOrderDetails", orderDetailsViewModel);
    }

    /// <summary>
    /// Method redirects to the main page.
    /// GET: /customer/order/create/
    /// </summary>
    /// <returns>ActionResult</returns>
    public ActionResult Create()
    {
      return RedirectToAction("Index", "Home");
    }

    /// <summary>
    /// Method retrieves order status.
    /// GET: /customer/order/getorderstatus/id
    /// </summary>
    /// <param name="Id">Id</param>
    /// <returns></returns>
    public IActionResult GetOrderStatus(int Id)
    {
      return PartialView("_OrderStatus", _db.OrderHeaders.Where(m => m.Id == Id).FirstOrDefault().Status);

    }
  }
}
