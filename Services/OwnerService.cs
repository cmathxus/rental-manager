using tdlimoveis.Services;
using tdlimoveis.Models;
using tdlimoveis.Repository;
using System.Data.Common;

namespace tdlimoveis.Services
{
  public class OwnerService : IOwnerService
  {
    private readonly IOwnerRepository _repository;

    public OwnerService(IOwnerRepository repository)
    {
      _repository = repository;
    }

    public async Task<ServiceResult<Owner>> AddAsync(Owner owner)
    {
      if (string.IsNullOrWhiteSpace(owner.Name))
        return ServiceResult<Owner>.Fail("Nome é obrigatório");

      await _repository.AddAsync(owner);

      return ServiceResult<Owner>.Success(owner);
    }

    public async Task<ServiceResult<List<Owner>>> ReadAsync()
    {
      try
      {
        var owners = await _repository.ReadAsync();

        return ServiceResult<List<Owner>>.Success(owners);
      }
      catch (Exception ex)
      {
        return ServiceResult<List<Owner>>.Fail($"Erro ao buscar proprietários: {ex.Message}");
      }
    }

    public async Task<ServiceResult<Owner>> UpdateAsync(int id, Owner updatedOwner)
    {
      if (id <= 0 || updatedOwner.Name == null)
        return ServiceResult<Owner>.Fail($"Id ou nome não podem ser nulos!");

      Owner owner = await _repository.GetOwnerByIdAsync(id);

      owner.Name = updatedOwner.Name;
      owner.Email = updatedOwner.Email;
      owner.DocumentNumber = updatedOwner.DocumentNumber;
      owner.Phone = updatedOwner.Phone;
      owner.BankAccount = updatedOwner.BankAccount;

      await _repository.UpdateAsync(id, updatedOwner);

      return ServiceResult<Owner>.Success(owner);
    }

    public async Task<ServiceResult<Owner>> GetOwnerByIdAsync(int id)
    {
      try
      {
        Owner owner = await _repository.GetOwnerByIdAsync(id);

        return ServiceResult<Owner>.Success(owner);
      }
      catch (Exception ex)
      {
        return ServiceResult<Owner>.Fail($"Erro ao buscar proprietários: {ex.Message}");
      }
    }
  }
}