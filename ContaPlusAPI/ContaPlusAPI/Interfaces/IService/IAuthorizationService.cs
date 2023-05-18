namespace ContaPlusAPI.Interfaces.IService
{
    public interface IAuthorizationService
    {
        Task<bool> IsUserAdmin(Guid companyId, Guid userId);
        Task<bool> IsUserAccountat(Guid companyId, Guid userId);
        Task<bool> IsUserManager(Guid companyId, Guid userId);
    }
}
