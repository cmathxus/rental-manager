using Microsoft.AspNetCore.Mvc;
using tdlimoveis.Application.DTOs;
using tdlimoveis.Application.UseCases;

namespace tdlimoveis.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ContractController : ControllerBase
  {
    private readonly IContractService _service;

    public ContractController(IContractService service)
    {
      _service = service;
    }

    [HttpPost("/{propertyId}/contracts")]
    public async Task<IActionResult> AddContract(int propertyId, [FromBody] ContractCreateDto contract)
    {
      var result = await _service.AddAsync(propertyId, contract);

      if (!result.Result)
        return BadRequest(result.Message);

      return Ok(result.Data);
    }

    [HttpGet("/{propertyId}/contracts")]
    public async Task<IActionResult> GetContracts(int propertyId)
    {
      var result = await _service.GetContractsByPropertyId(propertyId);

      if (!result.Result)
        return BadRequest(result.Message);

      return Ok(result.Data);
    }

    [HttpPut("/contracts/{contractId}")]
    public async Task<IActionResult> UpdateContract(int contractId, [FromBody] ContractCreateDto contract)
    {
      var result = await _service.UpdateAsync(contractId, contract);

      if (!result.Result)
        return BadRequest(result.Message);

      return Ok(result.Data);
    }

    [HttpDelete("/contracts/{contractId}")]
    public async Task<IActionResult> RemoveContract(int contractId)
    {
      var result = await _service.RemoveAsync(contractId);

      if (!result.Result)
        return BadRequest(result.Message);

      return Ok(result.Data);
    }
  }
}