using ContaPlusAPI.Interfaces.IService;
using ContaPlusAPI.Models.UserModule;
using Microsoft.AspNetCore.Mvc;

namespace ContaPlusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : BaseApiController
    {
        private readonly IUserCompanyRoleService _userCompanyRoleService;

        public RolesController(IUserCompanyRoleService userCompanyRoleService) 
        {
            _userCompanyRoleService = userCompanyRoleService;
        }

        [HttpGet("getRoles")]
        public async Task<IEnumerable<Role>> GetRoles()
        {
            return await _userCompanyRoleService.GetRoles();
        }
    }
}
