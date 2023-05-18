namespace ContaPlusAPI.Models.Authentification
{
    public class RefreshToken
    {
        public string Token { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
