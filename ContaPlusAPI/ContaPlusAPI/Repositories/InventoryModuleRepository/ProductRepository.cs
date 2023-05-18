using ContaPlusAPI.Context;
using ContaPlusAPI.Interfaces.IRepository.InventoryRepositoryInterface;
using ContaPlusAPI.Models.InventoryModule;
using Microsoft.EntityFrameworkCore;

namespace ContaPlusAPI.Repositories.InventoryModuleRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Product>> GetProductsByCompanyId(Guid companyId)
        {
            var products = await _context.Products
                .Include(p => p.Inventory)
                .Where(p => p.Inventory.Company.CompanyId == companyId)
                .ToListAsync();

            return products;
        }

        public async Task<Product> GetProductByIdForCompany(int productId, Guid companyId)
        {
            var product = await _context.Products
                .Include(p => p.Inventory)
                .FirstOrDefaultAsync(p => p.ProductId == productId && p.Inventory.Company.CompanyId == companyId);

            return product;
        }

        public async Task AddProductForCompany(Product product, Guid companyId)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(c => c.CompanyId == companyId);
            var inventory = await _context.Inventory.FirstOrDefaultAsync(i => i.Company.CompanyId == companyId);

            if (company != null && inventory != null)
            {
                product.Inventory = inventory;
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateProductForCompany(Product product, Guid companyId)
        {
            var existingProduct = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == product.ProductId && p.Inventory.Company.CompanyId == companyId);

            if (existingProduct != null)
            {
                if (existingProduct.ProductName != product.ProductName)
                    existingProduct.ProductName = product.ProductName;

                if (existingProduct.Description != product.Description)
                    existingProduct.Description = product.Description;

                if (existingProduct.Price != product.Price)
                    existingProduct.Price = product.Price;

                if (existingProduct.Quantity != product.Quantity)
                    existingProduct.Quantity = product.Quantity;

                if (existingProduct.UpdatedAt != product.UpdatedAt)
                    existingProduct.UpdatedAt = product.UpdatedAt;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteProductForCompany(int productId, Guid companyId)
        {
            var existingProduct = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == productId && p.Inventory.Company.CompanyId == companyId);

            if (existingProduct != null)
            {
                _context.Products.Remove(existingProduct);
                await _context.SaveChangesAsync();
            }
        }
    }
}
