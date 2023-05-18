using ContaPlusAPI.Context;
using ContaPlusAPI.Interfaces.IRepository;
using ContaPlusAPI.Interfaces.IService;
using ContaPlusAPI.Models.UserModule;

namespace ContaPlusAPI.Repositories
{
    public class PhotoRepository : IPhotosRepository
    {
        private readonly AppDbContext _context;
        private readonly ISaveChangesRepository _saveChangesRepository;
        private readonly IUserService _userService;

        public PhotoRepository(AppDbContext context, ISaveChangesRepository saveChangesRepository, IUserService userService)
        {
            _context = context;
            _saveChangesRepository = saveChangesRepository;
            _userService = userService;
        }
        public async Task<byte[]> GetPictureAsync(string fileName)
        {
            if (fileName.StartsWith("user_"))
            {
                var userId = new Guid(fileName.Substring(5));
                var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
                if (user != null && user.ProfilePicture != null)
                {
                    return await Task.FromResult(user.ProfilePicture);
                }
            }
            else if (fileName.StartsWith("company_"))
            {
                var companyId = new Guid(fileName.Substring(8));
                var company = _context.Companies.FirstOrDefault(c => c.CompanyId == companyId);
                if (company != null && company.Logo != null && fileName.EndsWith("_photo"))
                {
                    return await Task.FromResult(company.Logo);
                }
                else if (company != null && company.Signature != null && fileName.EndsWith("_signature"))
                {
                    return await Task.FromResult(company.Signature);
                }
            }
            return null;
        }

        public async Task<string> UploadPictureAsync(string fileName, byte[] picture)
        {
            if (fileName.StartsWith("user_"))
            {
                var userId = new Guid(fileName.Substring(5));
                var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
                if (user != null)
                {
                    user.ProfilePicture = picture;
                    await _saveChangesRepository.SaveChanges();
                    return fileName;
                }
            }
            else if (fileName.StartsWith("company"))
            {
                var companyId = new Guid(fileName.Substring(8));
                var company = _context.Companies.FirstOrDefault(c => c.CompanyId == companyId);
                if (company != null && fileName.EndsWith("_photo"))
                {
                    company.Logo = picture;
                    await _saveChangesRepository.SaveChanges();
                    return fileName;
                }
                else if (company != null && fileName.EndsWith("_signature"))
                {
                    company.Signature = picture;
                    await _saveChangesRepository.SaveChanges();
                    return fileName;
                }
            }
            throw new ArgumentException("Invalid file name.");
        }

        public async Task<bool> DeletePictureAsync(string fileName)
        {
            if (fileName.StartsWith("user_"))
            {
                var userId = new Guid(fileName.Substring(5));
                var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
                if (user != null)
                {
                    user.ProfilePicture = null;
                    await _saveChangesRepository.SaveChanges();
                    return true;
                }
            }
            else if (fileName.StartsWith("company_"))
            {
                var companyId = new Guid(fileName.Substring(8));
                var company = _context.Companies.FirstOrDefault(c => c.CompanyId == companyId);
                if (company != null && fileName.EndsWith("_photo"))
                {
                    company.Logo = null;
                    await _saveChangesRepository.SaveChanges();
                    return true;
                }
                else if (company != null && fileName.EndsWith("_signature"))
                {
                    company.Signature = null;
                    await _saveChangesRepository.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}

