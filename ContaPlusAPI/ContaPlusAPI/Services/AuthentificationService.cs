using AutoMapper;
using ContaPlusAPI.DTOs.AuthentificationDTO;
using ContaPlusAPI.Interfaces.IRepository;
using ContaPlusAPI.Interfaces.IService;
using ContaPlusAPI.Models.UserModule;
using Microsoft.AspNetCore.Mvc;

namespace ContaPlusAPI.Services
{
    public class AuthentificationService : IAuthentificationService
    {
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;
        private readonly IGenerateTokenService _token;
        private readonly IEmailSenderService _emailSenderService;
        private readonly IUserRepository _userRepository;
        public AuthentificationService(IMapper mapper, IPasswordService passwordService, IGenerateTokenService token,
            IEmailSenderService emailSenderService, IUserRepository userRepository)
        {
            _mapper = mapper;
            _passwordService = passwordService;
            _token = token;
            _emailSenderService = emailSenderService;
            _userRepository = userRepository;
        }

        public async Task<IActionResult> Register(RegisterUserDTO registerUser)
        {
            var mappedUser = _mapper.Map<User>(registerUser);

            var user = await _userRepository.GetUserByEmail(mappedUser.Email);

            if (user == null)
            {
                _passwordService.HashPassword(registerUser.Password!, out byte[] passwordHash, out byte[] passwordSalt);
                mappedUser.FirstName = registerUser.FirstName;
                mappedUser.LastName = registerUser.LastName;
                mappedUser.Email = registerUser.Email;
                mappedUser.PasswordHash = passwordHash;
                mappedUser.PasswordSalt = passwordSalt;
                mappedUser.CreatedAt = DateTime.UtcNow;

                await _userRepository.AddUser(mappedUser);

                try
                {
                    await _emailSenderService.AfterRegistrationEmail(mappedUser);
                    return new OkObjectResult(mappedUser);
                }
                catch (Exception)
                {
                    return new BadRequestObjectResult("Failed to send email");
                }
            }
            else
                return new BadRequestObjectResult("User already exists");
        }

        public async Task<IActionResult> Login(LoginUserDTO loginUser)
        {
            var user = await _userRepository.GetUserByEmail(loginUser.Email);

            if (user == null)
            {
                return new BadRequestObjectResult("User not found");
            }

            if (!_passwordService.VerifyPassword(loginUser.Password, user.PasswordHash, user.PasswordSalt))
            {
                return new BadRequestObjectResult("Incorrect password");
            }

            user.RememberMe = loginUser.RememberMe;
            var accessToken = _token.GenerateAccessToken(user);
            var refreshToken = _token.GenerateRefreshToken();
            user.AccessToken = accessToken;
            user.RefreshToken = refreshToken.Token;
            user.CreatedAt = refreshToken.CreatedAt;
            user.TokenExpiration = refreshToken.ExpiresAt;

            await _userRepository.UpdateUser(user);

            var response = new
            {
                accessToken = user.AccessToken,
                userId = user.UserId,
                email = user.Email,
                rememberMe = user.RememberMe
            };

            return new OkObjectResult(response);
        }
    }
}
