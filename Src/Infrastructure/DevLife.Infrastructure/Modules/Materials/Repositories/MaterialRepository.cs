using DevLife.Application.Modules.Materials.Interfaces.Repositories;
using DevLife.Domain.Modules.Materials;
using DevLife.Infrastructure.Commons.Bases;
using DevLife.Infrastructure.Persistence.Contexts;

namespace DevLife.Infrastructure.Commons.Repositories
{
    public sealed class MaterialCompanyRepository(AppDbContext context) : BaseRepository<Material>(context), IMaterialRepository
    {
    }
}
