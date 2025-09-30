using System;
using Microsoft.AspNetCore.Authorization;
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

    [Authorize]
    [HttpPost("/owners/{ownerId}/properties")]
    public async Task<IActionResult> CreateProperty(int ownerId, [FromBody] PropertyCreateDto property)
    {
      var result = await _propertyService.CreateAsync(ownerId, property);

      if (!result.Result)
        return BadRequest(result.Message);

      return Ok(result.Data);
    }

    [Authorize]
    [HttpGet("/owners/{ownerId}/properties")]
    public async Task<IActionResult> ListProperties(int ownerId)
    {
      var result = await _propertyService.GetPropertiesByOwnerIdAsync(ownerId);

      if (!result.Result)
        return BadRequest(result.Message);

      return Ok(result.Data);
    }

    [Authorize]
    [HttpGet("/properties/{propertyId}")]
    public async Task<IActionResult> GetPropertyById(int propertyId)
    {
      var result = await _propertyService.GetPropertyById(propertyId);

      if (!result.Result)
        return BadRequest(result.Message);

      return Ok(result.Data);
    }

    [Authorize]
    [HttpPut("/properties/{propertyId}")]
    public async Task<IActionResult> UpdateProperty(int propertyId, [FromBody] PropertyUpdateDto property)
    {
      var result = await _propertyService.UpdateAsync(propertyId, property);

      if (!result.Result)
        return BadRequest(result.Message);

      return Ok(result.Data);
    }

    [Authorize]
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