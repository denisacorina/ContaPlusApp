using ContaPlusAPI.Models.CompanyModule;
using ContaPlusAPI.Models.UserModule;

namespace ContaPlusAPI.Interfaces.IRepository
{
    public interface IUserCompanyRoleRepository
    {
        Task<IEnumerable<Role>> GetRoles();
        Task<Role> GetRoleById(int roleId);
        Task<bool> UserIsAssignedToCompany(User user, Company company);
        Task AddRoleToUserCompany(UserCompanyRole userCompanyRole);
        Task<UserCompanyRole> GetUserCompanyRole(Guid userId, Guid companyId);
        Task<List<UserCompanyRole>> GetListCompanyUserRoles(Guid companyId);
    }
}
