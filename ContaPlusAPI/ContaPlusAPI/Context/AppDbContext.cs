using ContaPlusAPI.Models;
using ContaPlusAPI.Models.AccountingModule;
using ContaPlusAPI.Models.CompanyModule;
using ContaPlusAPI.Models.InventoryModule;
using ContaPlusAPI.Models.UserModule;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace ContaPlusAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<UserCompanyRole> UserCompanyRoles { get; set; }
        public DbSet<GeneralChartOfAccounts> GeneralChartOfAccounts { get; set; }
        public DbSet<CompanyChartOfAccounts> CompanyChartOfAccounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSale> ProductSales { get; set; }
        public DbSet<ProductPurchase> ProductPurchases { get; set; }
        public DbSet<Document> Documents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedRoles(modelBuilder);
            SeedChartOfAccountsData(modelBuilder);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.DebitAccount)
                .WithMany()
                .HasForeignKey(t => t.DebitAccountCode)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.CreditAccount)
                .WithMany()
                .HasForeignKey(t => t.CreditAccountCode)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Transaction>()
                   .HasMany(t => t.Documents)
                   .WithOne(d => d.Transaction)
                   .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Transaction>()
                .HasMany(t => t.ProductSales)
                .WithOne(ps => ps.Transaction)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
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
            var records = csv.GetRecords<GeneralChartOfAccounts>();

            foreach (var record in records)
            {
                var existingRecord = modelBuilder.Entity<GeneralChartOfAccounts>().HasData(record);

                if (existingRecord == null)
                {
                    modelBuilder.Entity<GeneralChartOfAccounts>().HasData(record);
                }
            }
        }
    }
}
