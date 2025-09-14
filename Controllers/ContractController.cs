using System;
using Microsoft.AspNetCore.Mvc;
using tdlimoveis.Data;
using tdlimoveis.Models;

namespace tdlimoveis.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class ContractController : Controller
  {
    private readonly TdlContext db;

    public ContractController(TdlContext _context)
    {
      db = _context;
    }

    [HttpPost("create/{tenantId}/{propertyid}")]
    public async Task<IActionResult> CreateContract(int tenantid, int propertyid, [FromBody] Contract contract)
    {
      if (contract == null)
        return BadRequest();
      contract.PropertyId = propertyid;
      contract.TenantId = tenantid;

      db.Add(contract);
      await db.SaveChangesAsync();

      return Ok(contract);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateContract(int contractId, [FromBody] Contract updatedContract)
    {
      if (updatedContract == null)
        return BadRequest();
        
      var contract = await db.Contracts.FindAsync(contractId);
      if (contract == null)
        return NotFound($"Contrato com id {contractId} não encontrado!");

      contract.DataInicio = updatedContract.DataInicio;
      contract.DataFim = updatedContract.DataFim;
      contract.StatusContract = updatedContract.StatusContract;

      await db.SaveChangesAsync();

      return Ok();
    }
  }
}