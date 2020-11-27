using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Data;

namespace MVC.Areas.Admin.Controllers
{
  /// <summary>
  /// Class implements Coupon Controller
  /// </summary>
  [Area("Admin")]
  public class CouponController : Controller
  {
    /// <summary>
    /// DbContext
    /// </summary>
    private readonly ApplicationDbContext _db;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="db"></param>
    public CouponController(ApplicationDbContext db)
    {
      _db = db;
    }

    /// <summary>
    /// Method shows UI to list all coupons.
    /// GET: /admin/coupon/
    /// </summary>
    /// <returns>IActionResult</returns>
    public async Task<IActionResult> Index()
    {
      var coupons = await _db.Coupons.ToListAsync();
      return View(coupons);
    }
  }
}
