using ASPNetCoreMVC.Data;
using ASPNetCoreMVC.Models;
using ASPNetCoreMVC.Models.ViewModels;
using ASPNetCoreMVC.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMVC.Areas.Admin.Controllers
{
  /// <summary>
  /// Class implements MenuItem controller
  /// </summary>
  [Area("Admin")]
  public class MenuItemController : Controller
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
    /// MenuItem View Model
    /// </summary>
    [BindProperty]
    public MenuItemViewModel MenuItemVM { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="db">Db Context</param>
    /// <param name="hostingEnvironment">IWebHostEnvironment</param>
    public MenuItemController(
      ApplicationDbContext db, IWebHostEnvironment hostingEnvironment)
    {
      _db = db;
      _hostingEnvironment = hostingEnvironment;
      MenuItemVM = new MenuItemViewModel()
      {
        Categories = _db.Categories,
        MenuItem = new MenuItem()
      };
    }

    /// <summary>
    /// Method displays Menu items UI
    /// </summary>
    /// <returns></returns>
    public async Task<IActionResult> Index()
    {
      var menuItems = await _db.MenuItems
        .Include(m => m.Category)
        .Include(m => m.SubCategory)
        .ToListAsync();
      return View(menuItems);
    }

    /// <summary>
    /// Method shows create menu item UI
    /// </summary>
    /// <returns>IActionResult</returns>
    public async Task<IActionResult> Create()
    {
      return View(MenuItemVM);
    }

    /// <summary>
    /// Method creates menu item
    /// </summary>
    /// <returns>IActionResult</returns>
    [HttpPost, ActionName("Create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreatePOST()
    {
      MenuItemVM.MenuItem.SubCategoryId = Convert
        .ToInt32(Request.Form["SubCategoryId"].ToString());
      if (!ModelState.IsValid)
      {
        MenuItemVM.Categories = await _db.Categories.ToListAsync();
        return View(MenuItemVM);
      }

      _db.MenuItems.Add(MenuItemVM.MenuItem);
      await _db.SaveChangesAsync();
      // img saving
      var webRootPath = _hostingEnvironment.WebRootPath;
      var files = HttpContext.Request.Form.Files;
      var menuItenFromDb =
        await _db.MenuItems.FindAsync(MenuItemVM.MenuItem.Id);
      if (files.Count > 0)
      {
        var uploads = Path.Combine(webRootPath, "img");
        var extension = Path.GetExtension(files[0].FileName);
        using (var filesStream
          = new FileStream(
            Path.Combine(uploads, MenuItemVM.MenuItem.Id + extension),
            FileMode.Create))
        {
          files[0].CopyTo(filesStream);
        }

        menuItenFromDb.Image = @"\img\" + MenuItemVM.MenuItem.Id + extension;
      }
      else
      {
        var uploads = Path.Combine(webRootPath, @"img\" + SD.DefaultFoodImage);
        System.IO.File.Copy(uploads,
          webRootPath + @"\img\" + MenuItemVM.MenuItem.Id + ".png");
        menuItenFromDb.Image = @"\img\" + MenuItemVM.MenuItem.Id + ".png";
      }

      await _db.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// Method shows edit menu item UI
    /// </summary>
    /// <param name="id">Id</param>
    /// <returns>IActionResult</returns>
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      MenuItemVM.MenuItem = await _db.MenuItems
        .Include(m => m.Category)
        .Include(m => m.SubCategory)
        .SingleOrDefaultAsync(m => m.Id == id);
      MenuItemVM.SubCategories = await _db
        .SubCategories
        .Where(s => s.CategoryId == MenuItemVM.MenuItem.CategoryId)
        .ToListAsync();
      if (MenuItemVM.MenuItem == null)
      {
        return NotFound();
      }
      return View(MenuItemVM);
    }

    /// <summary>
    /// Method edits menu item
    /// </summary>
    /// <param name="id">id</param>
    /// <returns>IActionResult</returns>
    [HttpPost, ActionName("Edit")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditPOST(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      MenuItemVM.MenuItem.SubCategoryId = Convert
        .ToInt32(Request.Form["SubCategoryId"].ToString());
      if (!ModelState.IsValid)
      {
        MenuItemVM.Categories = await _db.Categories.ToListAsync();
        MenuItemVM.SubCategories = await _db.SubCategories
          .Where(s => s.CategoryId == MenuItemVM.MenuItem.CategoryId)
          .ToListAsync();
        return View(MenuItemVM);
      }
      // img saving
      var webRootPath = _hostingEnvironment.WebRootPath;
      var files = HttpContext.Request.Form.Files;
      var menuItenFromDb =
        await _db.MenuItems.FindAsync(MenuItemVM.MenuItem.Id);
      if (files.Count > 0)
      {
        var uploads = Path.Combine(webRootPath, "img");
        var extension_new = Path.GetExtension(files[0].FileName);
        var imagePath = Path.Combine(
          webRootPath,
          menuItenFromDb.Image.TrimStart('\\'));
        if (System.IO.File.Exists(imagePath))
        {
          System.IO.File.Delete(imagePath);
        }

        using (var filesStream
          = new FileStream(
            Path.Combine(uploads, MenuItemVM.MenuItem.Id + extension_new),
            FileMode.Create))
        {
          files[0].CopyTo(filesStream);
        }

        menuItenFromDb.Image = @"\img\" + MenuItemVM.MenuItem.Id + extension_new;
      }
      menuItenFromDb.Name = MenuItemVM.MenuItem.Name;
      menuItenFromDb.Description = MenuItemVM.MenuItem.Description;
      menuItenFromDb.Price = MenuItemVM.MenuItem.Price;
      menuItenFromDb.Spicyness = MenuItemVM.MenuItem.Spicyness;
      menuItenFromDb.CategoryId = MenuItemVM.MenuItem.CategoryId;
      menuItenFromDb.SubCategoryId = MenuItemVM.MenuItem.SubCategoryId;

      await _db.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }
  }
}
