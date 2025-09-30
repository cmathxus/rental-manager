using tdlimoveis.Domain.Entities;
using tdlimoveis.Domain.Interfaces;

namespace tdlimoveis.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly TdlContext _context;

    public UserRepository(TdlContext context)
    {
        _context = context;
    }

    public async Task AddAsync(User user)
    {
        await _context.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return _context.Users.FirstOrDefault(u => u.Username == username);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return _context.Users.FirstOrDefault(u => u.Email == email);
    }
}