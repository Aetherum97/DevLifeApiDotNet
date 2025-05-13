using System.Security.Claims;


namespace DevLife.Infrastructure.Identity.Interfaces.Services
{
    public interface ITokenAccessService
    {
        public string GenerateAccessToken(IEnumerable<Claim> userClaim);

    }
}
