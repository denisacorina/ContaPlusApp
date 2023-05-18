using ContaPlusAPI.Models.UserModule;

namespace ContaPlusAPI.Interfaces.IService
{
    public interface IUserCompanyRoleService
    {
        Task<IEnumerable<Role>> GetRoles();
    }
}
