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
        public ClientsController(IClientSupplierService clientSupplierService) 
        { 
            _clientSupplierService = clientSupplierService;
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
