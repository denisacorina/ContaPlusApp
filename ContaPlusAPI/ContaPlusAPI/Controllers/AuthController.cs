using AutoMapper;
using ContaPlusAPI.Context;

using ContaPlusAPI.Models;

using ContaPlusAPI.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ContaPlusAPI.Controllers
{
    [AllowAnonymous]
    public class AuthController : BaseApiController
    {
        private readonly IAuthentication _authRepository;

        public AuthController(IAuthentication authRepository)
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

