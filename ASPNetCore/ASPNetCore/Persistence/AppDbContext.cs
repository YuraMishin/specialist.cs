using Microsoft.EntityFrameworkCore;

namespace ASPNetCore.Persistence
{
  public class AppDbContext : DbContext
  {
    // Domain Model
    //
    //

    public AppDbContext(DbContextOptions<AppDbContext> options)
      : base(options)
    {
    }
  }
}
