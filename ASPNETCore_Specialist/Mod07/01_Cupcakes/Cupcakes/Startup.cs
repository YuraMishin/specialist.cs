using Cupcakes.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cupcakes
{
  public class Startup
  {
    private IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<CupcakeContext>(options =>
        options.UseSqlite("Data Source=cupcake.db"));


      services.AddMvc();
    }

    public void Configure(IApplicationBuilder app, CupcakeContext cupcakeContext)
    {
      cupcakeContext.Database.EnsureDeleted();
      cupcakeContext.Database.EnsureCreated();

      app.UseStaticFiles();

      app.UseMvc(routes =>
      {
        routes.MapRoute(
          name: "CupcakeRoute",
          template: "{controller}/{action}/{id?}",
          defaults: new { controller = "Cupcake", action = "Index" },
          constraints: new { id = "[0-9]+" });
      });
    }
  }
}
