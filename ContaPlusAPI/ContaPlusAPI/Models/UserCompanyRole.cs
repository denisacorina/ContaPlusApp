using System.ComponentModel.DataAnnotations;

namespace ContaPlusAPI.Models
{
    public class UserCompanyRole
    {
        [Key]
        public Guid UserCompanyId { get; set; }
        public virtual User User { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<Role>? Roles { get; set; } = new List<Role>();
    }
}
