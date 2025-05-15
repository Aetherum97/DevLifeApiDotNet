using System;
using System.Security.Claims;
using DevLife.Application.Commons.Interfaces.Services;

namespace DevLife.Web.Api.Commons.Services;

public class AuthenticatedUserService(IHttpContextAccessor httpContextAccessor) : IAuthenticatedUserService
{
    public string UserId { get; } = httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier)!;
    public string UserName { get; } = httpContextAccessor.HttpContext?.User.Identity?.Name!;
}

