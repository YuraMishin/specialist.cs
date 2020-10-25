using EFCore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EFCore
{
  public class Startup
  {
    public Startup(IConfiguration config) => Configuration = config;

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();
      services.AddMvc(
        mvcOptions => mvcOptions.EnableEndpointRouting = false
      );

      string conString = Configuration["ConnectionStrings:DefaultConnection"];
      services.AddDbContext<DataContext>(options =>
      {
        options.EnableSensitiveDataLogging(true);
        options.UseSqlServer(conString);
      });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseDeveloperExceptionPage();
      app.UseStatusCodePages();
      app.UseStaticFiles();
      app.UseMvcWithDefaultRoute();
    }
  }
}
