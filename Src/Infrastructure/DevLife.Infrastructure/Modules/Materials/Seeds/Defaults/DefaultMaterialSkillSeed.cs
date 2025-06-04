using DevLife.Domain.Modules.Materials;
using DevLife.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
namespace DevLife.Infrastructure.Modules.Materials.Seeds.Defaults;

public static class DefaultMaterialSkillSeed
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (await context.Set<MaterialSkill>().AnyAsync())
            return;

        var materialSkills = new List<MaterialSkill>
            {
                new MaterialSkill { Name = "Design"   , Modificator = 5 },
                new MaterialSkill { Name = "Backend"  , Modificator = 10 },
                new MaterialSkill { Name = "DevOps"   , Modificator = 8 }
            };

        context.Set<MaterialSkill>().AddRange(materialSkills);
        await context.SaveChangesAsync();
    }
}
