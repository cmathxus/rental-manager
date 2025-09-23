using System.Diagnostics.Contracts;
using tdlimoveis.Application.DTOs;

namespace tdlimoveis.Application.UseCases
{
  public interface IContractService
  {
    public Task<ServiceResult<ContractReadDto>> AddAsync(int id, ContractCreateDto contractCreateDto);
    public Task<ServiceResult<List<ContractReadDto>>> GetContractsByPropertyId(int id);
    public Task<ServiceResult<ContractReadDto>> UpdateAsync(int id, ContractCreateDto contractCreateDto);
    public Task<ServiceResult<ContractReadDto>> RemoveAsync(int id);
  }
}