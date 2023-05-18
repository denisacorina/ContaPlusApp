using ContaPlusAPI.Context;
using ContaPlusAPI.DTOs.AuthentificationDTO;
using ContaPlusAPI.DTOs.UserDTOs;
using ContaPlusAPI.Interfaces.IService;
using ContaPlusAPI.Models.CompanyModule;
using ContaPlusAPI.Models.UserModule;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContaPlusAPI.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly IPasswordService _passwordService;
        private readonly IUserService _userService;
        private readonly ICompanyService _companyService;
        private readonly Interfaces.IService.IAuthorizationService _authorizationService;

        public UsersController(IPasswordService passwordService,
            Interfaces.IService.IAuthorizationService authorizationService,
            IUserService userService,
            ICompanyService companyService)
        {
            _passwordService = passwordService;
            _authorizationService = authorizationService;
            _userService = userService;
            _companyService = companyService;
        }

        [HttpGet("getUserById")]
        public async Task<ActionResult<IEnumerable<User>>> GetUserById(Guid userId)
        {
            var user = await _userService.GetUserById(userId);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost("addUserRoleToCompany")]
        public async Task<IActionResult> AddUserRoleToCompany(Guid userId, int roleId, Guid companyId)
        {
            return await _userService.AddUserRoleToCompany(userId, roleId, companyId);
        }

        [HttpGet("currentUser")]
        [Authorize]
        public async Task<ActionResult<User>> GetCurrentUser()
        {
            var user = await _userService.GetCurrentUser();
            if (user == null)
                return NotFound();

            return user;
        }

        [HttpPut("updateUser/{userId}")]
        public async Task<IActionResult> UpdateUser([FromBody] UserProfileUpdateDTO updatedUser, Guid userId)
        {
            await _userService.UpdateUser(updatedUser, userId);
            return Ok("User has been updated");
        }

        [HttpPost("forgotPassword/{email}")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var result = await _passwordService.ForgotPassword(email);

            if (result)
                return Ok("Forgot password link has been sent.");
            else
                return NotFound();

        }

        [HttpPost("resetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO resetPassword)
        {
            var result = await _passwordService.ResetPassword(resetPassword);

            if (result)
                return Ok("Password reset successful.");
            else
                return NotFound();
        }

        [HttpPost("addExistingUserToCompany")]
        public async Task<IActionResult> AddExistingUserToCompany(Guid companyId, string email, int roleId)
        {
            bool isUserAdmin = await _authorizationService.IsUserAdmin(companyId);

            if (!isUserAdmin) return Forbid("You are not authorized to perform this action.");

            User user = await _userService.GetUserByEmail(email);

            Company company = await _companyService.GetCompanyById(companyId);

            if (company == null) return BadRequest("Company doesn't exist.");

            if (user != null)
                await _userService.AddExistingUserToCompany(company, user, roleId);

            return Ok("User added to company successfully.");
        }

        [HttpPost("addNewUserToCompany")]
        [Authorize]
        public async Task<IActionResult> AddNewUserToCompany([FromBody] Test test)
        {
            bool isUserAdmin = await _authorizationService.IsUserAdmin(test.CompanyId);

            if (!isUserAdmin) return Forbid("You are not authorized to perform this action.");

            User user = await _userService.GetUserByEmail(test.Email);

            Company company = await _companyService.GetCompanyById(test.CompanyId);

            if (company == null) return BadRequest("Company doesn't exist.");

            if (user == null)
                await _userService.AddNewUserToCompany(company, test.FirstName, test.LastName, test.Email, test.RoleId);

            return Ok("User added to company successfully.");
        }

        [HttpGet("getUserCompanyRoles/{userId}/{companyId}")]
        public async Task<ActionResult<UserCompanyRole>> GetUserCompanyRole(Guid userId, Guid companyId)
        {
            return await _userService.GetUserCompanyRole(userId, companyId);
        }

        [HttpGet("getUsersAndRolesFromCompany")]
        public async Task<List<UserCompanyRole>> GetListCompanyUserRoles(Guid companyId)
        {
            return await _userService.GetListCompanyUserRoles(companyId);
        }
    }

    public class Test
    {
        public Guid CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
    }

}
