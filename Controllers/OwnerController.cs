using System;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using tdlimoveis.Services;
using tdlimoveis.Models;

namespace tdlimoveis.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class OwnerController : Controller
  {
    private readonly IOwnerService _ownerService;

    public OwnerController(IOwnerService ownerService)
    {
      _ownerService = ownerService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateOwner([FromBody] Owner owner)
    {
      var result = await _ownerService.AddAsync(owner);

      if (!result.Result)
        return BadRequest(result.Message);

      return Ok(result.Data);
    }

    [HttpGet("read")]
    public async Task<IActionResult> ReadOwners()
    {
      var result = await _ownerService.ReadAsync();

      if (!result.Result)
        return BadRequest(result.Message);

      return Ok(result.Data);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateOwner(int id, [FromBody] Owner updatedOwner)
    {
      var result = await _ownerService.UpdateAsync(id, updatedOwner);
      
      if (!result.Result)
        return BadRequest(result.Message);

      return Ok(result.Data);
    }
  }
}