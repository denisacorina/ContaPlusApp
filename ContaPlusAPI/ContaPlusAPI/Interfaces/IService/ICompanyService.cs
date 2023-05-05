using ContaPlusAPI.Models.CompanyModule;
using ContaPlusAPI.Models.UserModule;
using Microsoft.AspNetCore.Mvc;

namespace ContaPlusAPI.Interfaces.IService
{
    public interface ICompanyService
    {
        Task<Company> GetCompanyByEmail(string email);
        Task<Company> GetCompanyById(Guid companyId);
        Task<bool> EmailExists(string email);
        Task<bool> FiscalCodeExists(string fiscalCode);
        Task<bool> TradeRegisterExists(string tradeRegister);
        Task AddCompanyToUser(Company company);
        Task UpdateCompany(Company updatedCompany, Guid companyId);
        Task<IEnumerable<Company>> GetCompaniesCurrentUser(Guid userId);
    }
}
