using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreat.Data
{
  public class DutchSeeder
  {
    private readonly DutchContext _ctx;
    private readonly IWebHostEnvironment _hosting;
    private readonly UserManager<StoreUser> _userManager;

    public DutchSeeder(DutchContext ctx, IWebHostEnvironment hosting,
      UserManager<StoreUser> userManager)
    {
      _ctx = ctx;
      _hosting = hosting;
      _userManager = userManager;
    }

    public async Task SeedAsync()
    {
      _ctx.Database.EnsureCreated();

      // Seed the Main User
      StoreUser user = await _userManager.FindByEmailAsync("admin@mail.ru");
      if (user == null)
      {
        user = new StoreUser()
        {
          LastName = "Mishin",
          FirstName = "Yura",
          Email = "admin@mail.ru",
          UserName = "admin@mail.ru"
        };

        var result = await _userManager.CreateAsync(user, "Aa-111");
        if (result != IdentityResult.Success)
        {
          throw new InvalidOperationException("Could not create user in Seeding");
        }
      }

      if (!_ctx.Products.Any())
      {
        // Need to create sample data
        var filepath = Path.Combine(_hosting.ContentRootPath, "Data/art.json");
        var json = File.ReadAllText(filepath);
        var products =
          JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
        _ctx.Products.AddRange(products);

        var order = _ctx.Orders.Where(o => o.Id == 1).FirstOrDefault();
        if (order == null)
        {
          order = new Order()
          {
            User = user,
            OrderDate = DateTime.Now,
            OrderNumber = "12345",
            Items = new List<OrderItem>()
            {
              new OrderItem()
              {
                Product = products.First(),
                Quantity = 5,
                UnitPrice = products.First().Price
              }
            }
          };

          _ctx.Orders.Add(order);
        }

        _ctx.SaveChanges();
      }
    }
  }
}
