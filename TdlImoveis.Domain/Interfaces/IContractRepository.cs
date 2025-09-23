using tdlimoveis.Domain.Entities;

namespace tdlimoveis.Domain.Interfaces
{
  public interface IContractRepository
  {
    Task AddAsync(Contract contract);
    Task<List<Contract>> GetContractsByPropertyIdAsync(int id);
    Task UpdateAsync(Contract owner);
    Task RemoveAsync(Contract contract);
    Task<Contract> GetContractById(int id);
  }
}