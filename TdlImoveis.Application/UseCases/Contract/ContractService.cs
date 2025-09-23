using AutoMapper;
using tdlimoveis.Application.DTOs;
using tdlimoveis.Domain.Entities;
using tdlimoveis.Domain.Interfaces;
using tdlimoveis.Application.UseCases;

namespace tdlimoveis.Application.UseCases
{
  public class ContractService : IContractService
  {
    private readonly IContractRepository _repository;
    private readonly IMapper _mapper;

    public ContractService(IContractRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<ServiceResult<ContractReadDto>> AddAsync(int id, ContractCreateDto contractCreateDto)
    {
      try
      {
        if (contractCreateDto == null)
          return ServiceResult<ContractReadDto>.Fail($"O contrato informado está inválido");

        var contract = _mapper.Map<Contract>(contractCreateDto);

        contract.PropertyId = id;

        await _repository.AddAsync(contract);

        var contractReadDto = _mapper.Map<ContractReadDto>(contract);

        return ServiceResult<ContractReadDto>.Success(contractReadDto);
      }
      catch (Exception ex)
      {
        return ServiceResult<ContractReadDto>.Fail($"Não foi possivel adicionar o contrato! {ex.Message}");
      }
    }

    public async Task<ServiceResult<List<ContractReadDto>>> GetContractsByPropertyId(int id)
    {
      try
      {
        if (id <= 0)
          return ServiceResult<List<ContractReadDto>>.Fail("Id informado inválido!");

        var contracts = await _repository.GetContractsByPropertyIdAsync(id);

        if (contracts == null)
          return ServiceResult<List<ContractReadDto>>.Fail("Nenhum contrato encontrado!");

        var contractReadDto = _mapper.Map<List<ContractReadDto>>(contracts);

        return ServiceResult<List<ContractReadDto>>.Success(contractReadDto);
      }
      catch (Exception ex)
      {
        return ServiceResult<List<ContractReadDto>>.Fail($"Não foi possivel listar os contratos do proprietário de id {id} {ex.Message}");
      }
    }
    public async Task<ServiceResult<ContractReadDto>> UpdateAsync(int id, ContractCreateDto contractCreateDto)
    {
      try
      {
        if (id <= 0)
          return ServiceResult<ContractReadDto>.Fail("Id informado inválido!");

        var contract = _repository.GetContractById(id);

        if (contract == null)
          return ServiceResult<ContractReadDto>.Fail($"Contrato de id {id} não encontrado!");

        var contractUpdated = _mapper.Map<Contract>(contractCreateDto);

        await _mapper.Map(contractUpdated, contract);

        var contractReadDto = _mapper.Map<ContractReadDto>(contract);

        return ServiceResult<ContractReadDto>.Success(contractReadDto);
      }
      catch (Exception ex)
      {
        return ServiceResult<ContractReadDto>.Fail($"Não foi possivel atualizar o contrato de id {id} {ex.Message}");
      }
    }
    public async Task<ServiceResult<ContractReadDto>> RemoveAsync(int id)
    {
      try
      {
        if (id <= 0)
          return ServiceResult<ContractReadDto>.Fail($"Id informado inválido!");

        var contract = await _repository.GetContractById(id);

        if (contract == null)
          return ServiceResult<ContractReadDto>.Fail($"Contrato de id {id} não encontrado!");

        await _repository.RemoveAsync(contract);

        var contractReadDto = _mapper.Map<ContractReadDto>(contract);

        return ServiceResult<ContractReadDto>.Success(contractReadDto);
      }
      catch (Exception ex)
      {
        return ServiceResult<ContractReadDto>.Fail($"Nao foi possivel excluir o contrato informado! {ex.Message}");
      }
    }
  }
}