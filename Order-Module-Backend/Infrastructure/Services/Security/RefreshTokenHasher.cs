using Application.Services.Security;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Services.Security
{
    public class RefreshTokenHasher : IRefreshTokenHasher
    {
        public string Hash(string refreshToken)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(refreshToken));
            return Convert.ToHexString(bytes);
        }
    }
}
