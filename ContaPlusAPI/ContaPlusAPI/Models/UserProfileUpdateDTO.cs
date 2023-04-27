namespace ContaPlusAPI.Models
{
    public class UserProfileUpdateDTO
    {
        public Guid UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public virtual ICollection<UserCompanyRole>? Roles { get; set; } = new List<UserCompanyRole>();
        public byte[]? ProfilePicture { get; set; }
        public virtual ICollection<Company>? Companies { get; set; } = new List<Company>();

    }
}
