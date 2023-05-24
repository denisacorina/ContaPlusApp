using ContaPlusAPI.Interfaces.IRepository.AccountingRepositoryInterface;
using ContaPlusAPI.Interfaces.IService.AccountingServiceInterface;
using ContaPlusAPI.Models;
using ContaPlusAPI.Models.AccountingModule;

namespace ContaPlusAPI.Services.AccountingService
{
    public class ClientSupplierService : IClientSupplierService
    {
        private readonly IClientSupplierRepository _clientSupplierRepository;
        public ClientSupplierService(IClientSupplierRepository clientSupplierRepository) 
        {
            _clientSupplierRepository = clientSupplierRepository;
        }
        public async Task AddClientForCompany(Client client, Guid companyId)
        {
            await _clientSupplierRepository.AddClientForCompany(client, companyId);
        }

        public async Task AddSupplierForCompany(Supplier supplier, Guid companyId)
        {
            await _clientSupplierRepository.AddSupplierForCompany(supplier, companyId);
        }

        public async Task DeleteClientForCompany(Client client, Guid companyId)
        {
            await _clientSupplierRepository.DeleteClientForCompany(client, companyId);
        }

        public async Task DeleteSupplierForCompany(Supplier supplier, Guid companyId)
        {
            await _clientSupplierRepository.DeleteSupplierForCompany(supplier, companyId);
        }

        public async Task<ICollection<Client>> GetAllClientsForCompany(Guid companyId)
        {
           return await _clientSupplierRepository.GetAllClientsForCompany(companyId);
        }

        public async Task<ICollection<Supplier>> GetAllSuppliersForCompany(Guid companyId)
        {
            return await _clientSupplierRepository.GetAllSuppliersForCompany(companyId);
        }

        public async Task<Client> GetClientByIdForCompany(int clientId, Guid companyId)
        {
            return await _clientSupplierRepository.GetClientByIdForCompany(clientId, companyId);
        }

        public async Task<Supplier> GetSupplierByIdForCompany(int supplierId, Guid companyId)
        {
            return await _clientSupplierRepository.GetSupplierByIdForCompany(supplierId, companyId);
        }

        public async Task UpdateClientForCompany(Client client, Guid companyId)
        {
            await _clientSupplierRepository.UpdateClientForCompany(client, companyId);
        }

        public async Task UpdateSupplierForCompany(Supplier supplier, Guid companyId)
        {
            await _clientSupplierRepository.UpdateSupplierForCompany(supplier, companyId);
        }
    }
}
