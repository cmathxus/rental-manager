using tdlimoveis.Models;

namespace tdlimoveis.Repository
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