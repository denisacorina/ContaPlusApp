using ContaPlusAPI.Context;
using ContaPlusAPI.Interfaces.IRepository;

namespace ContaPlusAPI.Repositories
{
    public class SaveChangesRepository : ISaveChangesRepository
    {
        private readonly AppDbContext _context;

        public SaveChangesRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
