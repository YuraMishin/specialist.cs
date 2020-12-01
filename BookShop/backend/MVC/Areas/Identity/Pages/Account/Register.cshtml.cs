using MVC.Models;
using MVC.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Areas.Identity.Pages.Account
{
  /// <summary>
  /// Class implements User Registration
  /// </summary>
  [AllowAnonymous]
  public class RegisterModel : PageModel
  {
    /// <summary>
    /// SignInManager
    /// </summary>
    private readonly SignInManager<IdentityUser> _signInManager;

    /// <summary>
    /// UserManager
    /// </summary>
    private readonly UserManager<IdentityUser> _userManager;

    /// <summary>
    /// ILogger
    /// </summary>
    private readonly ILogger<RegisterModel> _logger;

    /// <summary>
    /// IEmailSender
    /// </summary>
    private readonly IEmailSender _emailSender;

    /// <summary>
    /// RoleManager
    /// </summary>
    private readonly RoleManager<IdentityRole> _roleManager;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="userManager"></param>
    /// <param name="signInManager"></param>
    /// <param name="logger"></param>
    /// <param name="emailSender"></param>
    /// <param name="roleManager">RoleManager</param>
    public RegisterModel(
      UserManager<IdentityUser> userManager,
      SignInManager<IdentityUser> signInManager,
      ILogger<RegisterModel> logger,
      IEmailSender emailSender,
      RoleManager<IdentityRole> roleManager)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _logger = logger;
      _emailSender = emailSender;
      _roleManager = roleManager;
    }

    [BindProperty] public InputModel Input { get; set; }

    public string ReturnUrl { get; set; }

    public IList<AuthenticationScheme> ExternalLogins { get; set; }

    /// <summary>
    /// Class implements InputModel
    /// </summary>
    public class InputModel
    {
      /// <summary>
      /// Email
      /// </summary>
      [Required]
      [EmailAddress]
      [Display(Name = "Email")]
      public string Email { get; set; }

      /// <summary>
      /// Password
      /// </summary>
      [Required]
      [StringLength(100,
        ErrorMessage =
          "The {0} must be at least {2} and at max {1} characters long.",
        MinimumLength = 6)]
      [DataType(DataType.Password)]
      [Display(Name = "Password")]
      public string Password { get; set; }

      /// <summary>
      /// ConfirmPassword
      /// </summary>
      [DataType(DataType.Password)]
      [Display(Name = "Confirm password")]
      [Compare("Password",
        ErrorMessage = "The password and confirmation password do not match.")]
      public string ConfirmPassword { get; set; }

      /// <summary>
      /// Name
      /// </summary>
      [Required]
      public string Name { get; set; }

      /// <summary>
      /// Street address
      /// </summary>
      [Display(Name = "Street Address")]
      public string StreetAddress { get; set; }

      /// <summary>
      /// Phone number
      /// </summary>
      [Display(Name = "Phone Number")]
      public string PhoneNumber { get; set; }

      /// <summary>
      /// City
      /// </summary>
      public string City { get; set; }

      /// <summary>
      /// State
      /// </summary>
      public string State { get; set; }

      /// <summary>
      /// Postal code
      /// </summary>
      [Display(Name = "Postal Code")]
      public string PostalCode { get; set; }
    }

    /// <summary>
    /// Method displays UI to register.
    /// GET: /Identity/Account/Register
    /// </summary>
    /// <param name="returnUrl">returnUrl</param>
    /// <returns>Task</returns>
    public async Task OnGetAsync(string returnUrl = null)
    {
      ReturnUrl = returnUrl;
      ExternalLogins =
        (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
    }

    /// <summary>
    /// Method register a new user.
    /// </summary>
    /// <param name="returnUrl"></param>
    /// <returns>IActionResult</returns>
    public async Task<IActionResult> OnPostAsync(string returnUrl = null)
    {
      string role = Request.Form["rdUserRole"].ToString();

      returnUrl = returnUrl ?? Url.Content("~/");
      ExternalLogins =
        (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

      if (ModelState.IsValid)
      {
        var user = new ApplicationUser
        {
          UserName = Input.Email,
          Email = Input.Email,
          Name = Input.Name,
          City = Input.City,
          StreetAddress = Input.StreetAddress,
          State = Input.State,
          PostalCode = Input.PostalCode,
          PhoneNumber = Input.PhoneNumber
        };

        var result = await _userManager.CreateAsync(user, Input.Password);

        if (result.Succeeded)
        {
          // create roles
          if (!await _roleManager.RoleExistsAsync(SD.ManagerUser))
          {
            await _roleManager.CreateAsync(new IdentityRole(SD.ManagerUser));
          }

          if (!await _roleManager.RoleExistsAsync(SD.CustomerEndUser))
          {
            await _roleManager.CreateAsync(
              new IdentityRole(SD.CustomerEndUser));
          }

          if (!await _roleManager.RoleExistsAsync(SD.FrontDeskUser))
          {
            await _roleManager.CreateAsync(new IdentityRole(SD.FrontDeskUser));
          }
          //

          else
          {
            if (role == SD.FrontDeskUser)
            {
              await _userManager.AddToRoleAsync(user, SD.FrontDeskUser);
            }
            else
            {
              if (role == SD.ManagerUser)
              {
                await _userManager.AddToRoleAsync(user, SD.ManagerUser);
              }
              else
              {
                await _userManager.AddToRoleAsync(user, SD.CustomerEndUser);
                await _signInManager.SignInAsync(user, isPersistent: false);
                return LocalRedirect(returnUrl);
              }
            }
          }

          return RedirectToAction("Login", "Account", new {area = "Identity"});
        }

        foreach (var error in result.Errors)
        {
          ModelState.AddModelError(string.Empty, error.Description);
        }
      }

      // If we got this far, something failed, redisplay form
      return Page();
    }
  }
}
