using System.Collections.Generic;
using MVC.Models;

namespace MVC.ViewModels
{
  /// <summary>
  /// Class implements Index ViewModel
  /// </summary>
  public class IndexViewModel
  {
    /// <summary>
    /// Books
    /// </summary>
    public IEnumerable<Book> Books { get; set; }

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
