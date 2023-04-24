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

            company.CreatedAt = DateTime.UtcNow;
            existingUser.Companies.Add(company);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
