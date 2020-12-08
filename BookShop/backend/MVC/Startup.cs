using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using MVC.Data;
using MVC.Data.Repositories;
using MVC.Services;
using MVC.Utility;
using Stripe;

namespace MVC
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      // DB connection
      services.AddDbContext<ApplicationDbContext>(
        option =>
        {
          option.EnableDetailedErrors();
          option.UseNpgsql(
            Configuration.GetConnectionString("bookshop.dev"));
        });

      // Identity
      services.AddIdentity<IdentityUser, IdentityRole>()
        .AddDefaultTokenProviders()
        .AddDefaultUI()
        .AddEntityFrameworkStores<ApplicationDbContext>();

      // Stripe
      services.Configure<StripeSettings>(Configuration.GetSection("Stripe"));

      //Facebook
      services.AddAuthentication().AddFacebook(facebookOptions =>
      {
        facebookOptions.AppId = "add";
        facebookOptions.AppSecret = "add";
      });

      //Google
      services.AddAuthentication().AddGoogle(googleOptions =>
      {
        googleOptions.ClientId = "add";
        googleOptions.ClientSecret = "add";
      });

      // add sessions
      services.AddSession(options =>
      {
        options.Cookie.IsEssential = true;
        options.IdleTimeout = TimeSpan.FromMinutes(30);
        options.Cookie.HttpOnly = true;
      });

      #region Dependency Injections

      services.AddScoped<ICategoryRepository, CategoryRepository>();
      services.AddScoped<ICategoryService, CategoryService>();

      #endregion


      services.AddControllersWithViews();
      services.AddRazorPages().AddRazorRuntimeCompilation();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseDatabaseErrorPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      // Stripe
      StripeConfiguration.SetApiKey(
        Configuration.GetSection("Stripe")["SecretKey"]);

      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseCookiePolicy();

      // add support folder node_modules
      app.UseStaticFiles(new StaticFileOptions()
      {
        FileProvider = new PhysicalFileProvider(
          Path.Combine(Directory.GetCurrentDirectory(), @"node_modules")),
        RequestPath = new PathString("/node_modules")
      });

      app.UseRouting();

      app.UseAuthentication();

      app.UseSession();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
          name: "default",
          pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");
        endpoints.MapRazorPages();
      });
    }
  }
}
