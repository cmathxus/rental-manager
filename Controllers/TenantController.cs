using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using tdlimoveis.Data;
using tdlimoveis.Models;

namespace tdlimoveis.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class TenantController : Controller
  {
    private readonly TdlContext db;

    public TenantController(TdlContext _context)
    {
      db = _context;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateTenant(Tenant tenant)
    {
      if (tenant == null)
        return BadRequest();

      db.Add(tenant);

      await db.SaveChangesAsync();

      return Ok(tenant);
    }

    [HttpPut("update/{tenantId}")]
    public async Task<IActionResult> UpdateTenant(int tenantId, [FromBody] Tenant updatedTenant)
    {
      var tenant = await db.Tenants.FindAsync(tenantId);
      if (tenant == null)
        return NotFound($"Inquilino de id {tenantId} não encontrado!");

      tenant.Email = updatedTenant.Email;
      tenant.Phone = updatedTenant.Phone;

      await db.SaveChangesAsync();

      return Ok();
    }

    [HttpDelete("delete/{tenantId}")]
    public async Task<IActionResult> DeleteTenant(int tenantId)
    {
      var tenant = await db.Tenants.FindAsync(tenantId);

      if (tenant == null)
        return NotFound($"Inquilino de id {tenantId} não encontrado");

      db.Tenants.Remove(tenant);

      await db.SaveChangesAsync();
      return Ok();
    }

    [HttpGet("listContracts/{tenantId}")]
    public async Task<IActionResult> ReadContracts(int tenantId)
    {
      var tenant = await db.Tenants.FindAsync(tenantId);
      if (tenant == null)
        return NotFound($"Inquilino com id {tenantId} não encontrado.");

      var contratos = db.Contracts
          .Where(x => x.TenantId == tenant.Id)
          .ToList();

      return Ok(contratos);
    }
  }
}