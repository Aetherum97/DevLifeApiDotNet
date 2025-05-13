using DevLife.Infrastructure.Identity.Interfaces.Services;
using DevLife.Infrastructure.Identity.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DevLife.Infrastructure.Identity.Services
{
    class TokenAccessService(JwtSettings jwtSettings) : JwtService(jwtSettings), ITokenAccessService
    {
        public string GenerateAccessToken(IEnumerable<Claim> userClaim)
        {
            var signingCredentials = GetSigningCredentials();
            var jwtSecurityToken = CreateJwtToken(userClaim, signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}
