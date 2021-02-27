using Microsoft.EntityFrameworkCore;
using EFCore.Models;
namespace EFCore.Data
{
    public class EFCoreContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=Blog.db");
    }
}
