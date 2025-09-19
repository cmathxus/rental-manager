using tdlimoveis.Models;

namespace tdlimoveis.Repository
{
  public interface IPropertyRepository
  {
    Task CreateAsync(Property property);
    Task<List<Property>> GetPropertyByOwnerIdAsync(int? id);
    Task RemoveAsync(Property property);
  }
}