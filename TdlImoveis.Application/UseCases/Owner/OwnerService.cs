using tdlimoveis.Domain.Entities;
using tdlimoveis.Application.DTOs;
using AutoMapper;
using tdlimoveis.Domain.Interfaces;

namespace tdlimoveis.Application.UseCases
{
  public class OwnerService : IOwnerService
  {
    private readonly IOwnerRepository _repository;
    private readonly IMapper _mapper;

    public OwnerService(IOwnerRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<ServiceResult<OwnerReadDto>> AddAsync(OwnerCreateDto ownerDto)
    {
      if (string.IsNullOrWhiteSpace(ownerDto.Name))
        return ServiceResult<OwnerReadDto>.Fail("Nome é obrigatório");

      var owner = _mapper.Map<Owner>(ownerDto);

      await _repository.AddAsync(owner);

      var ownerReadDto = _mapper.Map<OwnerReadDto>(owner);
      return ServiceResult<OwnerReadDto>.Success(ownerReadDto);
    }

    public async Task<ServiceResult<List<OwnerReadDto>>> GetAllAsync()
    {
      try
      {
        var owners = await _repository.GetAllAsync();

        var ownerDtos = _mapper.Map<List<OwnerReadDto>>(owners);

        return ServiceResult<List<OwnerReadDto>>.Success(ownerDtos);
      }
      catch (Exception ex)
      {
        return ServiceResult<List<OwnerReadDto>>.Fail($"Erro ao buscar proprietários: {ex.Message}");
      }
    }

    public async Task<ServiceResult<OwnerReadDto>> UpdateAsync(int id, OwnerCreateDto updatedOwnerDto)
    {
      if (id <= 0 || updatedOwnerDto.Name == null)
        return ServiceResult<OwnerReadDto>.Fail($"Id ou nome não podem ser nulos!");

      Owner owner = await _repository.GetOwnerByIdAsync(id);
      if (owner == null)
        return ServiceResult<OwnerReadDto>.Fail("Proprietário não encontrado.");

      _mapper.Map(updatedOwnerDto, owner);

      await _repository.UpdateAsync(owner);

      var ownerReadDto = _mapper.Map<OwnerReadDto>(owner);

      return ServiceResult<OwnerReadDto>.Success(ownerReadDto);
    }

    public async Task<ServiceResult<OwnerReadDto>> GetOwnerByIdAsync(int id)
    {
      try
      {
        Owner owner = await _repository.GetOwnerByIdAsync(id);

        if (owner == null)
          return ServiceResult<OwnerReadDto>.Fail("Proprietário não encontrado.");

        var ownerReadDto = _mapper.Map<OwnerReadDto>(owner);

        return ServiceResult<OwnerReadDto>.Success(ownerReadDto);
      }
      catch (Exception ex)
      {
        return ServiceResult<OwnerReadDto>.Fail($"Erro ao buscar proprietários: {ex.Message}");
      }
    }

    public async Task<ServiceResult<OwnerReadDto>> RemoveAsync(int id)
    {
      try
      {
        if (id <= 0)
          return ServiceResult<OwnerReadDto>.Fail($"Id inválido!");

        var owner = await _repository.GetOwnerByIdAsync(id);

        if (owner == null)
          return ServiceResult<OwnerReadDto>.Fail("Proprietário não encontrado.");


        await _repository.RemoveAsync(owner);

        var ownerReadDto = _mapper.Map<OwnerReadDto>(owner);

        return ServiceResult<OwnerReadDto>.Success(ownerReadDto);
      }
      catch (Exception ex)
      {
        return ServiceResult<OwnerReadDto>.Fail($"Erro ao remover proprietário: {ex.Message}");
      }
    }
  }
}