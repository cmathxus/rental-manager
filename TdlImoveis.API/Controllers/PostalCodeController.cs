using Microsoft.AspNetCore.Mvc;
using tdlimoveis.Application.DTOs;
using TdlImoveis.Application.UseCases.PostalCode;

namespace tdlimoveis.Controllers;

[ApiController]
[Route("[controller]")]
public class PostalCodeController : ControllerBase
{
    
    private readonly IPostalCodeService  _postalCodeService;

    public PostalCodeController(IPostalCodeService postalCodeService)
    {
        _postalCodeService = postalCodeService;
    }
    
    [HttpPost("/postalCode")]
    public async Task<IActionResult> Get([FromBody] PostalCodeRequest request)
    {
        var result = await _postalCodeService.AddressByPostalCode(request);
        
        if (!result.Result)
            return BadRequest(result.Message);
        
        return Ok(result);
    }
}