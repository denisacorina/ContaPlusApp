using ContaPlusAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContaPlusAPI.Services.Interface
{
    public interface IAuthentication
    {
        Task<IActionResult> Register(RegisterUserDTO registerUser);
        Task<IActionResult> Login(LoginUserDTO loginUser);
    }
}
