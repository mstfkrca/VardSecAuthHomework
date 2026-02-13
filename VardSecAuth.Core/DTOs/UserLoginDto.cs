using System;
using System.Collections.Generic;
using System.Text;

namespace VardSecAuth.Core.DTOs
{
    public class UserLoginDto
    {
        public required string Email { get; set; } 
        public required string Password { get; set; }
    }
}
