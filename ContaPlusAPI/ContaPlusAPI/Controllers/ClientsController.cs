using ContaPlusAPI.Interfaces.IRepository.AccountingRepositoryInterface;
using ContaPlusAPI.Interfaces.IService.AccountingServiceInterface;
using ContaPlusAPI.Models;
using ContaPlusAPI.Models.AccountingModule;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContaPlusAPI.Controllers
{
    public class ClientsController : BaseApiController
    {
        private readonly IClientSupplierService _clientSupplierService;
        private readonly IClientSupplierRepository _clientSupplierRepository;
        public ClientsController(IClientSupplierService clientSupplierService, IClientSupplierRepository clientSupplierRepository) 
        { 
            _clientSupplierService = clientSupplierService;
            _clientSupplierRepository = clientSupplierRepository;
        }

        [HttpGet("getAllClientsForCompany")]
        public async Task<ICollection<Client>> GetAllClientsForCompany(Guid companyId)
        {
            var clients = await _clientSupplierService.GetAllClientsForCompany(companyId);
            return clients;
        }

        [HttpGet("getClientByIdForCompany")]
        public async Task<Client> GetClientByIdForCompany(int clientId, Guid companyId)
        {
            var client = await _clientSupplierService.GetClientByIdForCompany(clientId, companyId);
            return client;
        }

        [HttpGet("getClientById")]
        public async Task<Client> GetClientById(int clientId)
        {
            var client = await _clientSupplierRepository.GetClientById(clientId);
            return client;
        }

        [HttpPost("addClientForCompany")]
        public async Task AddClientForCompany(Client client, Guid companyId)
        {
            await _clientSupplierService.AddClientForCompany(client, companyId);
        }

        [HttpPut("updateClientForCompany")]
        public async Task UpdateClientForCompany(Client client, Guid companyId)
        {
            await _clientSupplierService.UpdateClientForCompany(client, companyId);
        }

        [HttpDelete("deleteClientForCompany")]
        public async Task DeleteClientForCompany(Client client, Guid companyId)
        {
            await _clientSupplierService.DeleteClientForCompany(client, companyId);
        }
    }
}
