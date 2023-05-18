using ContaPlusAPI.Models.CompanyModule;
using System.ComponentModel.DataAnnotations;

namespace ContaPlusAPI.Models.UserModule
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<UserCompanyRole>? Roles { get; set; } = new List<UserCompanyRole>();
    }
}
