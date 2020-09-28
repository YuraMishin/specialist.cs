using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace ASPNetCoreMVC.Extensions
{
  public static class IEnumerableExtenson
  {
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
