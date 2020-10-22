using Microsoft.EntityFrameworkCore;

namespace EFCore.Models
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options)
      : base(options)
    {
    }

    public DbSet<GuestResponse> Responses { get; set; }
  }
}
