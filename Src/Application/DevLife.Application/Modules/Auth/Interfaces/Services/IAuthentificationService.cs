using System;
using DevLife.Application.Modules.Auth.DTOs.Requests;
using DevLife.Application.Modules.Auth.DTOs.Response;

namespace DevLife.Application.Modules.Auth.Interfaces.Services;

public interface IAuthentificationService
{
    Task<LoginResponse> LoginAsync(LoginRequest request);
    Task<ConfirmEmailResponse> ConfirmEmailAsync(ConfirmEmailRequest request);
    Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest request);
    Task<RegisterResponse> RegisterAsync(RegisterRequest request);

}
