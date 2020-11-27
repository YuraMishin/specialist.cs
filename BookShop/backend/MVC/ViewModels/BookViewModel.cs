using System.Collections.Generic;
using MVC.Models;

namespace MVC.ViewModels
{
  /// <summary>
  /// Class implements Book ViewModel
  /// </summary>
  public class BookViewModel
  {
    /// <summary>
    /// Book
    /// </summary>
    public Book Book { get; set; }

    /// <summary>
    /// Categories
    /// </summary>
    public IEnumerable<Category> Categories { get; set; }

    /// <summary>
    /// SubCategories
    /// </summary>
    public IEnumerable<SubCategory> SubCategories { get; set; }
  }
}
