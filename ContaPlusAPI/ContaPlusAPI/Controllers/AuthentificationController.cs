using ContaPlusAPI.DTOs.AuthentificationDTO;
using ContaPlusAPI.Interfaces.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContaPlusAPI.Controllers
{
    [AllowAnonymous]
    public class AuthentificationController : BaseApiController
    {
        private readonly IAuthentificationService _authRepository;

        public AuthentificationController(IAuthentificationService authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDTO registerUser)
        {
            return await _authRepository.Register(registerUser);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDTO loginUser)
        {
            return await _authRepository.Login(loginUser);
        }
    }

}

