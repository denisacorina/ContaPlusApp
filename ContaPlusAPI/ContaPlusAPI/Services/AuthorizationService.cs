using ContaPlusAPI.Interfaces.IRepository;
using ContaPlusAPI.Interfaces.IService;
using ContaPlusAPI.Models.UserModule;
using Microsoft.AspNetCore.Mvc;

namespace ContaPlusAPI.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IUserService _userService;

        public AuthorizationService(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<bool> IsUserAccountat(Guid companyId, Guid userId)
        {
            var user = await _userService.GetUserById(userId);
            var userRoles = (await _userService.GetUserByIdRoles(user.UserId)).UserCompanyRoles;
            var userCompanyRole = userRoles.FirstOrDefault(u => u.Company.CompanyId == companyId && u.Roles.Any(r => r.RoleName == "accountant"));
            return userCompanyRole != null;
        }

        public async Task<bool> IsUserAdmin(Guid companyId, Guid userId)
        {
            var user = await _userService.GetUserById(userId);
            if(user == null) throw new Exception("User not found.");
            var userRoles = (await _userService.GetUserByIdRoles(user.UserId)).UserCompanyRoles;
            var userCompanyRole = userRoles.FirstOrDefault(u => u.Company.CompanyId == companyId && u.Roles.Any(r => r.RoleName == "admin"));
            return userCompanyRole != null;
        }

        public async Task<bool> IsUserManager(Guid companyId, Guid userId)
        {
            var user = await _userService.GetUserById(userId);
            var userRoles = (await _userService.GetUserByIdRoles(user.UserId)).UserCompanyRoles;
            var userCompanyRole = userRoles.FirstOrDefault(u => u.Company.CompanyId == companyId && u.Roles.Any(r => r.RoleName == "manager"));
            return userCompanyRole != null;
        }
    }
}
