using ASPNetCoreMVC.Data;
using ASPNetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;

namespace ASPNetCoreMVC.Areas.Admin.Controllers
{
  /// <summary>
  /// Class implements Coupon controller
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
    /// Method shows UI to list all coupons 
    /// </summary>
    /// <returns>IActionResult</returns>
    public async Task<IActionResult> Index()
    {
      var coupons = await _db.Coupons.ToListAsync();
      return View(coupons);
    }

    /// <summary>
    /// Method shows UI to create a coupon
    /// </summary>
    /// <returns>IActionResult</returns>
    public async Task<IActionResult> Create()
    {
      return View();
    }

    /// <summary>
    /// Method creates a coupon
    /// </summary>
    /// <param name="coupon">Coupon</param>
    /// <returns>IActionResult</returns>
    [HttpPost, ActionName("Create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreatePOST(Coupon coupon)
    {
      if (ModelState.IsValid)
      {
        var files = HttpContext.Request.Form.Files;
        if (files.Count > 0)
        {
          byte[] p1 = null;
          using (var fs1 = files[0].OpenReadStream())
          {
            using (var ms1 = new MemoryStream())
            {
              fs1.CopyTo(ms1);
              p1 = ms1.ToArray();
            }
          }

          coupon.Picture = p1;
        }

        _db.Coupons.Add(coupon);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }

      return View(coupon);
    }
  }
}
