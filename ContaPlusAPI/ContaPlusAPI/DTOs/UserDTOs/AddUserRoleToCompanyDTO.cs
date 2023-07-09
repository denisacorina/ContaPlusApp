namespace ContaPlusAPI.DTOs.UserDTOs
{
    public class AddUserRoleToCompanyDTO
    {
        public Guid UserId { get; set; }
        public int RoleId { get; set; }
        public Guid CompanyId { get; set; }
    }
}
