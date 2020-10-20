using ASPNetCoreMVC.Data;
using ASPNetCoreMVC.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASPNetCoreMVC.Areas.Admin.Controllers
{
  /// <summary>
  /// Class implements UserController
  /// </summary>
  [Area("Admin")]
  [Authorize(Roles = SD.ManagerUser)]
  public class UserController : Controller
  {
    /// <summary>
    /// Db context
    /// </summary>
    private readonly ApplicationDbContext _db;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="db">Db context</param>
    public UserController(ApplicationDbContext db)
    {
      _db = db;
    }

    /// <summary>
    /// Method displays UI to manage users accounts
    /// </summary>
    /// <returns>IActionResult</returns>
    public async Task<IActionResult> Index()
    {
      var claimsIdentity = (ClaimsIdentity) this.User.Identity;
      var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

      return View(await _db.ApplicationUser.Where(u => u.Id != claim.Value)
        .ToListAsync());
    }

    /// <summary>
    /// Method locks user
    /// </summary>
    /// <param name="id">Id</param>
    /// <returns>IActionResult</returns>
    public async Task<IActionResult> Lock(string id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var applicationUser =
        await _db.ApplicationUser.FirstOrDefaultAsync(m => m.Id == id);

      if (applicationUser == null)
      {
        return NotFound();
      }

      applicationUser.LockoutEnd = DateTime.Now.AddYears(1000);

      await _db.SaveChangesAsync();

      return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Method unlock user
    /// </summary>
    /// <param name="id">Id</param>
    /// <returns>IActionResult</returns>
    public async Task<IActionResult> UnLock(string id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var applicationUser =
        await _db.ApplicationUser.FirstOrDefaultAsync(m => m.Id == id);

      if (applicationUser == null)
      {
        return NotFound();
      }

      applicationUser.LockoutEnd = DateTime.Now;

      await _db.SaveChangesAsync();

      return RedirectToAction(nameof(Index));
    }
  }
}
