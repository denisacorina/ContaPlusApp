using ContaPlusAPI.Interfaces.IRepository;
using ContaPlusAPI.Interfaces.IService;

namespace ContaPlusAPI.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IUserService _userService;

        public AuthorizationService(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<bool> IsUserAccountat(Guid companyId)
        {
            var user = await _userService.GetCurrentUser();
            var userRoles = (await _userService.GetUserByIdRoles(user.UserId)).UserCompanyRoles;
            var userCompanyRole = userRoles.FirstOrDefault(u => u.Company.CompanyId == companyId && u.Roles.Any(r => r.RoleName == "accountant"));
            return userCompanyRole != null;
        }

        public async Task<bool> IsUserAdmin(Guid companyId)
        {
            var user = await _userService.GetCurrentUser();
            var userRoles = (await _userService.GetUserByIdRoles(user.UserId)).UserCompanyRoles;
            var userCompanyRole = userRoles.FirstOrDefault(u => u.Company.CompanyId == companyId && u.Roles.Any(r => r.RoleName == "admin"));
            return userCompanyRole != null;
        }

        public async Task<bool> IsUserManager(Guid companyId)
        {
            var user = await _userService.GetCurrentUser();
            var userRoles = (await _userService.GetUserByIdRoles(user.UserId)).UserCompanyRoles;
            var userCompanyRole = userRoles.FirstOrDefault(u => u.Company.CompanyId == companyId && u.Roles.Any(r => r.RoleName == "manager"));
            return userCompanyRole != null;
        }
    }
}
