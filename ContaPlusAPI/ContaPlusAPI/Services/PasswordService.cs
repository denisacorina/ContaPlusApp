using ContaPlusAPI.DTOs.AuthentificationDTO;
using ContaPlusAPI.Interfaces.IRepository;
using ContaPlusAPI.Interfaces.IService;
using System.Security.Cryptography;
using System.Text;

namespace ContaPlusAPI.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly IUserRepository _userRepository;
        private readonly IGenerateTokenService _generateTokenService;
        private readonly IEmailSenderService _emailSenderService;
        private readonly ISaveChangesRepository _saveChangesRepository;

        public PasswordService(IUserRepository userRepository, IGenerateTokenService generateTokenService,
            IEmailSenderService emailSenderService, ISaveChangesRepository saveChangesRepository)
        {
            _userRepository = userRepository;
            _generateTokenService = generateTokenService;
            _emailSenderService = emailSenderService;
            _saveChangesRepository = saveChangesRepository;
        }

        public void HashPassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var ComputeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return ComputeHash.SequenceEqual(passwordHash);
        }

        public string GeneratePassword()
        {
            var randomBytes = new byte[8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }
            string password = Convert.ToBase64String(randomBytes);
            return password;
        }

        public async Task<bool> ForgotPassword(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);
            if (user == null) return false;

            await _generateTokenService.GenerateResetToken(user);

            await _emailSenderService.SendResetPasswordLink(user);
            await _saveChangesRepository.SaveChanges();

            return true;
        }

        public async Task<bool> ResetPassword(ResetPasswordDTO resetPassword)
        {
            var user = await _userRepository.GetUserByEmail(resetPassword.Email);
            if (user == null) return false;

            var resetToken = resetPassword.ResetToken;

            if (!_generateTokenService.ValidateResetToken(user, resetToken))
            {
                return false;
            }

            HashPassword(resetPassword.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.ResetPasswordToken = null;
            user.ResetTokenExpiration = null;
            await _saveChangesRepository.SaveChanges();

            return true;
        }
    }
}
