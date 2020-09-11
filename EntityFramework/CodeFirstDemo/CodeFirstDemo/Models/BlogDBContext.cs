using System.Data.Entity;

namespace CodeFirstDemo.Models
{
    /// <summary>
    /// DB context
    /// </summary>
    public class BlogDBContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
    }
}