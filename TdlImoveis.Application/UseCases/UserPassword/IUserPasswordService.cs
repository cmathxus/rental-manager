using tdlimoveis.Domain.Entities;

namespace TdlImoveis.Application.UseCases
{
    public interface IUserPasswordService
    {
        string HashPassword(User user, string password);
        bool VerifyPassword(User user, string hashedPassword, string providedPassword);
    }
}