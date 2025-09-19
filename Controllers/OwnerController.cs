using System;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using tdlimoveis.Services;
using tdlimoveis.Dtos;

namespace tdlimoveis.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class OwnerController : ControllerBase
  {
    private readonly IOwnerService _ownerService;

    public OwnerController(IOwnerService ownerService)
    {
      _ownerService = ownerService;
    }

    [HttpPost("/owners")]
    public async Task<IActionResult> CreateOwner([FromBody] OwnerCreateDto owner)
    {
      var result = await _ownerService.AddAsync(owner);

      if (!result.Result)
        return BadRequest(result.Message);

      return Ok(result.Data);
    }

    [HttpGet("/owners")]
    public async Task<IActionResult> ReadOwners()
    {
      var result = await _ownerService.GetAllAsync();

      if (!result.Result)
        return BadRequest(result.Message);

      return Ok(result.Data);
    }

    [HttpPut("/owners/{id}")]
    public async Task<IActionResult> UpdateOwner(int id, [FromBody] OwnerCreateDto updatedOwner)
    {
      var result = await _ownerService.UpdateAsync(id, updatedOwner);

      if (!result.Result)
        return BadRequest(result.Message);

      return Ok(result.Data);
    }


    [HttpDelete("/owners/{id}")]
    public async Task<IActionResult> RemoveOwner(int id)
    {
      var result = await _ownerService.RemoveAsync(id);

      if (!result.Result)
        return BadRequest(result.Message);

      return Ok(result.Data);
    }
  }
}