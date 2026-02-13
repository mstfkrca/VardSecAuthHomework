using Microsoft.AspNetCore.Mvc;
using VardSecAuth.Core.DTOs;
using VardSecAuth.Core.Interfaces;

namespace VardSecAuth.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<string>> Register(UserRegisterDto request)
    {
        var result = await _authService.RegisterAsync(request);
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<ActionResult<string>> Login(UserLoginDto request)
    {
        var result = await _authService.LoginAsync(request);

        if (result == "User not found!" || result == "Wrong password!")
        {
            return BadRequest(result);
        }

        return Ok(result); 
    }
}