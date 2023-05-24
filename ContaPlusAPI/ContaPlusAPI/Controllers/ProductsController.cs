using ContaPlusAPI.Interfaces.IService.InventoryServiceInterface;
using ContaPlusAPI.Models.InventoryModule;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContaPlusAPI.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IInventoryService _inventoryService;

        public ProductsController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet("getProductsByCompany")]
        public async Task<ICollection<Product>> GetProductsByCompanyId(Guid companyId)
        {
            var products = await _inventoryService.GetProductsByCompanyId(companyId);
            return products;
        }

        [HttpGet("getProductByIdForCompany")]
        public async Task<Product> GetProductByIdForCompany(int productId, Guid companyId)
        {
            var product = await _inventoryService.GetProductByIdForCompany(productId, companyId);
            return product;
        }

        [HttpPost("addProductForCompany")]
        public async Task AddProductForCompany(Product product, Guid companyId)
        {
            await _inventoryService.AddProductForCompany(product, companyId);
        }

        [HttpPut("updateProductForCompany")]
        public async Task UpdateProductForCompany(Product product, Guid companyId)
        {
            await _inventoryService.UpdateProductForCompany(product, companyId);
        }

        [HttpDelete("deleteProductForCompany")]
        public async Task DeleteProductForCompany(int productId, Guid companyId)
        {
            await _inventoryService.DeleteProductForCompany(productId, companyId);
        }
    }
}
