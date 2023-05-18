using ContaPlusAPI.Models.InventoryModule;

namespace ContaPlusAPI.Interfaces.IService.InventoryServiceInterface
{
    public interface IInventoryService
    {
        Task<Inventory> GetInventoryByCompanyId(Guid companyId);
        Task AddInventoryForCompany(Inventory inventory, Guid companyId);
        Task UpdateInventoryForCompany(Inventory inventory, Guid companyId);
    }
}
