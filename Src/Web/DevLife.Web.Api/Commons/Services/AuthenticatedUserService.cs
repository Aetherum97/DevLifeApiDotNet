using System.Security.Claims;
using DevLife.Application.Commons.Interfaces.Services;

namespace DevLife.Web.Api.Commons.Services;

public class AuthenticatedUserService(
    IHttpContextAccessor httpContextAccessor
    ) : IAuthenticatedUserService
{
    public string UserId { get; set; } = httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier)!;
    public string CompanyId { get; } = httpContextAccessor.HttpContext?.User.FindFirstValue("companyId")!;
    public string UserName { get; } = httpContextAccessor.HttpContext?.User.Identity?.Name!;
    public Guid GetUserId()
    {

        return UserId is not null && Guid.TryParse(UserId, out var parsed)
            ? parsed
            : Guid.Empty;
    }

    public Guid GetCompanyId()
    {

        return CompanyId is not null && Guid.TryParse(CompanyId, out var parsed)
            ? parsed
            : throw new UnauthorizedAccessException("User is not authenticated or has an invalid ID.");
    }

}

