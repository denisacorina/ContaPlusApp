namespace ContaPlusAPI.Services.Interface
{
    public interface IPasswordHash
    {
        public void HashPassword(string password, out byte[] passwordHash, out byte[] passwordSalt);
        public bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt);
    }
}
