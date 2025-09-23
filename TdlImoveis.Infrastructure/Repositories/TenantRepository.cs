using Microsoft.EntityFrameworkCore;
using tdlimoveis.Domain.Entities;
using tdlimoveis.Domain.Interfaces;

namespace tdlimoveis.Infrastructure.Persistence.Repositories
{
  public class TenantRepository : ITenantRepository
  {
    private readonly TdlContext _context;

    public TenantRepository(TdlContext context)
    {
      _context = context;
    }

    public async Task AddAsync(Tenant tenant)
    {
      _context.Tenants.Add(tenant);
      await _context.SaveChangesAsync();
    }
    public async Task<Tenant> GetTenantById(int id)
    {
      return await _context.Tenants.FindAsync(id);
    }
    public async Task UpdateAsync(Tenant tenant)
    {
      _context.Tenants.Update(tenant);
      await _context.SaveChangesAsync();
    }
    public async Task RemoveAsync(Tenant tenant)
    {
      _context.Tenants.Remove(tenant);
      await _context.SaveChangesAsync();
    }
  }
}