using ContaPlusAPI.Models.InventoryModule;

namespace ContaPlusAPI.Interfaces.IRepository.InventoryRepositoryInterface
{
    public interface IInventoryRepository
    {
        Task<Inventory> GetInventoryByCompanyId(Guid companyId);
        Task AddInventoryForCompany(Inventory inventory, Guid companyId);
        Task UpdateInventoryForCompany(Inventory inventory, Guid companyId);
    }
}
