using MVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MVC.Areas.Admin.Controllers
{
  /// <summary>
  /// Class implements UserController
  /// </summary>
  [Area("Admin")]
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
    /// Method displays UI to manage users accounts.
    /// GET: /admin/user/
    /// </summary>
    /// <returns>IActionResult</returns>
    public async Task<IActionResult> Index()
    {
      var claimsIdentity = (ClaimsIdentity)this.User.Identity;
      var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

      return View(await _db.ApplicationUser.Where(u => u.Id != claim.Value)
        .ToListAsync());
    }
  }
}
