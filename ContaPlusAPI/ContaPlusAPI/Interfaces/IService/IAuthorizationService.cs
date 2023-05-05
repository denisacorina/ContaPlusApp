namespace ContaPlusAPI.Interfaces.IService
{
    public interface IAuthorizationService
    {
        Task<bool> IsUserAdmin(Guid companyId);
        Task<bool> IsUserAccountat(Guid companyId);
        Task<bool> IsUserManager(Guid companyId);
    }
}
