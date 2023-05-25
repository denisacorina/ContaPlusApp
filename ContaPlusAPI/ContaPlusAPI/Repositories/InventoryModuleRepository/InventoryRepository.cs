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

        public async Task<ICollection<Product>> GetProductsByCompanyId(Guid companyId)
        {
            var products = await _context.Products
                .Where(i => i.Company.CompanyId == companyId)
                .ToListAsync();

            return products;
        }

        public async Task<Product> GetProductByIdForCompany(int productId, Guid companyId)
        {
            var product = await _context.Products
                .Where(i => i.Company.CompanyId == companyId)
                .FirstOrDefaultAsync(p => p.ProductId == productId);

            return product;
        }

        public async Task<Product> GetProductByNameForCompany(string productName, Guid companyId)
        {
            var products = await GetProductsByCompanyId(companyId);
            var product = products.FirstOrDefault(p => p.ProductName == productName);

            return product;
        }

        public async Task AddProductForCompany(Product product, Guid companyId)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(i => i.CompanyId == companyId);

            if (company != null)
            {
                company.Products.Add(product);

                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateProductForCompany(Product product, Guid companyId)
        {
            var existingProduct = await _context.Products.Where(i => i.Company.CompanyId == companyId)
                .FirstOrDefaultAsync(p => p.ProductId == product.ProductId);

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

        public async Task UpdateProductQuantity(Product product, Guid companyId)
        {
            var company = await _context.Companies.Include(i => i.Products)
                                                     .FirstOrDefaultAsync(i => i.CompanyId == companyId);

            if (company != null)
            {
                var existingProduct = company.Products.FirstOrDefault(p => p.ProductId == product.ProductId);

                if (existingProduct != null)
                {
                    existingProduct.Quantity = product.Quantity;
                }
                else
                {
                    company.Products.Add(product);
                }

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Inventory not found for the specified company.");
            }
        }

        public async Task DeleteProductForCompany(int productId, Guid companyId)
        {
            var company = await _context.Companies
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.CompanyId == companyId);

            if (company != null)
            {
                var existingProduct = company.Products.FirstOrDefault(p => p.ProductId == productId);

                if (existingProduct != null)
                {
                    company.Products.Remove(existingProduct);
                    _context.Products.Remove(existingProduct);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
