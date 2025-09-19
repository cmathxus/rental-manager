using AutoMapper;
using tdlimoveis.Dtos;
using tdlimoveis.Models;
using tdlimoveis.Repository;

namespace tdlimoveis.Services
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
    public async Task<ServiceResult<PropertyReadDto>> CreatePropertyAsync(int id, PropertyCreateDto propertyDto)
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
  }
}
