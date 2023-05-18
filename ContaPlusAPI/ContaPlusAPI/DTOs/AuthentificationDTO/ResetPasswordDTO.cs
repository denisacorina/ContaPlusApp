namespace ContaPlusAPI.DTOs.AuthentificationDTO
{
    public class ResetPasswordDTO
    {
        public string Email { get; set; }
        public string ResetToken { get; set; }
        public string Password { get; set; }
    }
}
