using ContaPlusAPI.Context;
using ContaPlusAPI.Interfaces.IRepository;
using ContaPlusAPI.Models.CompanyModule;
using ContaPlusAPI.Models.UserModule;
using Microsoft.EntityFrameworkCore;

namespace ContaPlusAPI.Repositories
{
    public class UserCompanyRoleRepository : IUserCompanyRoleRepository
    {
        private readonly AppDbContext _context;

        public UserCompanyRoleRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddRoleToUserCompany(UserCompanyRole userCompanyRole)
        {
            await _context.UserCompanyRoles.AddAsync(userCompanyRole);
            await _context.SaveChangesAsync();
        }

        public async Task<Role> GetRoleById(int roleId)
        {
            return await _context.Roles.FindAsync(roleId);
        }

        public async Task<IEnumerable<Role>> GetRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<UserCompanyRole> GetUserCompanyRole(Guid userId, Guid companyId)
        {
           return await _context.UserCompanyRoles
          .Include(u => u.User)
          .Include(u => u.Company)
          .Include(u => u.Roles)
          .FirstOrDefaultAsync(u => u.User.UserId == userId && u.Company.CompanyId == companyId);
        }

        public async Task<List<UserCompanyRole>> GetListCompanyUserRoles(Guid companyId)
        {
            return await _context.UserCompanyRoles
         .Include(u => u.User)
         .Include(u => u.Company)
         .Include(u => u.Roles)
         .Where(u => u.Company.CompanyId == companyId)
         .ToListAsync();
        }

        public async Task<bool> UserIsAssignedToCompany(User user, Company company)
        {
            return await _context.UserCompanyRoles.AnyAsync(u => u.User == user && u.Company == company);
        }
    }
}
