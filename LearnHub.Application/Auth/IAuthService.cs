using LearnHub.Application.Auth.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnHub.Application.Auth
{
    public interface IAuthService
    {
        Task<AuthResponse> RegisterAsync(RegisterRequest request);

        Task<AuthResponse?> LoginAsync(LoginRequest request);
    }
}
