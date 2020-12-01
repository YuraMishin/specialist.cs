using Microsoft.AspNetCore.Identity;

namespace MVC.Models
{
  /// <summary>
  /// Class extends IdentityUser class
  /// </summary>
  public class ApplicationUser : IdentityUser
  {
    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Street address
    /// </summary>
    public string StreetAddress { get; set; }

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
    public string PostalCode { get; set; }
  }
}
