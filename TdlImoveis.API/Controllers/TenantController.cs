using Microsoft.AspNetCore.Authorization;
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

    [Authorize]
    [HttpPost("/tenants")]
    public async Task<IActionResult> CreateTenant([FromBody] TenantCreateDto tenantCreateDto)
    {
      var result = await _service.AddAsync(tenantCreateDto);

      if (!result.Result)
        return BadRequest(result.Message);

      return Ok(result.Data);
    }

    [Authorize]
    [HttpGet("/tenants")]
    public async Task<IActionResult> GetTenants()
    {
      var result = await _service.GetTenants();

      if (!result.Result)
        return BadRequest(result.Message);

      return Ok(result.Data);
    }

    [Authorize]
    [HttpPut("/tenants/{tenantId}")]
    public async Task<IActionResult> UpdateTenant(int tenantId, [FromBody] TenantCreateDto tenantCreateDto)
    {
      var result = await _service.UpdateAsync(tenantId, tenantCreateDto);

      if (!result.Result)
        return BadRequest(result.Message);

      return Ok(result.Data);
    }

    [Authorize]
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