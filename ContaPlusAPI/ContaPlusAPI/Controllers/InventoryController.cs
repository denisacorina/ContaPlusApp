using ContaPlusAPI.Interfaces.IService.InventoryServiceInterface;
using ContaPlusAPI.Models.InventoryModule;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContaPlusAPI.Controllers
{
    public class InventoryController : BaseApiController
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet("getInventoryByCompanyId")]
        public async Task<Inventory> GetInventoryByCompanyId(Guid companyId)
        {
            var inventory = await _inventoryService.GetInventoryByCompanyId(companyId); ;
            return inventory;
        }

        [HttpPost("addInventoryForCompany")]
        public async Task AddInventoryForCompany(Inventory inventory, Guid companyId)
        {
            await _inventoryService.AddInventoryForCompany(inventory, companyId);
        }

        [HttpPut("updateInventoryForCompany")]
        public async Task UpdateInventoryForCompany(Inventory inventory, Guid companyId)
        {
            await _inventoryService.UpdateInventoryForCompany(inventory, companyId);
        }
    }
}
