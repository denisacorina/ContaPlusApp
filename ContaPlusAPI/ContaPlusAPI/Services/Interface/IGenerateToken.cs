using ContaPlusAPI.Models;

namespace ContaPlusAPI.Services.Interface
{
    public interface IGenerateToken
    {
        public string GenerateAccessToken(User user);
        public RefreshToken GenerateRefreshToken();
    }
}
