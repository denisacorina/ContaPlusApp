using ContaPlusAPI.Interfaces.IRepository;
using ContaPlusAPI.Interfaces.IService;
using ContaPlusAPI.Repositories;

namespace ContaPlusAPI.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotosRepository _photoRepository;
        private readonly IUserService _userService;
        private readonly ICompanyService _companyService;
        private readonly ISaveChangesRepository _saveChangesRepository;
        public PhotoService(IPhotosRepository photoRepository, IUserService userService, ISaveChangesRepository saveChangesRepository, ICompanyService companyService)
        {
            _photoRepository = photoRepository;
            _userService = userService;
            _saveChangesRepository = saveChangesRepository;
            _companyService = companyService;
        }

        public async Task<byte[]> GetPictureAsync(string fileName)
        {
            return await _photoRepository.GetPictureAsync(fileName);
        }

        public async Task<string> UploadPictureAsync(string fileName, byte[] picture, string pictureType, Guid referenceId)
        {
            switch (pictureType)
            {
                case "user":
                    var user = await _userService.GetUserById(referenceId);
                    if (user != null)
                    {
                        user.ProfilePicture = picture;
                        await _saveChangesRepository.SaveChanges();
                        return fileName;
                    }
                    break;
                case "company_logo":
                    var company = await _companyService.GetCompanyById(referenceId);
                    if (company != null)
                    {
                        company.Logo = picture;
                        await _saveChangesRepository.SaveChanges();
                        return fileName;
                    }
                    break;
                case "company_signature":
                    var companySignature = await _companyService.GetCompanyById(referenceId);
                    if (companySignature != null)
                    {
                        companySignature.Signature = picture;
                        await _saveChangesRepository.SaveChanges();
                        return fileName;
                    }
                    break;
                default:
                    break;
            }

            throw new ArgumentException("Invalid picture type or reference ID.");
        }

        public async Task<bool> DeletePictureAsync(string fileName)
        {
            return await _photoRepository.DeletePictureAsync(fileName);
        }
    }
}

