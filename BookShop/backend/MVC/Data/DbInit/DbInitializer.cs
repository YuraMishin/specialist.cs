using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVC.Models;
using MVC.Utility;

namespace MVC.Data.DbInit
{
  /// <summary>
  /// Class DbInitializer.
  /// Implements IDbInitializer
  /// </summary>
  public class DbInitializer : IDbInitializer
  {
    /// <summary>
    /// Logger
    /// </summary>
    private readonly ILogger<DbInitializer> _logger;

    /// <summary>
    /// Db context
    /// </summary>
    private readonly ApplicationDbContext _db;

    /// <summary>
    /// UserManager
    /// </summary>
    private readonly UserManager<IdentityUser> _userManager;

    /// <summary>
    /// RoleManager
    /// </summary>
    private readonly RoleManager<IdentityRole> _roleManager;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="db">ApplicationDbContext</param>
    /// <param name="userManager">UserManager</param>
    /// <param name="roleManager">RoleManager</param>
    /// <param name="logger">ILogger</param>
    public DbInitializer(
      ApplicationDbContext db,
      UserManager<IdentityUser> userManager,
      RoleManager<IdentityRole> roleManager,
      ILogger<DbInitializer> logger)
    {
      _db = db;
      _roleManager = roleManager;
      _logger = logger;
      _userManager = userManager;
    }

    /// <summary>
    /// Method initializes database
    /// </summary>
    public async void Initialize()
    {
      try
      {
        if (_db.Database.GetPendingMigrations().Any())
        {
          _db.Database.Migrate();
        }
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Apply migrations fails!");
      }

      if (_db.Roles.Any(r => r.Name == SD.ManagerUser)) return;

      // Seed AspNetRoles Table
      _roleManager.CreateAsync(new IdentityRole(SD.ManagerUser)).GetAwaiter()
        .GetResult();
      _roleManager.CreateAsync(new IdentityRole(SD.FrontDeskUser)).GetAwaiter()
        .GetResult();
      _roleManager.CreateAsync(new IdentityRole(SD.CustomerEndUser))
        .GetAwaiter().GetResult();

      // Seed AspNetUsers Table
      _userManager.CreateAsync(new ApplicationUser
        {
          UserName = "admin@mail.ru",
          Email = "admin@mail.ru",
          Name = "Admin Yura",
          EmailConfirmed = true,
          PhoneNumber = "1112223333"
        }, "Aa-111")
        .GetAwaiter()
        .GetResult();

      _userManager.CreateAsync(new ApplicationUser
        {
          UserName = "user@mail.ru",
          Email = "user@mail.ru",
          Name = "User Yura",
          EmailConfirmed = true,
          PhoneNumber = "1112223333"
        }, "Aa-111")
        .GetAwaiter()
        .GetResult();

      // Seed AspNetUserRoles Table
      IdentityUser user =
        await _db.Users.FirstOrDefaultAsync(u => u.Email == "admin@mail.ru");
      await _userManager.AddToRoleAsync(user, SD.ManagerUser);

      user =
        await _db.Users.FirstOrDefaultAsync(u => u.Email == "user@mail.ru");
      await _userManager.AddToRoleAsync(user, SD.CustomerEndUser);
    }
  }
}
