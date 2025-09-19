using System;
using Microsoft.AspNetCore.Mvc;
using tdlimoveis.Dtos;
using tdlimoveis.Models;
using tdlimoveis.Services;

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
      var result = await _propertyService.CreatePropertyAsync(ownerId, property);

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
  }
}