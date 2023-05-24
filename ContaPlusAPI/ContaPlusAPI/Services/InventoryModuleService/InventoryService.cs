﻿using ContaPlusAPI.Interfaces.IRepository.InventoryRepositoryInterface;
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

        public async Task AddProductForCompany(Product product, Guid companyId)
        {
            await _inventoryRepository.AddProductForCompany(product, companyId);
        }

        public async Task DeleteProductForCompany(int productId, Guid companyId)
        {
            await _inventoryRepository.DeleteProductForCompany(productId, companyId);
        }

        public async Task<Product> GetProductByIdForCompany(int productId, Guid companyId)
        {
            return await _inventoryRepository.GetProductByIdForCompany(productId, companyId);
        }

        public async Task<ICollection<Product>> GetProductsByCompanyId(Guid companyId)
        {
            return await _inventoryRepository.GetProductsByCompanyId(companyId);
        }

        public async Task UpdateProductForCompany(Product product, Guid companyId)
        {
            await _inventoryRepository.UpdateProductForCompany(product, companyId);
        }
    }
}
