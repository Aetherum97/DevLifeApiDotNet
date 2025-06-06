using System;
using DevLife.Application.Modules.Auth.DTOs.Requests;
using DevLife.Application.Modules.Auth.DTOs.Response;
using DevLife.Application.Modules.Auth.Interfaces.Services;
using FluentValidation;

namespace DevLife.Application.Modules.Auth.Services;

public class AuthentificationService(
    IAuthManager authManager,
    IEmailConfirmationHandler emailConfirmationHandler
) : IAuthentificationService
{

    public async Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest request)
    {
        return await authManager.AuthenticateAsync(request.RefreshToken);
    }

    public async Task<ConfirmEmailResponse> ConfirmEmailAsync(ConfirmEmailRequest request)
    {
        var response = await authManager.ValidateEmailAsync(request);

        if (response.Success && !string.IsNullOrEmpty(response.UserName))
        {
            await emailConfirmationHandler.HandleAsync(response.UserId, response.UserName);
        }
        return response;
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        return await authManager.LoginAsync(request);
    }

    public async Task<RegisterResponse> RegisterAsync(RegisterRequest request)
    {
        return await authManager.RegisterAccountAsync(request, request.Password);
    }
}

