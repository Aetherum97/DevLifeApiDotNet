using System.Security.Claims;


namespace DevLife.Infrastructure.Identity.Interfaces.Services
{
    public interface ITokenAccessService
    {
        Task<string> GenerateAccessToken(IEnumerable<Claim> userClaim);

    }
}
