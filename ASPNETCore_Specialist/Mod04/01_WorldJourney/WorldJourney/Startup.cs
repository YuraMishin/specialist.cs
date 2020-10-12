using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using WorldJourney.Models;

namespace WorldJourney
{
  public class Startup
  {
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();
      services.AddSingleton<IData, Data>();
    }

    public void Configure(IApplicationBuilder app)
    {
      app.UseStaticFiles();
      app.UseMvcWithDefaultRoute();

      app.UseMvc(routes =>
      {
        routes.MapRoute(
          name: "TravelerRoute",
          template: "{controller}/{action}/{name}",
          constraints: new { name = "[A-Za-z ]+" },
          defaults: new
          { controller = "Traveler", action = "Index", name = "Katie Bruce" });

        routes.MapRoute(
          name: "defaultRoute",
          template: "{controller}/{action}/{id?}",
          defaults: new { controller = "Home", action = "Index" },
          constraints: new { id = "[0-9]+" });
      });
    }
  }
}
