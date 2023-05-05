using ContaPlusAPI.Models.CompanyModule;
using ContaPlusAPI.Models.UserModule;

namespace ContaPlusAPI.Interfaces.IRepository
{
    public interface IUserRepository
    {
        Task<User> GetUserById(Guid userId);
        Task<User> GetUserByIdRoles(Guid userId);
        Task<User> GetUserByEmail(string email);
        Task AddUser(User user);
        Task UpdateUser(User user);
    }
}
