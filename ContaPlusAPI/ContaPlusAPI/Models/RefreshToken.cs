using System.Security.Claims;

namespace ContaPlusAPI.Models
{
    public class RefreshToken
    {
        public string Token { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }

    }
}