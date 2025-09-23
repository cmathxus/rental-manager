using tdlimoveis.Domain.Entities;

namespace tdlimoveis.Domain.Interfaces
{
  public interface IPropertyRepository
  {
    Task CreateAsync(Property property);
    Task<List<Property>> GetPropertyByOwnerIdAsync(int id);
    Task<Property> GetPropertyById(int id);
    Task UpdateAsync(Property property);
    Task RemoveAsync(Property property);
  }
}