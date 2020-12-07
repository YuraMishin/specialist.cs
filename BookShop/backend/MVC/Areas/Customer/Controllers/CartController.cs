using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Data;
using MVC.Utility;
using MVC.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MVC.Models;
using Stripe;

namespace MVC.Areas.Customer.Controllers
{
  /// <summary>
  /// Class implements Cart controller
  /// </summary>
  [Area("Customer")]
  public class CartController : Controller
  {
    /// <summary>
    /// Db Context
    /// </summary>
    private readonly ApplicationDbContext _db;

    /// <summary>
    /// OrderDetailsCart ViewModel
    /// </summary>
    [BindProperty]
    public OrderDetailsCartViewModel OrderDetailsCartVM { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="db">DbContext</param>
    public CartController(ApplicationDbContext db)
    {
      _db = db;
    }

    /// <summary>
    /// Method displays cart UI.
    /// GET: /customer/cart/
    /// </summary>
    /// <returns>IActionResult</returns>
    public async Task<IActionResult> Index()
    {
      OrderDetailsCartVM = new OrderDetailsCartViewModel()
      {
        OrderHeader = new Models.OrderHeader()
      };

      OrderDetailsCartVM.OrderHeader.OrderTotal = 0;

      var claimsIdentity = (ClaimsIdentity) User.Identity;
      var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

      var cart =
        _db.ShoppingCarts
          .Where(c => c.ApplicationUserId == claim.Value);

      if (cart != null)
      {
        OrderDetailsCartVM.ListCart = cart.ToList();
      }

      foreach (var list in OrderDetailsCartVM.ListCart)
      {
        list.Book =
          await _db.Books.FirstOrDefaultAsync(m => m.Id == list.BookId);
        OrderDetailsCartVM.OrderHeader.OrderTotal =
          OrderDetailsCartVM.OrderHeader.OrderTotal +
          (list.Book.Price * list.Count);

        list.Book.Description = SD.ConvertToRawHtml(list.Book.Description);

        if (list.Book.Description.Length > 100)
        {
          list.Book.Description =
            list.Book.Description.Substring(0, 99) + "...";
        }
      }

      OrderDetailsCartVM.OrderHeader.OrderTotalOriginal =
        OrderDetailsCartVM.OrderHeader.OrderTotal;

      if (HttpContext.Session.GetString(SD.ssCouponCode) != null)
      {
        OrderDetailsCartVM.OrderHeader.CouponCode =
          HttpContext.Session.GetString(SD.ssCouponCode);
        var couponFromDb = await _db.Coupons
          .Where(c =>
            c.Name.ToLower() ==
            OrderDetailsCartVM.OrderHeader.CouponCode.ToLower())
          .FirstOrDefaultAsync();
        OrderDetailsCartVM.OrderHeader.OrderTotal = SD.DiscountedPrice(
          couponFromDb, OrderDetailsCartVM.OrderHeader.OrderTotalOriginal);
      }

      return View(OrderDetailsCartVM);
    }

    /// <summary>
    /// Method adds coupon.
    /// GET: /customer/cart/addcoupon
    /// </summary>
    /// <returns>IActionResult</returns>
    public IActionResult AddCoupon()
    {
      if (OrderDetailsCartVM.OrderHeader.CouponCode == null)
      {
        OrderDetailsCartVM.OrderHeader.CouponCode = "";
      }

      HttpContext.Session.SetString(SD.ssCouponCode,
        OrderDetailsCartVM.OrderHeader.CouponCode);

      return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Method removes coupon.
    /// GET: /customer/cart/removecoupon
    /// </summary>
    /// <returns>IActionResult</returns>
    public IActionResult RemoveCoupon()
    {
      HttpContext.Session.SetString(SD.ssCouponCode, string.Empty);

      return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Method increases count.
    /// GET: /customer/cart/plus/cartId
    /// </summary>
    /// <param name="cartId">CartId</param>
    /// <returns>IActionResult</returns>
    public async Task<IActionResult> Plus(int cartId)
    {
      var cart =
        await _db.ShoppingCarts.FirstOrDefaultAsync(c => c.Id == cartId);
      cart.Count += 1;
      await _db.SaveChangesAsync();

      return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Method decreases count.
    /// GET: /customer/cart/minus/cartId
    /// </summary>
    /// <param name="cartId">CartId</param>
    /// <returns>IActionResult</returns>
    public async Task<IActionResult> Minus(int cartId)
    {
      var cart =
        await _db.ShoppingCarts.FirstOrDefaultAsync(c => c.Id == cartId);
      if (cart.Count == 1)
      {
        _db.ShoppingCarts.Remove(cart);
        await _db.SaveChangesAsync();

        var cnt = _db.ShoppingCarts
          .Where(u => u.ApplicationUserId == cart.ApplicationUserId)
          .ToList()
          .Count;
        HttpContext.Session.SetInt32(SD.ssShoppingCartCount, cnt);
      }
      else
      {
        cart.Count -= 1;
        await _db.SaveChangesAsync();
      }

      return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Method removes book from cart.
    /// GET: /customer/cart/remove/cartId
    /// </summary>
    /// <param name="cartId">CartId</param>
    /// <returns>IActionResult</returns>
    public async Task<IActionResult> Remove(int cartId)
    {
      var cart =
        await _db.ShoppingCarts.FirstOrDefaultAsync(c => c.Id == cartId);

      _db.ShoppingCarts.Remove(cart);
      await _db.SaveChangesAsync();

      var cnt = _db.ShoppingCarts
        .Where(u => u.ApplicationUserId == cart.ApplicationUserId)
        .ToList()
        .Count;
      HttpContext.Session.SetInt32(SD.ssShoppingCartCount, cnt);

      return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Method displays summary order UI.
    /// GET: /customer/cart/summary
    /// </summary>
    /// <returns>IActionResult</returns>
    public async Task<IActionResult> Summary()
    {
      OrderDetailsCartVM = new OrderDetailsCartViewModel()
      {
        OrderHeader = new Models.OrderHeader()
      };

      OrderDetailsCartVM.OrderHeader.OrderTotal = 0;

      var claimsIdentity = (ClaimsIdentity) User.Identity;
      var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
      ApplicationUser applicationUser = await _db.ApplicationUser
        .Where(c => c.Id == claim.Value).FirstOrDefaultAsync();
      var cart =
        _db.ShoppingCarts.Where(c => c.ApplicationUserId == claim.Value);
      if (cart != null)
      {
        OrderDetailsCartVM.ListCart = cart.ToList();
      }

      foreach (var list in OrderDetailsCartVM.ListCart)
      {
        list.Book =
          await _db.Books.FirstOrDefaultAsync(m => m.Id == list.BookId);
        OrderDetailsCartVM.OrderHeader.OrderTotal =
          OrderDetailsCartVM.OrderHeader.OrderTotal +
          (list.Book.Price * list.Count);
      }

      OrderDetailsCartVM.OrderHeader.OrderTotalOriginal =
        OrderDetailsCartVM.OrderHeader.OrderTotal;
      OrderDetailsCartVM.OrderHeader.PickupName = applicationUser.Name;
      OrderDetailsCartVM.OrderHeader.PhoneNumber = applicationUser.PhoneNumber;
      OrderDetailsCartVM.OrderHeader.PickUpTime = DateTime.Now;


      if (HttpContext.Session.GetString(SD.ssCouponCode) != null)
      {
        OrderDetailsCartVM.OrderHeader.CouponCode =
          HttpContext.Session.GetString(SD.ssCouponCode);
        var couponFromDb = await _db.Coupons
          .Where(c =>
            c.Name.ToLower() ==
            OrderDetailsCartVM.OrderHeader.CouponCode.ToLower())
          .FirstOrDefaultAsync();
        OrderDetailsCartVM.OrderHeader.OrderTotal = SD.DiscountedPrice(
          couponFromDb, OrderDetailsCartVM.OrderHeader.OrderTotalOriginal);
      }


      return View(OrderDetailsCartVM);
    }

    /// <summary>
    /// Method displays places order.
    /// POST: /customer/cart/summary
    /// </summary>
    /// <returns>IActionResult</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    [ActionName("Summary")]
    public async Task<IActionResult> SummaryPost(
      string stripeEmail,
      string stripeToken
    )
    {
      var claimsIdentity = (ClaimsIdentity) User.Identity;
      var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

      OrderDetailsCartVM.ListCart = await _db.ShoppingCarts
        .Where(c => c.ApplicationUserId == claim.Value).ToListAsync();

      OrderDetailsCartVM.OrderHeader.PaymentStatus = SD.PaymentStatusPending;
      OrderDetailsCartVM.OrderHeader.OrderDate = DateTime.Now;
      OrderDetailsCartVM.OrderHeader.UserId = claim.Value;
      OrderDetailsCartVM.OrderHeader.Status = SD.PaymentStatusPending;
      OrderDetailsCartVM.OrderHeader.PickUpTime = Convert.ToDateTime(
        OrderDetailsCartVM.OrderHeader.PickUpDate.ToShortDateString() + " " +
        OrderDetailsCartVM.OrderHeader.PickUpTime.ToShortTimeString());

      List<OrderDetails> orderDetailsList = new List<OrderDetails>();
      _db.OrderHeaders.Add(OrderDetailsCartVM.OrderHeader);
      await _db.SaveChangesAsync();

      OrderDetailsCartVM.OrderHeader.OrderTotalOriginal = 0;


      foreach (var item in OrderDetailsCartVM.ListCart)
      {
        item.Book =
          await _db.Books.FirstOrDefaultAsync(m => m.Id == item.BookId);
        OrderDetails orderDetails = new OrderDetails
        {
          BookId = item.BookId,
          OrderId = OrderDetailsCartVM.OrderHeader.Id,
          Description = item.Book.Description,
          Name = item.Book.Name,
          Price = item.Book.Price,
          Count = item.Count
        };
        OrderDetailsCartVM.OrderHeader.OrderTotalOriginal +=
          orderDetails.Count * orderDetails.Price;
        _db.OrderDetails.Add(orderDetails);
      }

      if (HttpContext.Session.GetString(SD.ssCouponCode) != null)
      {
        OrderDetailsCartVM.OrderHeader.CouponCode =
          HttpContext.Session.GetString(SD.ssCouponCode);
        var couponFromDb = await _db.Coupons
          .Where(c =>
            c.Name.ToLower() ==
            OrderDetailsCartVM.OrderHeader.CouponCode.ToLower())
          .FirstOrDefaultAsync();
        OrderDetailsCartVM.OrderHeader.OrderTotal = SD.DiscountedPrice(
          couponFromDb,
          OrderDetailsCartVM.OrderHeader.OrderTotalOriginal);
      }
      else
      {
        OrderDetailsCartVM.OrderHeader.OrderTotal =
          OrderDetailsCartVM.OrderHeader.OrderTotalOriginal;
      }

      OrderDetailsCartVM.OrderHeader.CouponCodeDiscount =
        OrderDetailsCartVM.OrderHeader.OrderTotalOriginal -
        OrderDetailsCartVM.OrderHeader.OrderTotal;

      _db.ShoppingCarts.RemoveRange(OrderDetailsCartVM.ListCart);
      HttpContext.Session.SetInt32(SD.ssShoppingCartCount, 0);
      await _db.SaveChangesAsync();

      //Stripe Logic
      if (stripeToken != null)
      {
        var customers = new CustomerService();
        var charges = new ChargeService();

        var customer = customers.Create(new CustomerCreateOptions
        {
          Email = stripeEmail,
          SourceToken = stripeToken
        });

        var charge = charges.Create(new ChargeCreateOptions
        {
          Amount =
            Convert.ToInt32(OrderDetailsCartVM.OrderHeader.OrderTotal * 100),
          Description = "Order ID : " + OrderDetailsCartVM.OrderHeader.Id,
          Currency = "usd",
          CustomerId = customer.Id
        });

        OrderDetailsCartVM.OrderHeader.TransactionId =
          charge.BalanceTransactionId;
        if (charge.Status.ToLower() == "succeeded")
        {
          //email for successful order

          OrderDetailsCartVM.OrderHeader.PaymentStatus =
            SD.PaymentStatusApproved;
          OrderDetailsCartVM.OrderHeader.Status = SD.StatusSubmitted;
        }
        else
        {
          OrderDetailsCartVM.OrderHeader.PaymentStatus =
            SD.PaymentStatusRejected;
        }
      }
      else
      {
        OrderDetailsCartVM.OrderHeader.PaymentStatus = SD.PaymentStatusRejected;
      }
      // /Stripe Logic

      await _db.SaveChangesAsync();

      return RedirectToAction("Index", "Home");
      // return RedirectToAction("Confirm", "Order", new
      // {
      //   id = OrderDetailsCartVM.OrderHeader.Id
      // });
    }
  }
}
