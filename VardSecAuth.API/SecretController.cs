using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VardSecAuth.API.Controllers;

[Route("api/[controller]")]
[ApiController]

[Authorize]
public class SecretController : ControllerBase
{
    [HttpGet]
    public IActionResult GetSecretData()
    {
        
        var username = User.Identity?.Name;

        return Ok(new
        {
            Message = $"Tebrikler {username}! Bu veriyi sadece giriş yapmış yetkili personel görebilir.",
            SecretCode = "VARDSEC-2026-CONFIDENTIAL"
        });
    }
}