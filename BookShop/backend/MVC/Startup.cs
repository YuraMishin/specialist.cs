using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MVC.Data;
using MVC.Data.DbInit;
using MVC.Data.Repositories;
using MVC.Services;
using MVC.Services.Email;
using MVC.Utility;
using Stripe;

namespace MVC
{
  /// <summary>
  /// Class Startup
  /// </summary>
  public class Startup
  {
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="configuration">IConfiguration</param>
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    /// <summary>
    /// Configuration
    /// </summary>
    public IConfiguration Configuration { get; }

    /// <summary>
    /// Method gets called by the runtime to add services to the container
    /// </summary>
    /// <param name="services">IServiceCollection</param>
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

      //DB Seed
      services.AddScoped<IDbInitializer, DbInitializer>();

      // Identity
      services.AddIdentity<IdentityUser, IdentityRole>()
        .AddDefaultTokenProviders()
        .AddDefaultUI()
        .AddEntityFrameworkStores<ApplicationDbContext>();

      // Stripe
      services.Configure<StripeSettings>(Configuration.GetSection("Stripe"));

      //Mailtrap DI
      services.AddSingleton<IEmailSender, EmailSender>();
      services.Configure<EmailOptions>(Configuration.GetSection("Mailtrap"));

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

    /// <summary>
    /// Method gets called by the runtime to configure the HTTP request pipeline
    /// </summary>
    /// <param name="app">IApplicationBuilder</param>
    /// <param name="env">IWebHostEnvironment</param>
    /// <param name="dbInitializer">IDbInitializer</param>
    /// <param name="logger">ILogger</param>
    public void Configure(
      IApplicationBuilder app,
      IWebHostEnvironment env,
      IDbInitializer dbInitializer,
      ILogger<Startup> logger
    )
    {
      logger.LogInformation("BookShop is running");

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
      // Db Seed
      dbInitializer.Initialize();

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

      // User's middleware
      app.UseMiddleware<LoggingMiddleware>();

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
