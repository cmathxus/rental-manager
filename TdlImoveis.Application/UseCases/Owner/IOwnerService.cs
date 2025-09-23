using tdlimoveis.Application.DTOs;
using tdlimoveis.Domain.Entities;
using tdlimoveis.Application.UseCases;

namespace tdlimoveis.Application.UseCases
{
  public interface IOwnerService
  {
    Task<ServiceResult<OwnerReadDto>> AddAsync(OwnerCreateDto owner);
    Task<ServiceResult<List<OwnerReadDto>>> GetAllAsync();
    Task<ServiceResult<OwnerReadDto>> UpdateAsync(int id, OwnerCreateDto owner);
    Task<ServiceResult<OwnerReadDto>> GetOwnerByIdAsync(int id);
    Task<ServiceResult<OwnerReadDto>> RemoveAsync(int id);
  }
}