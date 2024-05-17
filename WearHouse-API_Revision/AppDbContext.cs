using Microsoft.EntityFrameworkCore;
using WearHouse_API_Revision.Models;

namespace WearHouse_API_Revision
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Category> Category { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
