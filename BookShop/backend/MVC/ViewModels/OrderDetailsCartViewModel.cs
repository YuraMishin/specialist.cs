using System.Collections.Generic;
using MVC.Models;

namespace MVC.ViewModels
{
  /// <summary>
  /// Class implements OrderDetailsCart ViewModel
  /// </summary>
  public class OrderDetailsCartViewModel
  {
    /// <summary>
    /// ListCart
    /// </summary>
    public List<ShoppingCart> ListCart { get; set; }

    /// <summary>
    /// OrderHeader
    /// </summary>
    public OrderHeader OrderHeader { get; set; }
  }
}
