using DevLife.Domain.Commons.Entity;
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

        var firstCompany = await context.Set<Domain.Modules.Companies.Company>()
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync();
        if (firstCompany == null)
            throw new InvalidOperationException("Company must be exist before seeding.");

        var firstTemplate = await context.Set<MaterialTemplate>()
                                         .AsNoTracking()
                                         .FirstOrDefaultAsync();
        if (firstTemplate == null)
            throw new InvalidOperationException("MaterialTemplate must be exist before seeding.");

        var material = new Material
        {
            MaterialTemplateId = firstTemplate.Id
        };

        var companyMaterial = new CompanyMaterial
        {
            MaterialId = material.Id,
            CompanyId = firstCompany.Id,
            Material = material
        };

        context.Set<Material>().Add(material);
        context.Set<CompanyMaterial>().Add(companyMaterial);
        await context.SaveChangesAsync();
    }
}