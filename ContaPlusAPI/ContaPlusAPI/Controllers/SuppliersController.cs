using ContaPlusAPI.Interfaces.IService.AccountingServiceInterface;
using ContaPlusAPI.Models.AccountingModule;
using Microsoft.AspNetCore.Mvc;

namespace ContaPlusAPI.Controllers
{
    public class SuppliersController : BaseApiController
    {
        private readonly IClientSupplierService _clientSupplierService;
        public SuppliersController(IClientSupplierService clientSupplierService)
        {
            _clientSupplierService = clientSupplierService;
        }

        [HttpGet("getAllSuppliersForCompany")]
        public async Task<ICollection<Supplier>> GetAllSuppliersForCompany(Guid companyId)
        {
            var suppliers = await _clientSupplierService.GetAllSuppliersForCompany(companyId);
            return suppliers;
        }

        [HttpGet("getSupplierByIdForCompany")]
        public async Task<Supplier> GetSupplierByIdForCompany(int supplierId, Guid companyId)
        {
            var supplier = await _clientSupplierService.GetSupplierByIdForCompany(supplierId, companyId);   
            return supplier;
        }

        [HttpGet("getSupplierByName")]
        public async Task<Supplier> GetSupplierByName(string supplierName)
        {
            return await _clientSupplierService.GetSupplierByName(supplierName);
        }

        [HttpPost("addSupplierForCompany")]
        public async Task AddSupplierForCompany(Supplier supplier, Guid companyId)
        {
            await _clientSupplierService.AddSupplierForCompany(supplier, companyId); 
        }

        [HttpPut("updateSupplierForCompany")]
        public async Task UpdateSupplierForCompany(Supplier supplier, Guid companyId)
        {
            await _clientSupplierService.UpdateSupplierForCompany(supplier, companyId);
        }

        [HttpDelete("deleteSupplierForCompany")]
        public async Task DeleteSupplierForCompany(Supplier supplier, Guid companyId)
        {
            await _clientSupplierService.DeleteSupplierForCompany(supplier, companyId);
        }
    }
}
