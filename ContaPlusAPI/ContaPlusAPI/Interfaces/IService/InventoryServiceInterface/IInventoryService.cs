using ContaPlusAPI.Models.AccountingModule;
using ContaPlusAPI.Models.InventoryModule;

namespace ContaPlusAPI.Interfaces.IService.InventoryServiceInterface
{
    public interface IInventoryService
    {
        Task<ICollection<Product>> GetProductsByCompanyId(Guid companyId);
        Task<Product> GetProductByIdForCompany(int productId, Guid companyId);
        Task AddProductForCompany(Product product, Guid companyId);
        Task UpdateProductForCompany(Product product, Guid companyId);
        Task DeleteProductForCompany(int productId, Guid companyId);

        Task<ICollection<GeneralChartOfAccounts>> GeneralChartOfAccountsList();
    }
}
