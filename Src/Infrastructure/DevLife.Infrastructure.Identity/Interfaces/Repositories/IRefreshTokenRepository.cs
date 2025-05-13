using DevLife.Infrastructure.Identity.Entity;

namespace DevLife.Infrastructure.Identity.Interfaces.Repositories
{
    public interface IRefreshTokenRepository
    {
        public Task<RefreshToken?> GetByUserIdAsync(Guid id);
        public Task<RefreshToken?> GetByTokenAsync(string token);
        public Task<RefreshToken> AddAsync(RefreshToken entity);
        public Task<RefreshToken> DeleteAsync(RefreshToken entity);
    }
}
