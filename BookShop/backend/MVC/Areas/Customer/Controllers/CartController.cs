using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Data;
using MVC.Utility;
using MVC.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MVC.Areas.Customer.Controllers
{
  /// <summary>
  /// Class implements Cart controller
  /// </summary>
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

      return View(OrderDetailsCartVM);
    }
  }
}
