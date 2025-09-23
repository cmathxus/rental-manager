using tdlimoveis.Domain.Entities;

namespace tdlimoveis.Domain.Interfaces
{
  public interface ITenantRepository
  {
    public Task AddAsync(Tenant tenant);
    public Task<Tenant> GetTenantById(int id);
    public Task UpdateAsync(Tenant tenant);
    public Task RemoveAsync(Tenant tenant);
  }
}