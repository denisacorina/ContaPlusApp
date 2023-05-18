using ContaPlusAPI.Models.CompanyModule;
using ContaPlusAPI.Models.UserModule;
using Microsoft.AspNetCore.Mvc;

namespace ContaPlusAPI.Interfaces.IRepository
{
    public interface ICompanyRepository
    {
        Task<Company> GetCompanyById(Guid id);
        Task<Company> GetCompanyByEmail(string email);
        Task<List<Company>> GetAdminCompanies(Guid userId);
        Task AddCompany(Company company);
        Task UpdateCompany(Company company);
        Task<IEnumerable<Company>> GetCompaniesCurrentUser(Guid userId);
        Task<bool> EmailExists(string email);
        Task<bool> FiscalCodeExists(string fiscalCode);
        Task<bool> TradeRegisterExists(string tradeRegister);
    }
}
