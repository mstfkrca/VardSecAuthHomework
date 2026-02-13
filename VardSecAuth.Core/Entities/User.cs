using System;
using System.Collections.Generic;
using System.Text;

namespace VardSecAuth.Core.Entities
{
    public class User
    {
        public int Id { get; set; }

        
        public required string Username { get; set; }
        public required string Email { get; set; }

        
        public required string PasswordHash { get; set; }

        
        public string Role { get; set; } = "User"; 

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
