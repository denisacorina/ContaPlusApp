﻿using ContaPlusAPI.Models.AccountingModule;
using ContaPlusAPI.Models;

namespace ContaPlusAPI.Interfaces.IService.AccountingServiceInterface
{
    public interface IClientSupplierService
    {
        Task<ICollection<Client>> GetAllClientsForCompany(Guid companyId);
        Task AddClientForCompany(Client client, Guid companyId);
        Task UpdateClientForCompany(Client client, Guid companyId);
        Task DeleteClientForCompany(Client client, Guid companyId);

        Task<ICollection<Supplier>> GetAllSuppliersForCompany(Guid companyId);
        Task AddSupplierForCompany(Supplier supplier, Guid companyId);
        Task UpdateSupplierForCompany(Supplier supplier, Guid companyId);
        Task DeleteSupplierForCompany(Supplier supplier, Guid companyId);
    }
}