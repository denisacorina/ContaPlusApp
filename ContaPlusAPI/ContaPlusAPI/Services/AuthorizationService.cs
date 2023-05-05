using ContaPlusAPI.Interfaces.IRepository;
using ContaPlusAPI.Interfaces.IService;
using System.Security.Claims;

namespace ContaPlusAPI.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IUserRepository _userRepository;

        public AuthorizationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> IsUserAccountat(Guid companyId)
        {
            var userId = _userRepository.GetCurrentUser();
            var userRoles = await _userRepository.GetUserRoles(userId);
            var userCompanyRole = userRoles.FirstOrDefault(u => u.Company.CompanyId == companyId && u.Roles.Any(r => r.RoleName == "accountant"));
            return userCompanyRole != null;
        }

        public async Task<bool> IsUserAdmin(Guid companyId)
        {
            var userId = _userRepository.GetCurrentUser();
            var userRoles = await _userRepository.GetUserRoles(userId);
            var userCompanyRole = userRoles.FirstOrDefault(u => u.Company.CompanyId == companyId && u.Roles.Any(r => r.RoleName == "admin"));
            return userCompanyRole != null;
        }

        public async Task<bool> IsUserManager(Guid companyId)
        {
            var userId = _userRepository.GetCurrentUser();
            var userRoles = await _userRepository.GetUserRoles(userId);
            var userCompanyRole = userRoles.FirstOrDefault(u => u.Company.CompanyId == companyId && u.Roles.Any(r => r.RoleName == "manager"));
            return userCompanyRole != null;
        }
    }
}
