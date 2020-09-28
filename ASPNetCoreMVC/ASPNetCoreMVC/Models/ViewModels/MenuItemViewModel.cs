using System.Collections.Generic;

namespace ASPNetCoreMVC.Models.ViewModels
{
  /// <summary>
  /// Class implements MenuItem ViewModel
  /// </summary>
  public class MenuItemViewModel
  {
    /// <summary>
    /// MenuItem
    /// </summary>
    public MenuItem MenuItem { get; set; }

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
