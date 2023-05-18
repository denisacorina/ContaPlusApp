using ContaPlusAPI.Interfaces.IRepository.InventoryRepositoryInterface;
using ContaPlusAPI.Interfaces.IService.InventoryServiceInterface;
using ContaPlusAPI.Models.InventoryModule;

namespace ContaPlusAPI.Services.InventoryModuleService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AddProductForCompany(Product product, Guid companyId)
        {
            await _productRepository.AddProductForCompany(product, companyId);
        }

        public async Task DeleteProductForCompany(int productId, Guid companyId)
        {
            await _productRepository.DeleteProductForCompany(productId, companyId);
        }

        public async Task<Product> GetProductByIdForCompany(int productId, Guid companyId)
        {
            return await _productRepository.GetProductByIdForCompany(productId, companyId);
        }

        public async Task<ICollection<Product>> GetProductsByCompanyId(Guid companyId)
        {
            return await _productRepository.GetProductsByCompanyId(companyId);
        }

        public async Task UpdateProductForCompany(Product product, Guid companyId)
        {
            await _productRepository.UpdateProductForCompany(product, companyId);
        }
    }
}
