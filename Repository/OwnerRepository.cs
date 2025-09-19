using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using tdlimoveis.Data;
using tdlimoveis.Dtos;
using tdlimoveis.Models;

namespace tdlimoveis.Repository
{
  public class OwnerRepository : IOwnerRepository
  {
    private readonly TdlContext _context;

    public OwnerRepository(TdlContext context)
    {
      _context = context;
    }
    public async Task AddAsync(Owner owner)
    {
      _context.Owners.Add(owner);
      await _context.SaveChangesAsync();
    }

    public async Task<List<Owner>> GetAllAsync()
    {
      return await _context.Owners
      .OrderBy(x => x.Name)
      .ToListAsync();
    }

    public async Task UpdateAsync(Owner owner)
    {
      _context.Owners.Add(owner);
      await _context.SaveChangesAsync();
    }

    public async Task<Owner> GetOwnerByIdAsync(int id)
    {
      return await _context.Owners.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task RemoveAsync(Owner owner)
    {
      _context.Owners.Remove(owner);
      await _context.SaveChangesAsync();
    }
   }
}