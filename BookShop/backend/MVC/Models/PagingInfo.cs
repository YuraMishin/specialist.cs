using System;

namespace MVC.Models
{
  /// <summary>
  /// Class PagingInfo.
  /// Implements paging info to create pagination
  /// </summary>
  public class PagingInfo
  {
    /// <summary>
    /// Total item
    /// </summary>
    public int TotalItem { get; set; }

    /// <summary>
    /// Items per page
    /// </summary>
    public int ItemsPerPage { get; set; }

    /// <summary>
    /// Current page
    /// </summary>
    public int CurrentPage { get; set; }

    /// <summary>
    /// Total page
    /// </summary>
    public int totalPage =>
      (int) Math.Ceiling((decimal) TotalItem / ItemsPerPage);

    /// <summary>
    /// Url param
    /// </summary>
    public string urlParam { get; set; }
  }
}
