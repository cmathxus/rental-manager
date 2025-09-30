using AutoMapper;
using tdlimoveis.Application.DTOs;
using tdlimoveis.Domain.Entities;

namespace TdlImoveis.Application.Mappings
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<Owner, OwnerReadDto>();
      CreateMap<OwnerCreateDto, Owner>();

      CreateMap<Property, PropertyReadDto>();
      CreateMap<PropertyCreateDto, Property>();
      CreateMap<PropertyUpdateDto, Property>();

      CreateMap<ContractCreateDto, Contract>();
      CreateMap<Contract, ContractReadDto>();

      CreateMap<Tenant, TenantReadDto>();
      CreateMap<TenantCreateDto, Tenant>();

      CreateMap<UserCreateDto, User>();
      CreateMap<User, UserReadDto>();
    }
  }
}