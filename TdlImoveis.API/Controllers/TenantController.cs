using Microsoft.AspNetCore.Mvc;
using tdlimoveis.Application.DTOs;
using tdlimoveis.Application.UseCases;

namespace tdlimoveis.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class TenantController : ControllerBase
  {
    private readonly ITenantService _service;

    public TenantController(ITenantService service)
    {
      _service = service;
    }

    [HttpPost("/{contractId}/tenants")]
    public async Task<IActionResult> CreateTenant(int contractId, [FromBody] TenantCreateDto tenantCreateDto)
    {
      var result = await _service.AddAsync(contractId, tenantCreateDto);

      if (!result.Result)
        return BadRequest(result.Message);

      return Ok(result.Data);
    }

    [HttpPut("/tenants/{tenantId}")]
    public async Task<IActionResult> UpdateTenant(int tenantId, [FromBody] TenantCreateDto tenantCreateDto)
    {
      var result = await _service.UpdateAsync(tenantId, tenantCreateDto);

      if (!result.Result)
        return BadRequest(result.Message);

      return Ok(result.Data);
    }

    [HttpDelete("/tenants/{tenantId}")]
    public async Task<IActionResult> RemoveTenant(int tenantId)
    {
      var result = await _service.RemoveAsync(tenantId);

      if (!result.Result)
        return BadRequest(result.Message);

      return Ok(result.Data);
    }
  }
}