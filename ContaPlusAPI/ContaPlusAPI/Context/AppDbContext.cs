using ContaPlusAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContaPlusAPI.Context
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CityCountyData> Cities_Counties { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedRoles(modelBuilder);
        }
        private void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "admin" },
                new Role { RoleId = 2, RoleName = "accountant" },
                new Role { RoleId = 3, RoleName = "manager" }
            );
        }

    }
}
