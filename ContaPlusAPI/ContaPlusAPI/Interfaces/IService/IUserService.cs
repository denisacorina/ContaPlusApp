using ContaPlusAPI.DTOs.UserDTOs;
using ContaPlusAPI.Models.CompanyModule;
using ContaPlusAPI.Models.UserModule;
using Microsoft.AspNetCore.Mvc;

namespace ContaPlusAPI.Interfaces.IService
{
    public interface IUserService
    {
        Task <User> GetUserById(Guid userId);
        Task <User> GetUserByIdRoles(Guid userId);
        Task<User> GetCurrentUser();
        Task<User> GetUserByEmail(string email);
        Task AddExistingUserToCompany(Company company, User user, int roleId);
        Task AddNewUserToCompany(Company company, string firstName, string lastName, string email, int roleId);
        Task<IActionResult> AddUserRoleToCompany(Guid userId, int roleId, Guid companyId);
        Task UpdateUser([FromBody] UserProfileUpdateDTO updatedUser, Guid userId);
    }
}
