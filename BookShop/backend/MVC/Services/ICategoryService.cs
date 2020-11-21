using System.Collections.Generic;
using System.Threading.Tasks;
using MVC.Models;

namespace MVC.Services
{
  /// <summary>
  /// Interface ICategoryService.
  /// Declares Category Service contracts
  /// </summary>
  public interface ICategoryService
  {
    /// <summary>
    /// Method retrieves all categories
    /// </summary>
    /// <returns>IEnumerable&lt;Category&gt;</returns>
    Task<IEnumerable<Category>> RetrieveAllCategories();
  }
}
