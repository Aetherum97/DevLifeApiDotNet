using DevLife.Application.Modules.Materials.Interfaces.Repositories;
using DevLife.Domain.Modules.Materials;
using DevLife.Infrastructure.Commons.Bases;
using DevLife.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DevLife.Infrastructure.Modules.Materials.Repositories
{
    public class MaterialRepository(AppDbContext context) : BaseRepository<Material>(context), IMaterialRepository
    {
        public async Task<List<Material>> GetAllByCompanyIdAsync(Guid companyId)
        {
            return await context.Set<Material>()
                                 .Include(m => m.CompanyMaterial)
                                 .Include(m => m.MaterialTemplate)
                                     .ThenInclude(mt => mt!.MaterialSkill)
                                     .Where(m => m.CompanyMaterial != null && m.CompanyMaterial.CompanyId == companyId)
                                 .ToListAsync();
        }

        public override async Task<Material> GetByIdAsync(Guid id)
        {
            var material = await context.Set<Material>()
                                        .Include(m => m.CompanyMaterial)
                                        .Include(m => m.MaterialTemplate)
                                            .ThenInclude(mt => mt!.MaterialSkill)
                                        .FirstOrDefaultAsync(m => m.Id == id);
            return material ?? throw new InvalidOperationException("Ressources not Found");
        }
    }
}
