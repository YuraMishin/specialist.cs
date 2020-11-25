using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace MVC.Extensions
{
  /// <summary>
  /// Class allows create customized SelectListItem
  /// </summary>
  public static class IEnumerableExtension
  {
    /// <summary>
    /// Method implements customized SelectListItem
    /// </summary>
    /// <param name="items">Items</param>
    /// <param name="selectedValue">SelectedValue</param>
    /// <typeparam name="T">T</typeparam>
    /// <returns>SelectListItem</returns>
    public static IEnumerable<SelectListItem> ToSelectListItem<T>(
      this IEnumerable<T> items, int selectedValue)
    {
      return from item in items
        select new SelectListItem
        {
          Text = item.GetPropertyValue("Name"),
          Value = item.GetPropertyValue("Id"),
          Selected = item.GetPropertyValue("Id")
            .Equals(selectedValue.ToString())
        };
    }
  }
}
