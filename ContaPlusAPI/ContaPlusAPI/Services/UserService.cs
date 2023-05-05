using ContaPlusAPI.DTOs.UserDTOs;
using ContaPlusAPI.Interfaces.IRepository;
using ContaPlusAPI.Interfaces.IService;
using ContaPlusAPI.Models.CompanyModule;
using ContaPlusAPI.Models.UserModule;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ContaPlusAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserCompanyRoleRepository _userCompanyRoleRepository;
        private readonly IEmailSenderService _emailSenderService;
        private readonly IPasswordService _passwordService;
        private readonly ISaveChangesRepository _saveChangesRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IUserRepository userRepository, IUserCompanyRoleRepository userCompanyRoleRepository,
            ICompanyRepository companyRepository, IEmailSenderService emailSenderService, IPasswordService passwordService,
            ISaveChangesRepository saveChangesRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _userCompanyRoleRepository = userCompanyRoleRepository;
            _emailSenderService = emailSenderService;
            _passwordService = passwordService;
            _saveChangesRepository = saveChangesRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddExistingUserToCompany(Company company, User user, int roleId)
        {
            bool userAlreadyAssignedToCompany = await _userCompanyRoleRepository.UserIsAssignedToCompany(user, company);

            if (userAlreadyAssignedToCompany) throw new ArgumentException("User is already assigned to this company.");

            var companyRoleExistingUser = new UserCompanyRole
            {
                UserCompanyId = Guid.NewGuid(),
                User = user,
                Company = company
            };

            var role = await _userCompanyRoleRepository.GetRoleById(roleId);

            if (role != null)
                companyRoleExistingUser.Roles?.Add(role);

            user.Companies?.Add(company);

            await _userCompanyRoleRepository.AddRoleToUserCompany(companyRoleExistingUser);

            await _saveChangesRepository.SaveChanges();

            await _emailSenderService.SendEmailToNewAddedUserWithAccount(user, company.CompanyName, role);
        }

        public async Task AddNewUserToCompany(Company company, string firstName, string lastName, string email, int roleId)
        {
            string password = _passwordService.GeneratePassword();

            _passwordService.HashPassword(password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User
            {
                UserId = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedAt = DateTime.UtcNow
            };

            await _userRepository.AddUser(user);

            var companyRoleNewUser = new UserCompanyRole
            {
                UserCompanyId = Guid.NewGuid(),
                User = user,
                Company = company
            };

            var role = await _userCompanyRoleRepository.GetRoleById(roleId);

            if (role != null)
                companyRoleNewUser.Roles?.Add(role);

            user.Companies?.Add(company);

            await _userCompanyRoleRepository.AddRoleToUserCompany(companyRoleNewUser);

            await _saveChangesRepository.SaveChanges();

            await _emailSenderService.SendEmailToNewAddedUserWithoutAccount(user, company.CompanyName, role, password);
        }

        public async Task<User> GetUserById(Guid userId)
        {
            return await _userRepository.GetUserById(userId);
        }

        public async Task<User> GetUserByIdRoles(Guid userId)
        {
            return await _userRepository.GetUserByIdRoles(userId);
        }

        public async Task<User> GetCurrentUser()
        {
            var userId = Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value);
            return await _userRepository.GetUserById(userId);
        }
        public async Task<User> GetUserByEmail(string email)
        {
            return await _userRepository.GetUserByEmail(email);
        }

        public async Task<IActionResult> AddUserRoleToCompany(Guid userId, int roleId, Guid companyId)
        {
            var userCompanyRole = await _userCompanyRoleRepository.GetUserCompanyRole(userId, companyId);

            if (userCompanyRole == null)
            {
                return new NotFoundResult();
            }

            var role = await _userCompanyRoleRepository.GetRoleById(roleId);

            if (role == null)
            {
                return new NotFoundResult();
            }

            if (userCompanyRole.Roles.Any(r => r.RoleId == roleId))
            {
                return new BadRequestObjectResult("User already has this role for the given company.");
            }

            userCompanyRole.Roles.Add(role);
            await _saveChangesRepository.SaveChanges();

            return new OkResult();
        }

        public async Task UpdateUser([FromBody] UserProfileUpdateDTO updatedUser, Guid userId)
        {
            var currentUserInfo = await _userRepository.GetUserById(userId);
            if (currentUserInfo == null) throw new Exception("User not found.");
            if (updatedUser.FirstName != null)
                currentUserInfo.FirstName = updatedUser.FirstName ?? currentUserInfo.FirstName;

            if (updatedUser.LastName != null)
                currentUserInfo.LastName = updatedUser.LastName ?? currentUserInfo.LastName;

            if (updatedUser.ProfilePicture != null)
                currentUserInfo.ProfilePicture = updatedUser.ProfilePicture ?? currentUserInfo.ProfilePicture;

            currentUserInfo.UpdatedAt = DateTime.UtcNow;

            await _saveChangesRepository.SaveChanges();
        }
    }
}
