using tdlimoveis.Models;
using tdlimoveis.Services;

namespace tdlimoveis.Services
{
  public interface IOwnerService
  {
    Task<ServiceResult<Owner>> AddAsync(Owner owner);
    Task<ServiceResult<List<Owner>>> GetAllAsync();
    Task<ServiceResult<Owner>> UpdateAsync(int id, Owner owner);
    Task<ServiceResult<Owner>> GetOwnerByIdAsync(int id);
    Task<ServiceResult<Owner>> RemoveAsync(int id);
  }
}