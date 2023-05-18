namespace ContaPlusAPI.Interfaces.IService
{
    public interface IPhotoService
    {
        Task<byte[]> GetPictureAsync(string fileName);
        Task<string> UploadPictureAsync(string fileName, byte[] picture, string pictureType, Guid referenceId);
        Task<bool> DeletePictureAsync(string fileName);
    }
}
