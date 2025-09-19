using tdlimoveis.Models;
using tdlimoveis.Repository;

namespace tdlimoveis.Services
{
  public class PropertyService : IPropertyService
  {
    private readonly IPropertyRepository _propertyRepository;
    private readonly IOwnerRepository _ownerRepository;
    public PropertyService(IPropertyRepository propertyRepository, IOwnerRepository ownerRepository)
    {
      _propertyRepository = propertyRepository;
      _ownerRepository = ownerRepository;
    }
    public async Task<ServiceResult<Property>> CreatePropertyAsync(int id, Property property)
    {
      try
      {
        var owner = await _ownerRepository.GetOwnerByIdAsync(id);

        if (owner == null)
          return ServiceResult<Property>.Fail("Proprietário não encontrado.");

        property.OwnerId = id;

        await _propertyRepository.CreateAsync(property);

        return ServiceResult<Property>.Success(property);
      }
      catch (Exception ex)
      {
        return ServiceResult<Property>.Fail($"Erro ao criar imóvel para proprietário: {ex.Message}");
      }
    }

    public async Task<ServiceResult<List<Property>>> GetPropertiesByOwnerIdAsync(int id)
    {
      try
      {
        if (id == null)
          return ServiceResult<List<Property>>.Fail("O id do proprietário não pode ser nulo!");

        var properties = await _propertyRepository.GetPropertyByOwnerIdAsync(id);

        return ServiceResult<List<Property>>.Success(properties);
      }
      catch (Exception ex)
      {
        return ServiceResult<List<Property>>.Fail($"Erro ao buscar imóveis de proprietário: {ex.Message}");
      }
    }
  }
}
