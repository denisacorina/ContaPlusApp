using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ContaPlusAPI.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public byte[] PaswordHash { get; set; }
        public byte[] PaswordSalt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public virtual ICollection<Role>? Roles { get; set; } = new List<Role>();
        public bool RememberMe { get; set; } = false;
        public byte[]? ProfilePicture { get; set; }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime TokenExpiration { get; set; }
        public virtual ICollection<Company>? Companies { get; set; } = new List<Company>();


    }
}
