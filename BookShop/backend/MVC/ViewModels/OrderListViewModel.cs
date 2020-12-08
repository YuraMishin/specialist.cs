using System.Collections.Generic;
using MVC.Models;

namespace MVC.ViewModels
{
  /// <summary>
  /// Class OrderListViewModel.
  /// Implements Order List ViewModel
  /// </summary>
  public class OrderListViewModel
  {
    /// <summary>
    /// Orders
    /// </summary>
    public IList<OrderDetailsViewModel> Orders { get; set; }

    /// <summary>
    /// Paging info
    /// </summary>
    public PagingInfo PagingInfo { get; set; }
  }
}
