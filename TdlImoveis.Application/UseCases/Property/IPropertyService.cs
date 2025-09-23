using tdlimoveis.Application.DTOs;

namespace tdlimoveis.Application.UseCases
{
  public interface IPropertyService
  {
    Task<ServiceResult<PropertyReadDto>> CreateAsync(int id, PropertyCreateDto propertyCreateDto);
    Task<ServiceResult<List<PropertyReadDto>>> GetPropertiesByOwnerIdAsync(int id);
    Task<ServiceResult<PropertyReadDto>> UpdateAsync(int id, PropertyUpdateDto propertyCreateDto);
    Task<ServiceResult<PropertyReadDto>> RemoveAsync(int id);
  }
}