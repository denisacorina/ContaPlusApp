namespace ContaPlusAPI.Interfaces.IRepository
{
    public interface IPhotosRepository
    {
        Task<byte[]> GetPictureAsync(string fileName);
        Task<string> UploadPictureAsync(string fileName, byte[] picture);
        Task<bool> DeletePictureAsync(string fileName);
    }
}

