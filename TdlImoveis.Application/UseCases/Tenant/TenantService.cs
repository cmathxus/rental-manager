using AutoMapper;
using tdlimoveis.Application.DTOs;
using tdlimoveis.Domain.Entities;
using tdlimoveis.Domain.Interfaces;

namespace tdlimoveis.Application.UseCases
{
  public class TenantService : ITenantService
  {
    private readonly ITenantRepository _repository;
    private readonly IMapper _mapper;

    public TenantService(ITenantRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<ServiceResult<TenantReadDto>> AddAsync(TenantCreateDto tenantCreateDto)
    {
      try
      {
        if (tenantCreateDto == null)
          return ServiceResult<TenantReadDto>.Fail($"Inquilino informado inválido!");

        var tenant = _mapper.Map<Tenant>(tenantCreateDto);

        await _repository.AddAsync(tenant);

        var tenantReadDto = _mapper.Map<TenantReadDto>(tenant);

        return ServiceResult<TenantReadDto>.Success(tenantReadDto);
      }
      catch (Exception ex)
      {
        return ServiceResult<TenantReadDto>.Fail($"Falha ao criar o inquilino! {ex.Message}");
      }
    }

    public async Task<ServiceResult<List<TenantReadDto>>> GetTenants()
    {
      try
      {
        var tenants = await _repository.GetTenants();

        if (tenants == null)
          return ServiceResult<List<TenantReadDto>>.Fail($"Não foi possivel carregar a lista de inquilinos!");

        var tenantsReadDto = _mapper.Map<List<TenantReadDto>>(tenants);

        return ServiceResult<List<TenantReadDto>>.Success(tenantsReadDto);
      }
      catch (Exception ex)
      {
        return ServiceResult<List<TenantReadDto>>.Fail($"Não foi possivel carregar a lista de inquilinos! {ex.Message}");
      }
    }
    public async Task<ServiceResult<TenantReadDto>> UpdateAsync(int id, TenantCreateDto tenantCreateDto)
    {
      try
      {
        if (id <= 0)
          return ServiceResult<TenantReadDto>.Fail("Id informado inválido!");

        var tenantOld = _repository.GetTenantById(id);

        if (tenantOld == null)
          return ServiceResult<TenantReadDto>.Fail($"Inquilino de id {id} nao encontrado!");

        var tenantUpdated = _mapper.Map<Tenant>(tenantCreateDto);

        await _mapper.Map(tenantUpdated, tenantOld);

        var tenantReadDto = _mapper.Map<TenantReadDto>(tenantOld);

        return ServiceResult<TenantReadDto>.Success(tenantReadDto);
      }
      catch (Exception ex)
      {
        return ServiceResult<TenantReadDto>.Fail($"Erro ao atualizar o inquilino! {ex.Message}");
      }
    }
    public async Task<ServiceResult<TenantReadDto>> RemoveAsync(int id)
    {
      try
      {
        if (id <= 0)
          return ServiceResult<TenantReadDto>.Fail("Id informado inválido!");

        var tenant = await _repository.GetTenantById(id);

        if (tenant == null)
          return ServiceResult<TenantReadDto>.Fail($"Tenant de id {id} não encontrado!");

        await _repository.RemoveAsync(tenant);

        var tenantReadDto = _mapper.Map<TenantReadDto>(tenant);

        return ServiceResult<TenantReadDto>.Success(tenantReadDto);
      }
      catch (Exception ex)
      {
        return ServiceResult<TenantReadDto>.Fail($"Erro ao remover inquilino! {ex.Message}");
      }
    }
  }
}