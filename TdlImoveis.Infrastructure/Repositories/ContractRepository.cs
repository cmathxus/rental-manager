using System;
using System.Data;
using Microsoft.EntityFrameworkCore;
using tdlimoveis.Domain.Entities;
using tdlimoveis.Domain.Interfaces;

namespace tdlimoveis.Infrastructure.Persistence.Repositories
{
  public class ContractRepository : IContractRepository
  {
    private readonly TdlContext _context;

    public ContractRepository(TdlContext context)
    {
      _context = context;
    }

    public async Task AddAsync(Contract contract)
    {
      await _context.Contracts.AddAsync(contract);
      await _context.SaveChangesAsync();
    }

    public async Task<List<Contract>> GetContractsByPropertyIdAsync(int id)
    {
      return await _context.Contracts
      .Include(i => i.Tenant)
      .Where(x => x.PropertyId == id)
      .ToListAsync();
    }

    public async Task UpdateAsync(Contract contract)
    {
      _context.Contracts.Update(contract);
      await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(Contract contract)
    {
      _context.Contracts.Remove(contract);
      await _context.SaveChangesAsync();
    }

    public async Task<Contract> GetContractById(int id)
    {
      return await _context.Contracts.FindAsync(id);
    }
  }
}