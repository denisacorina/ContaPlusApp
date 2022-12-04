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
  
    }
}
