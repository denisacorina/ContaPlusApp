using AutoMapper;
using Azure.Core;
using ContaPlusAPI.Context;
using ContaPlusAPI.Models;
using ContaPlusAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;
using Swashbuckle.Swagger;

namespace ContaPlusAPI.Services.Repository
{
    public class AuthenticationRepository : IAuthentication
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly IPasswordHash _passwordHash;
        private readonly IGenerateToken _token;
        public AuthenticationRepository(IMapper mapper, AppDbContext context, IPasswordHash passwordHash, IGenerateToken token) 
        {
            _mapper = mapper;
            _context = context;
            _passwordHash = passwordHash;
            _token = token;
        }

        public async Task<IActionResult> Register(RegisterUserDTO registerUser)
        {
            var mappedUser = _mapper.Map<User>(registerUser);
            var userExists = await _context.Users.FirstOrDefaultAsync(u => u.Email == registerUser.Email);
            if (userExists == null)
            {
                _passwordHash.HashPassword(registerUser.Password!, out byte[] passwordHash, out byte[] passwordSalt);
                mappedUser.FirstName = registerUser.FirstName;
                mappedUser.LastName = registerUser.LastName;
                mappedUser.Email = registerUser.Email;
                mappedUser.PaswordHash = passwordHash;
                mappedUser.PaswordSalt = passwordSalt;
                mappedUser.CreatedAt = DateTime.UtcNow;
             
                _context.Users.Add(mappedUser);

                await _context.SaveChangesAsync();
                return new OkObjectResult(mappedUser);
            }
            else
                return new BadRequestObjectResult("User already exists");
        }

        public async Task<IActionResult> Login(LoginUserDTO loginUser)
        {
            var userExists = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginUser.Email);
            if (userExists == null)
            {
                return new BadRequestObjectResult("User not found");
            }
            else if (!_passwordHash.VerifyPassword(loginUser.Password, userExists.PaswordHash, userExists.PaswordSalt))
            {
                return new BadRequestObjectResult("Incorrect password");
            }
            userExists.RememberMe = loginUser.RememberMe;
            var accessToken = _token.GenerateAccessToken(userExists);
            var refreshToken = _token.GenerateRefreshToken();
            userExists.AccessToken = accessToken;
            userExists.RefreshToken = refreshToken.Token;
            userExists.CreatedAt = refreshToken.CreatedAt;
            userExists.TokenExpiration = refreshToken.ExpiresAt;

            await _context.SaveChangesAsync();

            var response = new
            {
                accessToken = userExists.AccessToken,
                userId = userExists.UserId,
                email = userExists.Email,
                rememberMe = userExists.RememberMe

            };
            return new OkObjectResult(response);
        }
    }
}
