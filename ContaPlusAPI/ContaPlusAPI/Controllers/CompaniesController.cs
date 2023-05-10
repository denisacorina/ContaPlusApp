using ContaPlusAPI.Context;
using ContaPlusAPI.Interfaces.IService;
using ContaPlusAPI.Models.CompanyModule;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContaPlusAPI.Controllers
{
    public class CompaniesController : BaseApiController
    {
        private readonly AppDbContext _context;
        private readonly ICompanyService _companyService;
        public CompaniesController(AppDbContext context, ICompanyService companyService)
        {
            _context = context;
            _companyService = companyService;
        }

        [HttpGet("getCompaniesForCurrentUser")]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompaniesCurrentUser(Guid userId)
        {
            var companies = await _companyService.GetCompaniesCurrentUser(userId);
            return Ok(companies);
        }

        [HttpGet("getCompanyById")]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanyIdData(Guid companyId)
        {
            var data = await _companyService.GetCompanyById(companyId);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet("emailExists")]
        public async Task<ActionResult<bool>> EmailExists(string email)
        {
            var emailExists = await _context.Companies.AnyAsync(c => c.Email == email);
            return emailExists;
        }

        [HttpGet("fiscalCodeExists")]
        public async Task<ActionResult<bool>> FiscalCodeExists(string fiscalCode)
        {
            var fiscalCodeExists = await _context.Companies.AnyAsync(c => c.FiscalCode == fiscalCode);
            return fiscalCodeExists;
        }

        [HttpGet("tradeRegisterExists")]
        public async Task<ActionResult<bool>> TradeRegisterExists(string tradeRegister)
        {
            var tradeRegisterExists = await _context.Companies.AnyAsync(c => c.TradeRegister == tradeRegister);
            return tradeRegisterExists;
        }

        [HttpPost("{userId}/addCompany")]
        public async Task<IActionResult> AddCompanyToUser([FromBody] Company company)
        {
            await _companyService.AddCompanyToUser(company);
            return Ok();
        }

        [HttpPut("updateCompany/{companyId}")]
        public async Task<IActionResult> UpdateCompany([FromBody] Company updatedCompany, Guid companyId)
        {
            await _companyService.UpdateCompany(updatedCompany, companyId);
            return Ok("Company has been updated succesfully.");
        }
    }
}
