using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration; 
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VardSecAuth.Core.DTOs;
using VardSecAuth.Core.Entities;
using VardSecAuth.Core.Interfaces;
using VardSecAuth.Data;

namespace VardSecAuth.Service;

public class AuthService : IAuthService
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    
    public AuthService(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<string> RegisterAsync(UserRegisterDto request)
    {
        
        if (await _context.Users.AnyAsync(u => u.Email == request.Email))
        {
            return "Email already exists!";
        }

        
        
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

       
        var user = new User
        {
            Username = request.Username,
            Email = request.Email,
            PasswordHash = passwordHash 
        };

        
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return "User registered successfully!";
    }

    public async Task<string> LoginAsync(UserLoginDto request)
    {
        
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

        if (user == null)
        {
            return "User not found!";
        }

        
        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
        {
            return "Wrong password!";
        }

        
        string token = CreateToken(user);

        return token;
    }

    
    private string CreateToken(User user)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role), 
            new Claim(ClaimTypes.Email, user.Email)
        };

        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            _configuration.GetSection("Jwt:Key").Value!));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1), 
            signingCredentials: creds
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }
}