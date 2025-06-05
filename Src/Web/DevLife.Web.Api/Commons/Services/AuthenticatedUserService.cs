using System;
using System.Security.Claims;
using DevLife.Application.Commons.Interfaces.Services;
using DevLife.Infrastructure.Identity.Entity;
using Microsoft.AspNetCore.Identity;

namespace DevLife.Web.Api.Commons.Services;

public class AuthenticatedUserService(
    IHttpContextAccessor httpContextAccessor
    ) : IAuthenticatedUserService
{
    public string UserId { get; } = httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier)!;
    public string CompanyId { get; } = httpContextAccessor.HttpContext?.User.FindFirstValue("companyId")!;
    public string UserName { get; } = httpContextAccessor.HttpContext?.User.Identity?.Name!;
    public Guid GetUserId()
    {
        var httpContext = httpContextAccessor.HttpContext;
        if (httpContext?.User?.Identity?.IsAuthenticated != true)
        {
            return Guid.Empty;
        }
        var userIdString = httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        return Guid.TryParse(userIdString, out var parsed) ? parsed : Guid.Empty;
    }

    public Guid GetCompanyId()
    {
        var httpContext = httpContextAccessor.HttpContext;
        if (httpContext?.User?.Identity?.IsAuthenticated != true)
            return Guid.Empty;

        var companyIdString = httpContext.User.FindFirstValue("companyId");
        return Guid.TryParse(companyIdString, out var parsed)
            ? parsed
            : Guid.Empty;
    }

}

