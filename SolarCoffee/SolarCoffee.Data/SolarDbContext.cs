using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SolarCoffee.Data
{
  public class SolarDbContext : IdentityDbContext
  {
    public SolarDbContext()
    {
    }

    public SolarDbContext(DbContextOptions<SolarDbContext> options)
      : base(options)
    {
    }
  }
}
