using DevLife.Application.Modules.Auth.DTOs;
using DevLife.Infrastructure.Identity.Entity;
using System.Security.Claims;

namespace DevLife.Infrastructure.Identity.Interfaces.Services
{
    public interface ITokenRefreshService
    {
        public Task<RefreshToken> GenerateRefreshTokenAsync(AppUser user, IEnumerable<Claim> claims);
        public Task<RefreshToken> UpdateRefreshTokenAsync(RefreshToken refreshToken, IEnumerable<Claim> claims);
        public bool VerifyRefreshToken(string token);
        public Task<RefreshToken> GetRefreshTokenByUserId(Guid id);
        public Task<RefreshToken> GetRefreshTokenByTokenAsync(string token);
        public Task DeleteRefreshTokenAsync(AppUser user);
        public RefreshTokenDto MapToRefreshTokenDto(RefreshToken token);
    }
}
