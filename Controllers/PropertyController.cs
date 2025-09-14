using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tdlimoveis.Data;
using tdlimoveis.Models;

namespace tdlimoveis.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class PropertyController : Controller
  {
    private readonly TdlContext db;
    public PropertyController(TdlContext _context)
    {
      db = _context;
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateProperty(int id, [FromBody] Property updatedProperty)
    {
      var property = await db.Properties.FindAsync(id);
      if (property == null)
        return NotFound("Properiedade não encontrada!");

      property.RentalValue = updatedProperty.RentalValue;
      property.InsuranceExpiry = updatedProperty.InsuranceExpiry;
      property.Status = updatedProperty.Status;

      await db.SaveChangesAsync();

      return Ok();
    }

    [HttpGet("listContracts/{propertyId}")]
    public async Task<IActionResult> ReadContracts(int propertyId)
    {
      var property = await db.Properties.FindAsync(propertyId);
      if (property == null)
        return NotFound($"Propriedade com id {propertyId} não encontrada.");

      var contratos = await db.Contracts
          .Where(x => x.PropertyId == property.Id)
          .ToListAsync();

      return Ok(contratos);
    }
  }
}