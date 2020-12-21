using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace MVC
{
  /// <summary>
  /// Class Program
  /// </summary>
  public class Program
  {
    /// <summary>
    /// The entry point to the app
    /// </summary>
    /// <param name="args">Args</param>
    public static void Main(string[] args)
    {
      CreateHostBuilder(args).Build().Run();
    }

    /// <summary>
    /// Method setups server
    /// </summary>
    /// <param name="args">Args</param>
    /// <returns>IHostBuilder</returns>
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
              webBuilder.UseStartup<Startup>();
            });
  }
}
