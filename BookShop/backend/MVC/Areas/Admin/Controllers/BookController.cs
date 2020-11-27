﻿using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;
using MVC.Utility;
using MVC.ViewModels;

namespace MVC.Areas.Admin.Controllers
{
  /// <summary>
  /// Class implements Book Controller
  /// </summary>
  [Area("Admin")]
  public class BookController : Controller
  {
    /// <summary>
    /// DbContext
    /// </summary>
    private readonly ApplicationDbContext _db;

    /// <summary>
    /// IWebHostEnvironment
    /// </summary>
    private readonly IWebHostEnvironment _hostingEnvironment;

    /// <summary>
    /// Book View Model
    /// </summary>
    [BindProperty]
    public BookViewModel BookVM { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="db">Db Context</param>
    /// <param name="hostingEnvironment">IWebHostEnvironment</param>
    public BookController(
      ApplicationDbContext db,
      IWebHostEnvironment hostingEnvironment
    )
    {
      _db = db;
      _hostingEnvironment = hostingEnvironment;

      BookVM = new BookViewModel()
      {
        Categories = _db.Categories,
        Book = new Book()
      };

      _hostingEnvironment = hostingEnvironment;
    }

    /// <summary>
    /// Method retrieves all subcategories.
    /// GET: /admin/book/
    /// </summary>
    /// <returns>IActionResult</returns>
    public async Task<IActionResult> Index()
    {
      var books = await _db.Books
        .Include(m => m.Category)
        .Include(m => m.SubCategory)
        .ToListAsync();

      return View(books);
    }

    /// <summary>
    /// Method shows create book UI.
    /// GET: /admin/book/create
    /// </summary>
    /// <returns>IActionResult</returns>
    public IActionResult Create()
    {
      return View(BookVM);
    }

    /// <summary>
    /// Method creates book.
    /// POST: /admin/book/create
    /// </summary>
    /// <returns>IActionResult</returns>
    [HttpPost, ActionName("Create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreatePOST()
    {
      BookVM.Book.SubCategoryId = Convert
        .ToInt32(Request.Form["SubCategoryId"]
          .ToString());

      if (!ModelState.IsValid)
      {
        BookVM.Categories = await _db.Categories.ToListAsync();
        return View(BookVM);
      }

      _db.Books.Add(BookVM.Book);
      await _db.SaveChangesAsync();

      // img saving
      var webRootPath = _hostingEnvironment.WebRootPath;
      var files = HttpContext.Request.Form.Files;
      var bookFromDb =
        await _db.Books.FindAsync(BookVM.Book.Id);
      if (files.Any())
      {
        var uploads = Path.Combine(webRootPath, "img");
        var extension = Path.GetExtension(files[0].FileName);
        using (var filesStream
          = new FileStream(
            Path.Combine(uploads, BookVM.Book.Id + extension),
            FileMode.Create))
        {
          files[0].CopyTo(filesStream);
        }

        bookFromDb.Image = @"\img\" + BookVM.Book.Id + extension;
      }
      else
      {
        var uploads = Path.Combine(webRootPath, @"img\" + SD.DefaultBookImage);
        System.IO.File.Copy(uploads,
          webRootPath + @"\img\" + BookVM.Book.Id + ".png");
        bookFromDb.Image = @"\img\" + BookVM.Book.Id + ".png";
      }

      await _db.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }
  }
}
