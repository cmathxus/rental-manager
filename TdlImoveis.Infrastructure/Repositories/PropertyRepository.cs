using Microsoft.EntityFrameworkCore;
using tdlimoveis.Domain.Entities;
using tdlimoveis.Domain.Interfaces;

namespace tdlimoveis.Infrastructure.Persistence.Repositories
{
  public class PropertyRepository : IPropertyRepository
  {
    private readonly TdlContext _context;

    public PropertyRepository(TdlContext context)
    {
      _context = context;
    }

    public async Task CreateAsync(Property property)
    {
      await _context.Properties.AddAsync(property);
      await _context.SaveChangesAsync();
    }

    public async Task<List<Property>> GetPropertyByOwnerIdAsync(int id)
    {
      return await _context.Properties
      .Include(p => p.Owner)
      .Where(x => x.OwnerId == id)
      .ToListAsync();
    }

    public async Task<Property> GetPropertyById(int id)
    {
      return await _context.Properties
      .FindAsync(id);
    }

    public async Task UpdateAsync(Property property)
    {
      _context.Properties.Update(property);
      await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(Property property)
    {
      _context.Properties.Remove(property);
      await _context.SaveChangesAsync();
    }
  }
}