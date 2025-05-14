using DevLife.Application.Commons.Interfaces.Repositories;
using DevLife.Domain.Modules.Materials;
using DevLife.Infrastructure.Commons.Bases;
using DevLife.Infrastructure.Persistence.Contexts;

namespace DevLife.Infrastructure.Modules.Materials.Repositories
{
    public sealed class MaterialRepository(AppDbContext context) : BaseRepository<Material>(context), IMaterialRepository
    {
    }
}
