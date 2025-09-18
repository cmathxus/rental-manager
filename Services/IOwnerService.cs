using tdlimoveis.Models;
using tdlimoveis.Services;

namespace tdlimoveis.Services
{
  public interface IOwnerService
  {
    Task<ServiceResult<Owner>> AddAsync(Owner owner);
    Task<ServiceResult<List<Owner>>> ReadAsync();
    Task<ServiceResult<Owner>> UpdateAsync(int id, Owner owner);
    Task<ServiceResult<Owner>> GetOwnerByIdAsync(int id);
  }
}