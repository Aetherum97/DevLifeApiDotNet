using DevLife.Domain.Modules.Materials;
using DevLife.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
namespace DevLife.Infrastructure.Modules.Materials.Seeds.Defaults;

public static class DefaultMaterialTemplateSeed
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (await context.Set<MaterialTemplate>().AnyAsync())
            return;

        var firstSkill = await context.Set<MaterialSkill>()
                                      .AsNoTracking()
                                      .FirstOrDefaultAsync();
        if (firstSkill == null)
            throw new InvalidOperationException("MaterialSkill must be exist before seeding.");

        var materialTemplates = new List<MaterialTemplate>
            {
                new() {
                    MaterialSkillId = firstSkill.Id,
                    Name = "Chaise de bureau",
                    Type = "Bureautique",
                    Description = "Chaise de bureau standard",
                    ImageUrl = "https://example.com/images/chair.png"
                },
                new() {
                    MaterialSkillId = firstSkill.Id,
                    Name = "Écran 144hz",
                    Type = "Bureautique",
                    Description = "Écran de pc en 144hz",
                    ImageUrl = "https://example.com/images/desktop.png"
                }
            };

        context.Set<MaterialTemplate>().AddRange(materialTemplates);
        await context.SaveChangesAsync();
    }
}
