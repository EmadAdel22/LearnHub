using System;
using System.Collections.Generic;
using System.Text;

namespace LearnHub.Application.Auth.DTO
{
    public class RegisterRequest
    {
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
