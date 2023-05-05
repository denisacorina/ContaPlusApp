using ContaPlusAPI.Models.Authentication;
using ContaPlusAPI.Models.UserModule;

namespace ContaPlusAPI.Interfaces.IService
{
    public interface IGenerateTokenService
    {
        string GenerateAccessToken(User user);
        RefreshToken GenerateRefreshToken();
        Task<string> GenerateResetToken(User user);
        bool ValidateResetToken(User user, string token);
    }
}
