using Microsoft.AspNetCore.Mvc;
using tdlimoveis.Application.DTOs;
using TdlImoveis.Application.UseCases;

namespace tdlimoveis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserCreateDto user)
        {
            var result = await _userService.Register(user);

            if (!result.Result)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto user)
        {
            var result = await _userService.Login(user);

            if (!result.Result)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }
    }
}