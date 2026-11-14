using System;
using System.Collections.Generic;
using System.Text;

namespace LearnHub.Application.Auth.DTO
{
    public class AuthResponse
    {
        public string Token { get; set; } = string.Empty;

        public DateTime ExpiresAt { get; set; }

        public string Email { get; set; } = string.Empty;

        public List<string> Roles { get; set; } = new();
    }
}
