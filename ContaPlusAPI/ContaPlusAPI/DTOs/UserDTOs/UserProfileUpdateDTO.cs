using ContaPlusAPI.Models.CompanyModule;

namespace ContaPlusAPI.DTOs.UserDTOs
{
    public class UserProfileUpdateDTO
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public virtual ICollection<UserCompanyRole>? Roles { get; set; } = new List<UserCompanyRole>();
        public string? PhoneNumber { get; set; }
        public virtual ICollection<Company>? Companies { get; set; } = new List<Company>();
    }
}
