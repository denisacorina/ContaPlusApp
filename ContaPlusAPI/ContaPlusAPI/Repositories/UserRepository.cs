using ContaPlusAPI.Context;
using ContaPlusAPI.Interfaces.IRepository;
using ContaPlusAPI.Models.CompanyModule;
using ContaPlusAPI.Models.UserModule;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ContaPlusAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<List<UserCompanyRole>> GetUserRoles(Guid userId)
        {
            return await _context.UserCompanyRoles
                .Include(u => u.Roles)
                .Include(u => u.Company)
                .Where(u => u.User.UserId == userId)
                .ToListAsync();
        }

        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserById(Guid userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<User> GetUserByIdRoles(Guid userId)
        {
            return await _context.Users
              .Include(u => u.UserCompanyRoles)
              .ThenInclude(u => u.Roles)
              .Include(u => u.Companies)
              .FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task<Role> GetRole(int roleId)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.RoleId == roleId);
        }
    }
}
