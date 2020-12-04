using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Data;
using MVC.Utility;
using MVC.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

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
    /// Method increases count
    /// GET: /customer/cart/plus
    /// </summary>
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
    /// Method decreases count
    /// GET: /customer/cart/minus
    /// </summary>
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
  }
}
