using System;
using DevLife.Domain.Modules.Employees;
using DevLife.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DevLife.Infrastructure.Modules.Employees.Seeds.Defaults;

public static class DefaultEmployeeSkillModificatorSeed
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (!await context.EmployeeSkillModificator.AnyAsync())
        {
            var mods = new List<EmployeeSkillModificator>
            {
                new() { Name = "Bonus XP", Description = "Gains extra experience", Modificator = 1.1m },
                new() { Name = "Fast Learner", Description = "Learns faster", Modificator = 1.2m }
            };

            context.EmployeeSkillModificator.AddRange(mods);
            await context.SaveChangesAsync();
        }
    }
}
