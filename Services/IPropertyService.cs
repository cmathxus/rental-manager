using tdlimoveis.Dtos;
using tdlimoveis.Models;

namespace tdlimoveis.Services
{
  public interface IPropertyService
  {
    Task<ServiceResult<PropertyReadDto>> CreateAsync(int id, PropertyCreateDto propertyCreateDto);
    Task<ServiceResult<List<PropertyReadDto>>> GetPropertiesByOwnerIdAsync(int id);
    Task<ServiceResult<PropertyReadDto>> UpdateAsync(int id, PropertyUpdateDto propertyCreateDto);
    Task<ServiceResult<PropertyReadDto>> RemoveAsync(int id);
  }
}