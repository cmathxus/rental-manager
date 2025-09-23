using System;
using Microsoft.AspNetCore.Mvc;
using tdlimoveis.Application.DTOs;
using tdlimoveis.Application.UseCases;

namespace tdlimoveis.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class PropertyController : ControllerBase
  {

    private readonly IPropertyService _propertyService;

    public PropertyController(IPropertyService propertyService)
    {
      _propertyService = propertyService;
    }

    [HttpPost("/owners/{ownerId}/properties")]
    public async Task<IActionResult> CreateProperty(int ownerId, [FromBody] PropertyCreateDto property)
    {
      var result = await _propertyService.CreateAsync(ownerId, property);

      if (!result.Result)
        return BadRequest(result.Message);

      return Ok(result.Data);
    }

    [HttpGet("/owners/{ownerId}/properties")]
    public async Task<IActionResult> ListProperties(int ownerId)
    {
      var result = await _propertyService.GetPropertiesByOwnerIdAsync(ownerId);

      if (!result.Result)
        return BadRequest(result.Message);

      return Ok(result.Data);
    }

    [HttpPut("/properties/{propertyId}")]
    public async Task<IActionResult> UpdateProperty(int propertyId, [FromBody] PropertyUpdateDto property)
    {
      var result = await _propertyService.UpdateAsync(propertyId, property);

      if (!result.Result)
        return BadRequest(result.Message);

      return Ok(result.Data);
    }

    [HttpDelete("/properties/{propertyId}")]
    public async Task<IActionResult> RemoveProperty(int propertyId)
    {
      var result = await _propertyService.RemoveAsync(propertyId);

      if (!result.Result)
        return BadRequest(result.Message);

      return Ok(result.Data);
    }
  }
}