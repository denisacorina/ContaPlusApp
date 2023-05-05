using ContaPlusAPI.DTOs.AuthentificationDTO;
using Microsoft.AspNetCore.Mvc;

namespace ContaPlusAPI.Interfaces.IService
{
    public interface IAuthentificationService
    {
        Task<IActionResult> Register(RegisterUserDTO registerUser);
        Task<IActionResult> Login(LoginUserDTO loginUser);
    }
}
