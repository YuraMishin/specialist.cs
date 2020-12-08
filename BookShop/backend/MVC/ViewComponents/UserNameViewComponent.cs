using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Data;

namespace MVC.ViewComponents
{
  /// <summary>
  /// Class UserNameViewComponent.
  /// Implements UserName View Component
  /// </summary>
  public class UserNameViewComponent : ViewComponent
  {
    /// <summary>
    /// Db Context
    /// </summary>
    private readonly ApplicationDbContext _db;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="db">ApplicationDbContext</param>
    public UserNameViewComponent(ApplicationDbContext db)
    {
      _db = db;
    }

    /// <summary>
    /// Method renders UI
    /// </summary>
    /// <returns></returns>
    public async Task<IViewComponentResult> InvokeAsync()
    {
      var claimsIdentity = (ClaimsIdentity) User.Identity;
      var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

      var userFromDb =
        await _db.ApplicationUser.FirstOrDefaultAsync(u =>
          u.Id == claims.Value);

      return View(userFromDb);
    }
  }
}
