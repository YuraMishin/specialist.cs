using ASPNetCore.Models;
using ASPNetCore.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASPNetCore.Pages.Books
{
  /// <summary>
  /// Class implements Books UI
  /// </summary>
  public class IndexModel : PageModel
  {
    /// <summary>
    /// Database context
    /// </summary>
    private readonly AppDbContext _db;

    /// <summary>
    /// Books storage
    /// </summary>
    public IEnumerable<Book> Books { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="db"></param>
    public IndexModel(AppDbContext db)
    {
      _db = db;
    }

    /// <summary>
    /// Method invokes on request GET: /Books/
    /// </summary>
    /// <returns></returns>
    public async Task OnGet()
    {
      Books = await _db.Book.ToListAsync();
    }
    /// <summary>
    /// Method invokes on request POST: /Books/
    /// </summary>
    /// <param name="id">Book Id</param>
    /// <returns>IActionResult</returns>
    public async Task<IActionResult> OnPostDelete(int id)
    {
      var book = await _db.Book.FindAsync(id);
      if (book == null)
      {
        return NotFound();
      }

      _db.Book.Remove(book);
      await _db.SaveChangesAsync();

      return RedirectToPage("Index");
    }
  }
}
