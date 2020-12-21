using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MVC.Utility
{
  /// <summary>
  /// Class LoggingMiddleware
  /// Implements logging via middleware
  /// </summary>
  public class LoggingMiddleware
  {
    /// <summary>
    /// RequestDelegate
    /// </summary>
    private readonly RequestDelegate _next;

    /// <summary>
    /// ILogger
    /// </summary>
    private readonly ILogger _logger;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="next">RequestDelegate</param>
    /// <param name="loggerFactory">ILoggerFactory</param>
    public LoggingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
    {
      _next = next;
      _logger = loggerFactory.CreateLogger("Middleware Logger");
    }

    /// <summary>
    /// Method performs middleware action
    /// </summary>
    /// <param name="context">HttpContext</param>
    /// <returns>Task</returns>
    public async Task InvokeAsync(HttpContext context)
    {
      _logger.LogInformation($"Processing request: {context.Request.Path}");
      await _next.Invoke(context);
    }
  }
}
