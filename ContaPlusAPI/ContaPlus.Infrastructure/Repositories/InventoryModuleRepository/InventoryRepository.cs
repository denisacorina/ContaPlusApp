using ContaPlusAPI.Context;
using ContaPlusAPI.Interfaces.IRepository.InventoryRepositoryInterface;
using ContaPlusAPI.Interfaces.IService;
using ContaPlusAPI.Models.InventoryModule;
using Microsoft.EntityFrameworkCore;

namespace ContaPlusAPI.Repositories.InventoryRepository
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly AppDbContext _context;

        public InventoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Inventory> GetInventoryByCompanyId(Guid companyId)
        {
            var inventory = await _context.Inventory
                .Include(i => i.Product)
                .FirstOrDefaultAsync(i => i.Company.CompanyId == companyId);

            return inventory;
        }
        public async Task AddInventoryForCompany(Inventory inventory, Guid companyId)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(c => c.CompanyId == companyId);
            if (company != null)
            {
                inventory.Company = company;
                await _context.Inventory.AddAsync(inventory);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateInventoryForCompany(Inventory inventory, Guid companyId)
        {
            var existingInventory = await _context.Inventory.FirstOrDefaultAsync(i => i.Company.CompanyId == companyId);

            if (existingInventory != null)
            {
                existingInventory.UpdatedAt = inventory.UpdatedAt;

                await _context.SaveChangesAsync();
            }
        }
    }
}
