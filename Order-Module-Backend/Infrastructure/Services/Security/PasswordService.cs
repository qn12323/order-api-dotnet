using Application.Services.Security;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services.Security
{
    public class PasswordService : IPasswordService
    {
        private readonly PasswordHasher<User> _hasher = new();

        public string HashPassword(string password)
            => _hasher.HashPassword(null!, password);

        public bool VerifyPassword(string hashedPassword, string password)
            => _hasher.VerifyHashedPassword(null!, hashedPassword, password)
               == PasswordVerificationResult.Success;
    }
}
