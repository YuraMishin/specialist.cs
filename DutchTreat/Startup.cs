using AutoMapper;
using DutchTreat.Data;
using DutchTreat.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using System.Text;
using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace DutchTreat
{
  public class Startup
  {
    private readonly IConfiguration _config;

    public Startup(IConfiguration config)
    {
      _config = config;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddIdentity<StoreUser, IdentityRole>(cfg =>
        {
          cfg.User.RequireUniqueEmail = true;
        })
        .AddEntityFrameworkStores<DutchContext>();

      services.AddAuthentication()
        .AddCookie()
        .AddJwtBearer(cfg =>
        {
          cfg.TokenValidationParameters = new TokenValidationParameters()
          {
            ValidIssuer = _config["Tokens:Issuer"],
            ValidAudience = _config["Tokens:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]))
          };

        });

      services.AddDbContext<DutchContext>(cfg =>
      {
        cfg.UseSqlServer(
          _config.GetConnectionString("DutchConnectionString"));
      });
      services.AddAutoMapper(Assembly.GetExecutingAssembly());

      services.AddTransient<DutchSeeder>();

      services.AddScoped<IDutchRepository, DutchRepository>();

      services.AddTransient<IMailService, NullMailService>();

      services.AddControllersWithViews();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseStaticFiles();
      app.UseNodeModules();

      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(cfg =>
      {
        cfg.MapControllerRoute("Default",
          "{controller}/{action}/{id?}",
          new {controller = "App", Action = "Index"});
      });
    }
  }
}
