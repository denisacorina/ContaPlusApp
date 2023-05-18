using ContaPlusAPI.Interfaces.IRepository;
using ContaPlusAPI.Interfaces.IService;
using ContaPlusAPI.Models.UserModule;

namespace ContaPlusAPI.Services
{
    public class UserCompanyRoleService : IUserCompanyRoleService
    {
        private readonly IUserCompanyRoleRepository _userCompanyRoleRepository;

        public UserCompanyRoleService(IUserCompanyRoleRepository userCompanyRoleRepository)
        {
            _userCompanyRoleRepository = userCompanyRoleRepository;
        }

        public async Task<IEnumerable<Role>> GetRoles()
        {
            return await _userCompanyRoleRepository.GetRoles();
        }
    }
}
