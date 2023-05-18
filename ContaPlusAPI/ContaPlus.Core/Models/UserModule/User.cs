using ContaPlusAPI.Models.CompanyModule;
using System.ComponentModel.DataAnnotations;

namespace ContaPlusAPI.Models.UserModule
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First Name cannot contain digits or special characters.")]
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last Name cannot contain digits or special characters.")]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [RegularExpression(@"^07\d{8}$", ErrorMessage = "Phone number must be in the format '0712345678'.")]
        public string? PhoneNumber { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool RememberMe { get; set; } = false;
        public byte[]? ProfilePicture { get; set; }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime TokenExpiration { get; set; }
        public virtual ICollection<UserCompanyRole>? UserCompanyRoles { get; set; } = new List<UserCompanyRole>();
        public virtual ICollection<Company>? Companies { get; set; } = new List<Company>();
        public string? ResetPasswordToken { get; set; }
        public DateTime? ResetTokenExpiration { get; set; }
    }
}
