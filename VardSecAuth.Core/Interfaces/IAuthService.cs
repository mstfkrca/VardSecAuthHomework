using System;
using System.Collections.Generic;
using System.Text;
using VardSecAuth.Core.DTOs;

namespace VardSecAuth.Core.Interfaces
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(UserRegisterDto request);
        Task<string> LoginAsync(UserLoginDto request);
    }
}
