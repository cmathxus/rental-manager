using AutoMapper;
using tdlimoveis.Application.DTOs;
using tdlimoveis.Domain.Entities;
using tdlimoveis.ValueObjects;

namespace TdlImoveis.Application.Mappings
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<Owner, OwnerReadDto>()
        .ForMember(dest => dest.DocumentNumber,
          opt => opt.MapFrom(src => src.DocumentNumber.Number));
      CreateMap<OwnerCreateDto, Owner>()
        .ForMember(dest => dest.DocumentNumber, 
          opt => opt.MapFrom(src => new DocumentNumber(src.DocumentNumber)));

      CreateMap<Property, PropertyReadDto>();
      CreateMap<PropertyCreateDto, Property>();
      CreateMap<PropertyUpdateDto, Property>();

      CreateMap<ContractCreateDto, Contract>();
      CreateMap<Contract, ContractReadDto>();

      CreateMap<Tenant, TenantReadDto>()
        .ForMember(dest => dest.DocumentNumber,
          opt => opt.MapFrom(src => src.DocumentNumber.Number)); // ou .Value
      CreateMap<TenantCreateDto, Tenant>()
        .ForMember(dest => dest.DocumentNumber, 
          opt => opt.MapFrom(src => new DocumentNumber(src.DocumentNumber)));

      CreateMap<UserCreateDto, User>();
      CreateMap<User, UserReadDto>();
    }
  }
}