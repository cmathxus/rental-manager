using System;
using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tdlimoveis.Data;
using tdlimoveis.Models;

namespace tdlimoveis.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class OwnerController : Controller
  {
    private readonly TdlContext db;
    public OwnerController(TdlContext _context)
    {
      db = _context;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateOwner([FromBody] Owner owner)
    {
      if (owner == null)
        return BadRequest("Proprietário inválido");

      await db.AddAsync(owner);
      await db.SaveChangesAsync();
      return Ok(owner);
    }

    [HttpGet("read")]
    public IActionResult ReadOwner()
    {
      var owners = db.Owners
      .OrderBy(x => x.Name)
      .ToList();
      return Ok(owners);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateOwner(int id, [FromBody] Owner updatedOwner)
    {
      var owner = await db.Owners.FindAsync(id);
      if (owner == null)
        return NotFound("Proprietário inválido!");

      owner.Name = updatedOwner.Name;
      owner.Email = updatedOwner.Email;
      owner.BankAccount = updatedOwner.BankAccount;
      owner.Phone = updatedOwner.Phone;

      await db.SaveChangesAsync();

      return Ok();
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteOwner(int id)
    {
      var owner = await db.Owners
      .FindAsync(id);

      if (owner == null)
        return NotFound("Proprietário inválido!");

      db.Owners.Remove(owner);
      await db.SaveChangesAsync();

      return Ok();
    }

    [HttpPost("addProperty/{ownerId}")]
    public async Task<IActionResult> AddPropertyToOwner(int ownerId, [FromBody] Property property)
    {
      var owner = await db.Owners.FindAsync(ownerId);
      if (owner == null)
        return NotFound($"Owner com id {ownerId} não encontrado.");

      property.OwnerId = ownerId;

      await db.Properties.AddAsync(property);
      await db.SaveChangesAsync();

      return Ok(property);
    }

    [HttpGet("listProperties/{ownerId}")]
    public async Task<IActionResult> ReadProperties(int ownerId)
    {
      var owner = db.Owners.Find(ownerId);
      if (owner == null)
        return NotFound("Proprietário não encontrado");

      var properties = db.Properties
      .Where(x => x.OwnerId == ownerId)
      .ToList();

      return Ok(properties);
    }

    [HttpDelete("removeProperty/{ownerId}/{propertyId}")]
    public async Task<IActionResult> RemovePropertyFromOwner(int ownerId, int propertyId)
    {
      var owner = await db.Owners.FindAsync(ownerId);
      if (owner == null)
        return NotFound($"Owner com id {ownerId} não encontrado.");

      var property = await db.Properties.FindAsync(propertyId);
      if (property == null || property.OwnerId != ownerId)
        return NotFound("Propriedade não encontrada ou não pertence a este proprietário.");

      db.Properties.Remove(property);
      await db.SaveChangesAsync();

      return Ok(property);
    }
  }
}