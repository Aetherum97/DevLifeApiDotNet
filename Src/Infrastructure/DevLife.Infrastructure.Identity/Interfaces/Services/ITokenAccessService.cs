using System.Security.Claims;


namespace DevLife.Infrastructure.Identity.Interfaces.Services
{
    public interface ITokenAccessService
    {
        Task<string> GenerateAccessTokenAsync(IEnumerable<Claim> userClaim);

    }
}
