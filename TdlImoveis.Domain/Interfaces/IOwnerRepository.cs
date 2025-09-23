using tdlimoveis.Domain.Entities;

namespace tdlimoveis.Domain.Interfaces
{
  public interface IOwnerRepository
  {
    Task AddAsync(Owner owner);
    Task<List<Owner>> GetAllAsync();
    Task UpdateAsync(Owner owner);
    Task<Owner> GetOwnerByIdAsync(int id);
    Task RemoveAsync(Owner owner);
  }
}