using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;
using MVC.Utility;
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
    public async Task<IActionResult> OrderHistory(int productPage = 1)
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
      orderListVM.Orders = orderListVM.Orders
        .OrderByDescending(p => p.OrderHeader.Id)
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
    /// <param name="id">Id</param>
    /// <returns></returns>
    public IActionResult GetOrderStatus(int id)
    {
      var data = _db.OrderHeaders
        .Where(m => m.Id == id).FirstOrDefault()
        .Status;

      return PartialView("_OrderStatus", data);
    }

    /// <summary>
    /// Method displays manage order UI.
    /// GET: /customer/order/manageorder/id
    /// </summary>
    /// <param name="productPage"></param>
    /// <returns>IActionResult</returns>
    [Authorize(Roles = SD.FrontDeskUser + "," + SD.ManagerUser)]
    public async Task<IActionResult> ManageOrder(int productPage = 1)
    {
      List<OrderDetailsViewModel> orderDetailsVM =
        new List<OrderDetailsViewModel>();

      List<OrderHeader> OrderHeaderList = await _db.OrderHeaders
        .Where(o =>
          o.Status == SD.StatusSubmitted || o.Status == SD.StatusInProcess)
        .OrderByDescending(u => u.PickUpTime).ToListAsync();

      foreach (OrderHeader item in OrderHeaderList)
      {
        OrderDetailsViewModel individual = new OrderDetailsViewModel
        {
          OrderHeader = item,
          OrderDetails = await _db.OrderDetails.Where(o => o.OrderId == item.Id)
            .ToListAsync()
        };
        orderDetailsVM.Add(individual);
      }

      return View(
        orderDetailsVM.OrderBy(o => o.OrderHeader.PickUpTime).ToList());
    }

    /// <summary>
    /// Method implements order prepare status feature.
    /// GET: /customer/order/orderprepare/orderid
    /// </summary>
    /// <param name="OrderId">Order Id</param>
    /// <returns>IActionResult</returns>
    [Authorize(Roles = SD.FrontDeskUser + "," + SD.ManagerUser)]
    public async Task<IActionResult> OrderPrepare(int OrderId)
    {
      OrderHeader orderHeader = await _db.OrderHeaders.FindAsync(OrderId);
      orderHeader.Status = SD.StatusInProcess;
      await _db.SaveChangesAsync();
      return RedirectToAction("ManageOrder", "Order");
    }

    /// <summary>
    /// Method implements order ready status feature.
    /// GET: /customer/order/orderready/orderid
    /// </summary>
    /// <param name="OrderId"></param>
    /// <returns>IActionResult</returns>
    [Authorize(Roles = SD.FrontDeskUser + "," + SD.ManagerUser)]
    public async Task<IActionResult> OrderReady(int OrderId)
    {
      OrderHeader orderHeader = await _db.OrderHeaders.FindAsync(OrderId);
      orderHeader.Status = SD.StatusReady;
      await _db.SaveChangesAsync();
      return RedirectToAction("ManageOrder", "Order");
    }

    /// <summary>
    /// Method implements order cancel status feature.
    /// GET: /customer/order/ordercamcel/orderid
    /// </summary>
    /// <param name="OrderId">OrderId</param>
    /// <returns>IActionResult</returns>
    [Authorize(Roles = SD.FrontDeskUser + "," + SD.ManagerUser)]
    public async Task<IActionResult> OrderCancel(int OrderId)
    {
      OrderHeader orderHeader = await _db.OrderHeaders.FindAsync(OrderId);
      orderHeader.Status = SD.StatusCancelled;
      await _db.SaveChangesAsync();
      return RedirectToAction("ManageOrder", "Order");
    }

    /// <summary>
    /// Method displays order pickup UI.
    /// GET: /customer/order/orderpickup/productPage
    /// </summary>
    /// <param name="productPage">Product page</param>
    /// <param name="searchEmail">Search email</param>
    /// <param name="searchPhone">Search phone</param>
    /// <param name="searchName">Search name</param>
    /// <returns>IActionResult</returns>
    [Authorize]
    public async Task<IActionResult> OrderPickup(
      int productPage = 1,
      string searchEmail = null,
      string searchPhone = null,
      string searchName = null
    )
    {
      OrderListViewModel orderListVM = new OrderListViewModel()
      {
        Orders = new List<OrderDetailsViewModel>()
      };

      StringBuilder param = new StringBuilder();
      param.Append("/Customer/Order/OrderPickup?productPage=:");
      param.Append("&searchName=");
      if (searchName != null)
      {
        param.Append(searchName);
      }

      param.Append("&searchEmail=");
      if (searchEmail != null)
      {
        param.Append(searchEmail);
      }

      param.Append("&searchPhone=");
      if (searchPhone != null)
      {
        param.Append(searchPhone);
      }

      List<OrderHeader> OrderHeaderList = new List<OrderHeader>();
      if (searchName != null || searchEmail != null || searchPhone != null)
      {
        var user = new ApplicationUser();

        if (searchName != null)
        {
          OrderHeaderList = await _db.OrderHeaders
            .Include(o => o.ApplicationUser)
            .Where(u => u.PickupName.ToLower().Contains(searchName.ToLower()))
            .OrderByDescending(o => o.OrderDate)
            .ToListAsync();
        }
        else
        {
          if (searchEmail != null)
          {
            user = await _db.ApplicationUser
              .Where(u => u.Email.ToLower().Contains(searchEmail.ToLower()))
              .FirstOrDefaultAsync();
            OrderHeaderList = await _db.OrderHeaders
              .Include(o => o.ApplicationUser)
              .Where(o => o.UserId == user.Id)
              .OrderByDescending(o => o.OrderDate)
              .ToListAsync();
          }
          else
          {
            if (searchPhone != null)
            {
              OrderHeaderList = await _db.OrderHeaders
                .Include(o => o.ApplicationUser)
                .Where(u => u.PhoneNumber.Contains(searchPhone))
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
            }
          }
        }
      }
      else
      {
        OrderHeaderList = await _db.OrderHeaders
          .Include(o => o.ApplicationUser)
          .Where(u => u.Status == SD.StatusReady)
          .ToListAsync();
      }

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
      orderListVM.Orders = orderListVM.Orders
        .OrderByDescending(p => p.OrderHeader.Id)
        .Skip((productPage - 1) * PageSize)
        .Take(PageSize).ToList();

      orderListVM.PagingInfo = new PagingInfo
      {
        CurrentPage = productPage,
        ItemsPerPage = PageSize,
        TotalItem = count,
        urlParam = param.ToString()
      };

      return View(orderListVM);
    }

    [Authorize(Roles = SD.FrontDeskUser + "," + SD.ManagerUser)]
    [HttpPost]
    [ActionName("OrderPickup")]
    public async Task<IActionResult> OrderPickupPost(int orderId)
    {
      OrderHeader orderHeader = await _db.OrderHeaders.FindAsync(orderId);
      orderHeader.Status = SD.StatusCompleted;
      await _db.SaveChangesAsync();
      return RedirectToAction("OrderPickup", "Order");
    }
  }
}
