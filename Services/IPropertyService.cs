using tdlimoveis.Dtos;
using tdlimoveis.Models;

namespace tdlimoveis.Services
{
  public interface IPropertyService
  {
    Task<ServiceResult<PropertyReadDto>> CreatePropertyAsync(int id, PropertyCreateDto property);
    Task<ServiceResult<List<PropertyReadDto>>> GetPropertiesByOwnerIdAsync(int id);
  }
}