using ContaPlusAPI.Context;
using ContaPlusAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ContaPlusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase { 
        private readonly AppDbContext _context;
        public CompaniesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("getCompaniesForCurrentUser")]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies(Guid userId)
        {
            var companies = await _context.Companies
                .Where(c => c.Users.Any(u => u.UserId == userId))
                .ToListAsync();
            return companies;
        }

        [HttpGet("getCompanyById")]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanyIdData(Guid companyId)
        {
            var data = await _context.Companies
                .Where(c => c.CompanyId == companyId)
                .ToListAsync();
            return data;
        }

        [HttpPost("{userId}/addCompany")]
        public async Task<IActionResult> AddCompanyToUser(Guid userId, [FromBody] Company company)
        {
            var existingUser = await _context.Users
                .Include(u => u.Companies)
                .FirstOrDefaultAsync(u => u.UserId == userId);

            if (existingUser == null)
            {
                return NotFound("User not found.");
            }

            Role adminRole = await _context.Roles.FirstOrDefaultAsync(r => r.RoleId == 1);
            if (adminRole != null)
            {
                UserCompanyRole userCompanyRole = existingUser.UserCompanyRoles.FirstOrDefault(u => u.Company.CompanyId == company.CompanyId);
                if (userCompanyRole == null)
                {
                    userCompanyRole = new UserCompanyRole
                    {
                        User = existingUser,
                        Company = company
                    };
                    existingUser.UserCompanyRoles.Add(userCompanyRole);
                    company.UserCompanyRoles.Add(userCompanyRole);
                }
                userCompanyRole.Roles.Add(adminRole);
            }

            company.Users = new List<User> { existingUser };
            company.CreatedAt = DateTime.UtcNow;
            existingUser.Companies.Add(company);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("updateCompany/{companyId}")]
        public async Task<IActionResult> UpdateCompany([FromBody] Company updatedCompany, Guid companyId)
        {
            var currentCompanyInfo = await _context.Companies
                .FirstOrDefaultAsync(c => c.CompanyId == companyId);

            if (currentCompanyInfo == null)
            {
                return NotFound();
            }

            if (updatedCompany.CompanyName != null)
                currentCompanyInfo.CompanyName = updatedCompany.CompanyName ?? currentCompanyInfo.CompanyName;

            if (updatedCompany.Email != null)
                currentCompanyInfo.Email = updatedCompany.Email ?? currentCompanyInfo.Email;

            if (updatedCompany.FiscalCode != null)
                currentCompanyInfo.FiscalCode = updatedCompany.FiscalCode ?? currentCompanyInfo.FiscalCode;

            if (updatedCompany.TradeRegister != null)
                currentCompanyInfo.TradeRegister = updatedCompany.TradeRegister ?? currentCompanyInfo.TradeRegister;

            if (updatedCompany.PhoneNumber != null)
                currentCompanyInfo.PhoneNumber = updatedCompany.PhoneNumber ?? currentCompanyInfo.PhoneNumber;

            if (updatedCompany.Address != null)
                currentCompanyInfo.Address = updatedCompany.Address ?? currentCompanyInfo.Address;
        
            if (updatedCompany.SocialCapital >= 200)
                currentCompanyInfo.SocialCapital = updatedCompany.SocialCapital;
            else updatedCompany.SocialCapital = currentCompanyInfo.SocialCapital;

            if (updatedCompany.Logo != null)
                currentCompanyInfo.Logo = updatedCompany.Logo ?? currentCompanyInfo.Logo;

            if (updatedCompany.Signature != null)
                currentCompanyInfo.Signature = updatedCompany.Signature ?? currentCompanyInfo.Signature;

            currentCompanyInfo.TvaPayer = updatedCompany.TvaPayer ? updatedCompany.TvaPayer : currentCompanyInfo.TvaPayer;

            currentCompanyInfo.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return Ok(currentCompanyInfo);
        }
    }
}
