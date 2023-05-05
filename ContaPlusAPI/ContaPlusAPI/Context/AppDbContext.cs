using ContaPlusAPI.Models.AccountingModule;
using ContaPlusAPI.Models.CompanyModule;
using ContaPlusAPI.Models.UserModule;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ContaPlusAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<UserCompanyRole> UserCompanyRoles { get; set; }
        public DbSet<ChartOfAccounts> ChartOfAccounts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedRoles(modelBuilder);
            SeedChartOfAccountsData(modelBuilder);
        }

        private static void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "admin" },
                new Role { RoleId = 2, RoleName = "accountant" },
                new Role { RoleId = 3, RoleName = "manager" });
        }

        private static void SeedChartOfAccountsData(ModelBuilder modelBuilder)
        {
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null,
                MissingFieldFound = null
            };

            using var reader = new StreamReader(@"C:\Users\DENI\Desktop\PlanConturi.csv");
            using var csv = new CsvReader(reader, configuration);
            var records = csv.GetRecords<ChartOfAccounts>();

            foreach (var record in records)
            {
                var existingRecord = modelBuilder.Entity<ChartOfAccounts>().HasData(record);

                if (existingRecord == null)
                {
                    modelBuilder.Entity<ChartOfAccounts>().HasData(record);
                }
            }
        }
    }
}
