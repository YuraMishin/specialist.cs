using System.Collections.Generic;

namespace ASPNetCoreMVC.Models.ViewModels
{
  /// <summary>
  /// Class implements Index ViewModel
  /// </summary>
  public class IndexViewModel
  {
    /// <summary>
    /// Menu items
    /// </summary>
    public IEnumerable<MenuItem> MenuItems { get; set; }

    /// <summary>
    /// Categories
    /// </summary>
    public IEnumerable<Category> Categories { get; set; }

    /// <summary>
    /// Coupons
    /// </summary>
    public IEnumerable<Coupon> Coupons { get; set; }
  }
}
