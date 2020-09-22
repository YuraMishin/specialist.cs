using ASPNetCore.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ASPNetCore.Controllers
{
  /// <summary>
  /// Class implements WebAPI
  /// </summary>
  [Route("api/Books")]
  [ApiController]
  public class BookController : Controller
  {
    /// <summary>
    /// DB context
    /// </summary>
    private readonly AppDbContext _db;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="db"></param>
    public BookController(AppDbContext db)
    {
      _db = db;
    }

    /// <summary>
    /// Method gets all the books
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      return Json(new
      {
        data = await _db.Book.ToListAsync()
      });
    }
  }
}
