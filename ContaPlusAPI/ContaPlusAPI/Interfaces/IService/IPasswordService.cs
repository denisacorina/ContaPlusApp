using ContaPlusAPI.DTOs.AuthentificationDTO;

namespace ContaPlusAPI.Interfaces.IService
{
    public interface IPasswordService
    {
        public void HashPassword(string password, out byte[] passwordHash, out byte[] passwordSalt);
        public bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt);
        string GeneratePassword();
        Task<bool> ForgotPassword(string email);
        Task<bool> ResetPassword(ResetPasswordDTO resetPassword);
    }
}
