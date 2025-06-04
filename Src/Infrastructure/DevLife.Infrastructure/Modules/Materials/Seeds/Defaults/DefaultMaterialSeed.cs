using DevLife.Domain.Commons.Entity;
using DevLife.Domain.Modules.Companies;
using DevLife.Domain.Modules.Materials;
using DevLife.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
namespace DevLife.Infrastructure.Modules.Materials.Seeds.Defaults;

public static class DefaultMaterialSeed
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (await context.Set<Material>().AnyAsync())
            return;

        var firstCompany = await context.Set<Company>()
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync();
        if (firstCompany == null)
            throw new InvalidOperationException("Company must be exist before seeding.");

        var templates = await context.Set<MaterialTemplate>()
                                     .AsNoTracking()
                                     .ToListAsync();
        if (templates.Count == 0)
            throw new InvalidOperationException("MaterialTemplate must be seeded");

        foreach (var template in templates)
        {
            var material = new Material
            {
                MaterialTemplateId = template.Id
            };
            var companyMaterial = new CompanyMaterial
            {
                MaterialId = material.Id,
                CompanyId = firstCompany.Id,
                Material = material
            };

            context.Set<Material>().Add(material);
            context.Set<CompanyMaterial>().Add(companyMaterial);
        }

        await context.SaveChangesAsync();
    }
}