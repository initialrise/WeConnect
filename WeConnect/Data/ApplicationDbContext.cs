using Microsoft.EntityFrameworkCore;
using WeConnect.Models;

namespace WeConnect.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<Posts> Posts { get; set; }
        public DbSet<Threads> Threads { get; set; }
    }
}
