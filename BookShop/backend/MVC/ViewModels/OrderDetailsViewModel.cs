using System.Collections.Generic;
using MVC.Models;

namespace MVC.ViewModels
{
  /// <summary>
  /// Class implements OrderDetails ViewModel
  /// </summary>
  public class OrderDetailsViewModel
  {
    /// <summary>
    /// OrderHeader
    /// </summary>
    public OrderHeader OrderHeader { get; set; }

    /// <summary>
    /// OrderDetails
    /// </summary>
    public List<OrderDetails> OrderDetails { get; set; }
  }
}
