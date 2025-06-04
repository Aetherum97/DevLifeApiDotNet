using System;
using System.Security.Claims;
using DevLife.Application.Commons.Interfaces.Services;
using DevLife.Infrastructure.Identity.Entity;
using Microsoft.AspNetCore.Identity;

namespace DevLife.Web.Api.Commons.Services;

public class AuthenticatedUserService(
    IHttpContextAccessor httpContextAccessor,
    UserManager<AppUser> userManager,
    IHostEnvironment environment
    ) : IAuthenticatedUserService
{
    public string UserId { get; } = httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier)!;
    public string UserName { get; } = httpContextAccessor.HttpContext?.User.Identity?.Name!;
    public Guid GetUserId()
    {
        var id = httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

        return id is not null && Guid.TryParse(id, out var parsed)
            ? parsed
            : throw new UnauthorizedAccessException("User is not authenticated or has an invalid ID.");
    }

    public async Task<Guid?> GetAdminUserIdInDevelopmentAsync()
    {
        if (!environment.IsDevelopment())
            return null;

        var admin = await userManager.FindByNameAsync("admin");

        return admin?.Id;
    }
}

