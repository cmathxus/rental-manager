using tdlimoveis.Application.DTOs;

namespace tdlimoveis.Application.UseCases
{
  public interface ITenantService
  {
    public Task<ServiceResult<TenantReadDto>> AddAsync(int id, TenantCreateDto tenantCreateDto);
    public Task<ServiceResult<TenantReadDto>> UpdateAsync(int id, TenantCreateDto tenantCreateDto);
    public Task<ServiceResult<TenantReadDto>> RemoveAsync(int id);
  }
}