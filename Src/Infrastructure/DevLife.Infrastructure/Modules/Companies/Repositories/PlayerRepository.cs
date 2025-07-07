using DevLife.Application.Modules.Companies.Interfaces.Repositories;
using DevLife.Domain.Modules.Companies;
using DevLife.Infrastructure.Commons.Bases;
using DevLife.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;


namespace DevLife.Infrastructure.Modules.Companies.Repositories;


public class PlayerRepository(AppDbContext context) : BaseRepository<Player>(context), IPlayerRepository
{
    public async Task<bool> IsExistsByUserIdAsync(Guid playerId)
    {
        return await context.Set<Player>().AsNoTracking().AnyAsync(p => p.Id == playerId);
    }
}
