using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;

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

    /// <summary>
    /// Method shows UI to create a coupon.
    /// GET: /admin/coupon/create
    /// </summary>
    /// <returns>IActionResult</returns>
    public IActionResult Create()
    {
      return View();
    }

    /// <summary>
    /// Method creates a coupon.
    /// POST: /admin/coupon/create
    /// </summary>
    /// <param name="coupon">Coupon</param>
    /// <returns>IActionResult</returns>
    [HttpPost, ActionName("Create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreatePost(Coupon coupon)
    {
      if (ModelState.IsValid)
      {
        // image save
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
    /// Method shows UI to edit coupon.
    /// GET: /admin/coupon/edit/id
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
  }
}
