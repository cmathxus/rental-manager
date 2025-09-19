using AutoMapper;
using tdlimoveis.Dtos;
using tdlimoveis.Models;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    CreateMap<Owner, OwnerReadDto>();
    CreateMap<OwnerCreateDto, Owner>();
    
    CreateMap<Property, PropertyReadDto>();
    CreateMap<PropertyCreateDto, Property>();
  }
}