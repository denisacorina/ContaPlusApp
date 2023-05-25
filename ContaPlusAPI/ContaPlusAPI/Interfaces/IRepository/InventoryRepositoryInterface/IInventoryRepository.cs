using ContaPlusAPI.Models.InventoryModule;

namespace ContaPlusAPI.Interfaces.IRepository.InventoryRepositoryInterface
{
    public interface IInventoryRepository
    {
        Task<ICollection<Product>> GetProductsByCompanyId(Guid companyId);
        Task<Product> GetProductByIdForCompany(int productId, Guid companyId);
        Task<Product> GetProductByNameForCompany(string productName, Guid companyId);
        Task AddProductForCompany(Product product, Guid companyId);
        Task UpdateProductForCompany(Product product, Guid companyId);
        Task UpdateProductQuantity(Product product, Guid companyId);
        Task DeleteProductForCompany(int productId, Guid companyId);
    }
}
