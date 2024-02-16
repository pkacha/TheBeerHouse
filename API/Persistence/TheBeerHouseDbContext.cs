using System.Reflection;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Persistence
{
    public class TheBeerHouseDbContext : DbContext
    {
        public TheBeerHouseDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}