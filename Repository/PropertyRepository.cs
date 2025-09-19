using Microsoft.EntityFrameworkCore;
using tdlimoveis.Data;
using tdlimoveis.Models;

namespace tdlimoveis.Repository
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

    public async Task RemoveAsync(Property property)
    {
      _context.Properties.Remove(property);
      await _context.SaveChangesAsync();
    }
  }
}