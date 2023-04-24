using ContaPlusAPI.Services.Interface;
using System.Security.Cryptography;
using System.Text;

namespace ContaPlusAPI.Services.Repository
{
    public class PasswordHashRepository : IPasswordHash
    {
        public void HashPassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {

            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var ComputeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return ComputeHash.SequenceEqual(passwordHash);
        }
    }
}
