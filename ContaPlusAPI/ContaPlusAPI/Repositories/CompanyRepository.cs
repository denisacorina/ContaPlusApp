using ContaPlusAPI.Context;
using ContaPlusAPI.Interfaces.IRepository;
using ContaPlusAPI.Models.CompanyModule;
using ContaPlusAPI.Models.UserModule;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContaPlusAPI.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _context;

        public CompanyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Company> GetCompanyById(Guid companyId)
        {
            return await _context.Companies.FirstOrDefaultAsync(c => c.CompanyId == companyId);
        }

        public async Task<Company> GetCompanyByEmail(string email)
        {
            return await _context.Companies.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddCompany(Company company)
        {
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCompany(Company company)
        {
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> EmailExists(string email)
        {
            return await _context.Companies.AnyAsync(c => c.Email == email);
        }

        public async Task<bool> FiscalCodeExists(string fiscalCode)
        {
            return await _context.Companies.AnyAsync(c => c.FiscalCode == fiscalCode);
        }

        public async Task<bool> TradeRegisterExists(string tradeRegister)
        {
            return await _context.Companies.AnyAsync(c => c.TradeRegister == tradeRegister);
        }

        public async Task<IEnumerable<Company>> GetCompaniesCurrentUser(Guid userId)
        {
            return await _context.Companies
                .Where(u => u.Users.Any(u => u.UserId == userId))
                .ToListAsync();
        }

        public async Task<List<Company>> GetAdminCompanies(Guid userId)
        {
             return await _context.UserCompanyRoles
                 .Include(u => u.Company)
                 .Where(u => u.User.UserId == userId && u.Roles.Any(r => r.RoleName == "admin"))
                 .Select(u => u.Company)
                 .ToListAsync();
        }
    }
}
