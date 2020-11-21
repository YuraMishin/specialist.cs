using System.Collections.Generic;
using System.Threading.Tasks;
using MVC.Models;

namespace MVC.Data.Repositories
{
  /// <summary>
  /// Interface ICategoryRepository.
  /// Declares Category contracts
  /// </summary>
  public interface ICategoryRepository
  {
    /// <summary>
    /// Method retrieves all categories
    /// </summary>
    /// <returns>IEnumerable&lt;Category&gt;</returns>
    Task<IEnumerable<Category>> RetrieveAllCategories();
  }
}
