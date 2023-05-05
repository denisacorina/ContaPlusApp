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
        private readonly AppDbContext _context;
        private readonly IPasswordService _passwordService;
        private readonly IUserService _userService;
        private readonly ICompanyService _companyService;
        private readonly Interfaces.IService.IAuthorizationService _authorizationService;
        private readonly IGenerateTokenService _generateTokenService;

        public UsersController(AppDbContext context,
            IPasswordService passwordService,
            Interfaces.IService.IAuthorizationService authorizationService,
            IGenerateTokenService generateTokenService,
            IUserService userService,
            ICompanyService companyService)
        {
            _context = context;
            _passwordService = passwordService;
            _authorizationService = authorizationService;
            _generateTokenService = generateTokenService;
            _userService = userService;
            _companyService = companyService;
        }

        [HttpGet("getUserById")]
        public ActionResult<User> GetUserByIdRoles(Guid userId)
        {
            var user = _userService.GetUserByIdRoles(userId);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [Authorize]
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
        [Authorize]
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
        [Authorize]
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
        public async Task<IActionResult> AddNewUserToCompany(Guid companyId, string firstName, string lastName, string email, int roleId)
        {
            bool isUserAdmin = await _authorizationService.IsUserAdmin(companyId);

            if (!isUserAdmin) return Forbid("You are not authorized to perform this action.");

            User user = await _userService.GetUserByEmail(email);

            Company company = await _companyService.GetCompanyById(companyId);

            if (company == null) return BadRequest("Company doesn't exist.");

            if (user == null)
                await _userService.AddNewUserToCompany(company, firstName, lastName, email, roleId);

            return Ok("User added to company successfully.");
        }
    }

}
