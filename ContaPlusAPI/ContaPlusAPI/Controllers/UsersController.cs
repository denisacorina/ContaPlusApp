using AutoMapper;
using ContaPlusAPI.Context;
using ContaPlusAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContaPlusAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UsersController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("usersList")]
        public async Task<ActionResult> GetUsersList()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("getUserById")]
        public ActionResult<User> GetUserById(Guid userId)
        {
            var user = _context.Users
                .Include(u => u.UserCompanyRoles)
                .ThenInclude(u => u.Roles)
                .FirstOrDefault(u => u.UserId == userId);

            if (user == null)
                return NotFound();

            return user;
        }

        [HttpPost("addUserRoleToCompany")]
        public IActionResult AddUserRoleToCompany(Guid userId, int roleId, Guid companyId)
        {
            var userCompanyRole = _context.UserCompanyRoles
                .Include(u => u.User)
                .Include(u => u.Company)
                .Include(u => u.Roles)
                .FirstOrDefault(u => u.User.UserId == userId && u.Company.CompanyId == companyId);

            if (userCompanyRole == null)
            {
                return NotFound();
            }

            var role = _context.Roles.FirstOrDefault(r => r.RoleId == roleId);

            if (role == null)
            {
                return NotFound();
            }

            if (userCompanyRole.Roles.Any(r => r.RoleId == roleId))
            {
                return BadRequest("User already has this role for the given company.");
            }

            userCompanyRole.Roles.Add(role);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet("currentUser")]
        public async Task<IActionResult> GetCurrentUserDetails()
        {
            var currentUser = User.Identity.Name;

            if (string.IsNullOrEmpty(currentUser))
                return Unauthorized();

            var currentUserInfo = await _context.Users.FirstOrDefaultAsync(u => u.UserId.ToString() == currentUser);

            if (currentUserInfo == null)
                return Unauthorized();

            return Ok(currentUserInfo);
        }


        [HttpPut("updateUser/{userId}")]
        public async Task<IActionResult> UpdateUser([FromBody] UserProfileUpdateDTO updatedUser, Guid userId)
        {
            var currentUserInfo = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);

            if (currentUserInfo == null)
                return NotFound();

            if (updatedUser.FirstName != null)  
                currentUserInfo.FirstName = updatedUser.FirstName ?? currentUserInfo.FirstName; 

            if (updatedUser.LastName != null)  
                currentUserInfo.LastName = updatedUser.LastName ?? currentUserInfo.LastName; 

            if (updatedUser.ProfilePicture != null)  
                currentUserInfo.ProfilePicture = updatedUser.ProfilePicture ?? currentUserInfo.ProfilePicture; 

            currentUserInfo.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return Ok(currentUserInfo);
        }







    }
}
