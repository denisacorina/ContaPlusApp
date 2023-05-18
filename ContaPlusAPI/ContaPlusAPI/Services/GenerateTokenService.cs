using ContaPlusAPI.Interfaces.IRepository;
using ContaPlusAPI.Interfaces.IService;
using ContaPlusAPI.Models.Authentification;
using ContaPlusAPI.Models.UserModule;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ContaPlusAPI.Services
{
    public class GenerateTokenService : IGenerateTokenService
    {
        private readonly IConfiguration _config;
        private readonly ISaveChangesRepository _saveChangesRepository;

        public GenerateTokenService(IConfiguration config, ISaveChangesRepository saveChangesRepository)
        {
            _config = config;
            _saveChangesRepository = saveChangesRepository;
        }

        public string GenerateAccessToken(User user)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name,user.UserId.ToString()),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Key").Value));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: user.RememberMe ? DateTime.UtcNow.AddDays(7) : DateTime.UtcNow.AddHours(3),
                signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        public RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                ExpiresAt = DateTime.UtcNow.AddDays(7),
                CreatedAt = DateTime.UtcNow
            };
            return refreshToken;
        }

        public async Task<string> GenerateResetToken(User user)
        {
            var resetToken = Guid.NewGuid().ToString();
            user.ResetPasswordToken = resetToken;
            user.ResetTokenExpiration = DateTime.UtcNow.AddHours(1);
            await _saveChangesRepository.SaveChanges();
            return resetToken;
        }

        public bool ValidateResetToken(User user, string token)
        {
            if (user.ResetPasswordToken == token && user.ResetTokenExpiration > DateTime.UtcNow) return true;
            return false;
        }
    }
}
