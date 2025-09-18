using tdlimoveis.Models;

namespace tdlimoveis.Repository
{
  public interface IOwnerRepository
  {
    Task AddAsync(Owner owner);
    Task<List<Owner>> ReadAsync();
    Task UpdateAsync(int id, Owner owner);
    Task<Owner> GetOwnerByIdAsync(int id);
  }
}