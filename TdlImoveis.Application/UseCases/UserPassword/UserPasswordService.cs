using Microsoft.AspNetCore.Identity;
using tdlimoveis.Domain.Entities;

namespace TdlImoveis.Application.UseCases
{
    public class UserPasswordService : IUserPasswordService
    {
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserPasswordService(IPasswordHasher<User> passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public string HashPassword(User user, string password)
        {
            return _passwordHasher.HashPassword(user, password);
        }

        public bool VerifyPassword(User user, string hashedPassword, string providedPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(user, hashedPassword, providedPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}