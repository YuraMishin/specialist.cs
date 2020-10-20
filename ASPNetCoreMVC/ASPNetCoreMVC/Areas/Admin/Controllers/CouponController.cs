using ASPNetCoreMVC.Data;
using ASPNetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ASPNetCoreMVC.Utility;
using Microsoft.AspNetCore.Authorization;

namespace ASPNetCoreMVC.Areas.Admin.Controllers
{
  /// <summary>
  /// Class implements Coupon controller
  /// </summary>
  [Area("Admin")]
  [Authorize(Roles = SD.ManagerUser)]
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

    /// <summary>
    /// Method shows UI to edit coupon
    /// </summary>
    /// <param name="id">id</param>
    /// <returns>IActionResult</returns>
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var coupon = await _db.Coupons.SingleOrDefaultAsync(m => m.Id == id);
      if (coupon == null)
      {
        return NotFound();
      }

      return View(coupon);
    }

    /// <summary>
    /// Method updates coupon
    /// </summary>
    /// <param name="coupon">Coupon</param>
    /// <returns>IActionResult</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Coupon coupon)
    {
      if (coupon.Id == 0)
      {
        return NotFound();
      }

      var couponFromDb = await _db.Coupons
        .Where(c => c.Id == coupon.Id)
        .FirstOrDefaultAsync();

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

          couponFromDb.Picture = p1;
        }

        couponFromDb.MinimumAmount = coupon.MinimumAmount;
        couponFromDb.Name = coupon.Name;
        couponFromDb.Discount = coupon.Discount;
        couponFromDb.CouponType = coupon.CouponType;
        couponFromDb.isActive = coupon.isActive;
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }

      return View(coupon);
    }

    /// <summary>
    /// Method displays UI to view coupon details
    /// </summary>
    /// <param name="id">id</param>
    /// <returns>IActionResult</returns>
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var coupon = await _db.Coupons
        .FirstOrDefaultAsync(m => m.Id == id);
      if (coupon == null)
      {
        return NotFound();
      }

      return View(coupon);
    }

    /// <summary>
    /// Method shows UI to delete coupon
    /// </summary>
    /// <param name="id">id</param>
    /// <returns>IActionResult</returns>
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var coupon = await _db.Coupons.SingleOrDefaultAsync(m => m.Id == id);
      if (coupon == null)
      {
        return NotFound();
      }

      return View(coupon);
    }

    /// <summary>
    /// Method removes coupon
    /// </summary>
    /// <param name="id">id</param>
    /// <returns>IActionResult</returns>
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeletePost(int id)
    {
      var coupons = await _db.Coupons.SingleOrDefaultAsync(m => m.Id == id);
      _db.Coupons.Remove(coupons);
      await _db.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }
  }
}
