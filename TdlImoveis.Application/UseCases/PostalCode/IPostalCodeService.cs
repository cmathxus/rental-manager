using tdlimoveis.Application.DTOs;
using tdlimoveis.Application.UseCases;

namespace TdlImoveis.Application.UseCases.PostalCode;

public interface IPostalCodeService
{
    public Task<ServiceResult<PostalCodeDto>> AddressByPostalCode(PostalCodeRequest postalCode);
}