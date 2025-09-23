using AutoMapper;
using tdlimoveis.Application.DTOs;
using tdlimoveis.Domain.Entities;
using tdlimoveis.Domain.Interfaces;

namespace tdlimoveis.Application.UseCases
{
  public class PropertyService : IPropertyService
  {
    private readonly IPropertyRepository _propertyRepository;
    private readonly IOwnerRepository _ownerRepository;
    private readonly IMapper _mapper;
    public PropertyService(IPropertyRepository propertyRepository, IOwnerRepository ownerRepository, IMapper mapper)
    {
      _propertyRepository = propertyRepository;
      _ownerRepository = ownerRepository;
      _mapper = mapper;
    }
    public async Task<ServiceResult<PropertyReadDto>> CreateAsync(int id, PropertyCreateDto propertyDto)
    {
      try
      {
        var owner = await _ownerRepository.GetOwnerByIdAsync(id);

        if (owner == null)
          return ServiceResult<PropertyReadDto>.Fail("Proprietário não encontrado.");

        var property = _mapper.Map<Property>(propertyDto);

        property.OwnerId = id;

        await _propertyRepository.CreateAsync(property);

        var propertyReadDto = _mapper.Map<PropertyReadDto>(property);

        return ServiceResult<PropertyReadDto>.Success(propertyReadDto);
      }
      catch (Exception ex)
      {
        return ServiceResult<PropertyReadDto>.Fail($"Erro ao criar imóvel para proprietário: {ex.Message}");
      }
    }

    public async Task<ServiceResult<List<PropertyReadDto>>> GetPropertiesByOwnerIdAsync(int id)
    {
      try
      {
        if (id <= 0)
          return ServiceResult<List<PropertyReadDto>>.Fail("O id do proprietário não pode ser nulo!");

        var properties = await _propertyRepository.GetPropertyByOwnerIdAsync(id);

        var propertiesReadDto = _mapper.Map<List<PropertyReadDto>>(properties);

        return ServiceResult<List<PropertyReadDto>>.Success(propertiesReadDto);
      }
      catch (Exception ex)
      {
        return ServiceResult<List<PropertyReadDto>>.Fail($"Erro ao buscar imóveis de proprietário: {ex.Message}");
      }
    }

    public async Task<ServiceResult<PropertyReadDto>> UpdateAsync(int id, PropertyUpdateDto propertyUpdateDto)
    {
      try
      {
        if (id <= 0)
          return ServiceResult<PropertyReadDto>.Fail($"Id:{id} informado inválido!");

        var propertyOld = await _propertyRepository.GetPropertyById(id);

        if (propertyOld == null)
          return ServiceResult<PropertyReadDto>.Fail($"Imóvel de id {id} não encontrado!");

        _mapper.Map(propertyUpdateDto, propertyOld);

        await _propertyRepository.UpdateAsync(propertyOld);

        var propertyReadDto = _mapper.Map<PropertyReadDto>(propertyOld);

        return ServiceResult<PropertyReadDto>.Success(propertyReadDto);
      }
      catch (Exception ex)
      {
        return ServiceResult<PropertyReadDto>.Fail($"Erro ao atualizar dados do imóvel do proprietário. {ex.Message}");
      }
    }

    public async Task<ServiceResult<PropertyReadDto>> RemoveAsync(int id)
    {
      try
      {
        var property = await _propertyRepository.GetPropertyById(id);

        if (property == null)
          return ServiceResult<PropertyReadDto>.Fail($"Imóvel de id {id} não encontrado!");

        await _propertyRepository.RemoveAsync(property);

        var propertiesReadDto = _mapper.Map<PropertyReadDto>(property);

        return ServiceResult<PropertyReadDto>.Success(propertiesReadDto);
      }
      catch (Exception ex)
      {
        return ServiceResult<PropertyReadDto>.Fail($"Erro ao remover imóvel de usuário! {ex.Message}");
      }
    }
  }
}
