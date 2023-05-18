using ContaPlusAPI.Context;
using ContaPlusAPI.Interfaces.IRepository.AccountingRepositoryInterface;
using ContaPlusAPI.Interfaces.IService;
using ContaPlusAPI.Models;
using ContaPlusAPI.Models.AccountingModule;
using Microsoft.EntityFrameworkCore;

namespace ContaPlusAPI.Repositories.AccountingRepository
{
    public class ClientSupplierRepository : IClientSupplierRepository
    {
        private readonly AppDbContext _context;
        private readonly ICompanyService _companyService;

        public ClientSupplierRepository(AppDbContext context, ICompanyService companyService)
        {
            _context = context;
            _companyService = companyService;
        }

        public async Task AddClientForCompany(Client client, Guid companyId)
        {
            var company = await _companyService.GetCompanyById(companyId);

            if (company != null)
            {
                client.Company = company;
                await _context.Clients.AddAsync(client);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddSupplierForCompany(Supplier supplier, Guid companyId)
        {
            var company = await _companyService.GetCompanyById(companyId);

            if (company != null)
            {
                supplier.Company = company;
                await _context.Suppliers.AddAsync(supplier);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ICollection<Client>> GetAllClientsForCompany(Guid companyId)
        {
            var clients = await _context.Clients.Where(c => c.Company.CompanyId == companyId).ToListAsync();
            return clients;
        }

        public async Task<ICollection<Supplier>> GetAllSuppliersForCompany(Guid companyId)
        {
            var suppliers = await _context.Suppliers.Where(s => s.Company.CompanyId == companyId).ToListAsync();
            return suppliers;
        }

        public async Task UpdateClientForCompany(Client client, Guid companyId)
        {
            var existingClient = await _context.Clients.FirstOrDefaultAsync(c => c.ClientId == client.ClientId);
            if (existingClient != null)
            {
                var company = await _context.Companies.FirstOrDefaultAsync(c => c.CompanyId == companyId);
                if (company != null)
                {
                    existingClient.ClientName = client.ClientName;
                    existingClient.FiscalCode = client.FiscalCode;
                    existingClient.Company = company;

                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task UpdateSupplierForCompany(Supplier supplier, Guid companyId)
        {
            var existingSupplier = await _context.Suppliers.FirstOrDefaultAsync(s => s.SupplierId == supplier.SupplierId);
            if (existingSupplier != null)
            {
                var company = await _context.Companies.FirstOrDefaultAsync(c => c.CompanyId == companyId);
                if (company != null)
                {
                    existingSupplier.SupplierName = supplier.SupplierName;
                    existingSupplier.FiscalCode = supplier.FiscalCode;
                    existingSupplier.Company = company;

                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task DeleteClientForCompany(Client client, Guid companyId)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(c => c.CompanyId == companyId);
            if (company != null)
            {
                client.Company = null;
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteSupplierForCompany(Supplier supplier, Guid companyId)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(c => c.CompanyId == companyId);
            if (company != null)
            {
                supplier.Company = null;
                _context.Suppliers.Remove(supplier);
                await _context.SaveChangesAsync();
            }
        }
    }
}
