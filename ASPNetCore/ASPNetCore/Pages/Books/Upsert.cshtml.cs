using ASPNetCore.Models;
using ASPNetCore.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ASPNetCore.Pages.Books
{
  /// <summary>
  /// Class implements the feature to either insert or update a book
  /// </summary>
  public class UpsertModel : PageModel
  {
    /// <summary>
    /// DB context
    /// </summary>
    private readonly AppDbContext _db;

    /// <summary>
    /// Book
    /// </summary>
    [BindProperty]
    public Book Book { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="db"></param>
    public UpsertModel(AppDbContext db)
    {
      _db = db;
    }

    /// <summary>
    /// Method invokes upon request GET: /Upsert/
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IActionResult> OnGet(int? id)
    {
      Book = new Book();
      if (id == null)
      {
        // Create a book UI
        return Page();
      }

      // Update the book UI
      Book = await _db.Book.FirstOrDefaultAsync(book => book.Id == id);
      if (Book == null)
      {
        return NotFound();
      }

      return Page();
    }
    /// <summary>
    /// Method invokes upon request POST: /Upsert
    /// </summary>
    /// <returns></returns>
    public async Task<IActionResult> OnPost()
    {
      if (ModelState.IsValid)
      {
        if (Book.Id == 0)
        {
          _db.Book.Add(Book);
        }
        else
        {
          _db.Book.Update(Book);
        }

        await _db.SaveChangesAsync();
        return RedirectToPage("Index");
      }

      return RedirectToPage();
    }
  }
}
