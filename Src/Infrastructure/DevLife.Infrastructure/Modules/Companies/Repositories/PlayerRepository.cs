using DevLife.Application.Modules.Companies.Interfaces.Interfaces;
using DevLife.Domain.Modules.Companies;
using DevLife.Infrastructure.Commons.Bases;
using DevLife.Infrastructure.Persistence.Contexts;


namespace DevLife.Infrastructure.Modules.Companies.Repositories;


public class PlayerRepository(AppDbContext context) : BaseRepository<Player>(context), IPlayerRepository
{

}
