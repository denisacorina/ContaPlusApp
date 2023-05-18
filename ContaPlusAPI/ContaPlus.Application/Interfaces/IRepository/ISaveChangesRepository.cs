namespace ContaPlusAPI.Interfaces.IRepository
{
    public interface ISaveChangesRepository
    {
        Task<int> SaveChanges();
    }
}
