using DevLife.Application.Commons.Interfaces.Services.Accessors;
using DevLife.Infrastructure.Identity.Interfaces.Services;
using DevLife.Infrastructure.Identity.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DevLife.Infrastructure.Identity.Services
{
    class TokenAccessService(JwtSettings jwtSettings, IUserCompanyAccessor companyAccessor) : JwtService(jwtSettings), ITokenAccessService
    {
        public async Task<string> GenerateAccessToken(IEnumerable<Claim> userClaim)
        {
            var signingCredentials = GetSigningCredentials();
            var userId = userClaim.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var companyId = await companyAccessor.GetCompanyIdForUserAsync(Guid.Parse(userId!));

            var claims = new List<Claim>(userClaim)
            {
                new("companyId", companyId.ToString())
            };

            var jwtSecurityToken = CreateJwtToken(claims, signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}
