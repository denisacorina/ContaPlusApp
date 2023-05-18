namespace ContaPlusAPI.DTOs.AuthentificationDTO
{
    public class LoginUserDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; } = false;
    }
}
