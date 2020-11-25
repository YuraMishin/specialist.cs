using System.Collections.Generic;
using MVC.Models;

namespace MVC.ViewModels
{
  /// <summary>
  /// Class implements SubCategory And Category ViewModel
  /// </summary>
  public class SubCategoryAndCategoryViewModel
  {
    /// <summary>
    /// CategoryList
    /// </summary>
    public IEnumerable<Category> CategoryList { get; set; }

    /// <summary>
    /// SubCategory
    /// </summary>
    public SubCategory SubCategory { get; set; }

    /// <summary>
    /// SubCategoryList
    /// </summary>
    public List<string> SubCategoryList { get; set; }

    /// <summary>
    /// StatusMessage
    /// </summary>
    public string StatusMessage { get; set; }
  }
}
