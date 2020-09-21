using ASPNetCore.Models;
using ASPNetCore.Persistence;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASPNetCore.Pages.Books
{
  public class IndexModel : PageModel
  {
    private readonly AppDbContext _db;
    public IEnumerable<Book> Books { get; set; }

    public IndexModel(AppDbContext db)
    {
      _db = db;
    }

    public async Task OnGet()
    {
      Books = await _db.Book.ToListAsync();
    }
  }
}
