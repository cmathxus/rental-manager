using tdlimoveis.Models;

namespace tdlimoveis.Services
{
  public interface IPropertyService
  {
    Task<ServiceResult<Property>> CreatePropertyAsync(int id, Property property);
    Task<ServiceResult<List<Property>>> GetPropertiesByOwnerIdAsync(int id);
  }
}