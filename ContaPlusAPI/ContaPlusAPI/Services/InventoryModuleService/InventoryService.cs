using ContaPlusAPI.Interfaces.IRepository.InventoryRepositoryInterface;
using ContaPlusAPI.Interfaces.IService.InventoryServiceInterface;
using ContaPlusAPI.Models.InventoryModule;

namespace ContaPlusAPI.Services.InventoryModuleService
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;
        public InventoryService(IInventoryRepository inventoryRepository) 
        {
            _inventoryRepository = inventoryRepository;
        }
        public async Task AddInventoryForCompany(Inventory inventory, Guid companyId)
        {
            await _inventoryRepository.AddInventoryForCompany(inventory, companyId);
        }

        public async Task<Inventory> GetInventoryByCompanyId(Guid companyId)
        {
            return await _inventoryRepository.GetInventoryByCompanyId(companyId);
        }

        public async Task UpdateInventoryForCompany(Inventory inventory, Guid companyId)
        {
           await _inventoryRepository.UpdateInventoryForCompany(inventory, companyId);
        }
    }
}
