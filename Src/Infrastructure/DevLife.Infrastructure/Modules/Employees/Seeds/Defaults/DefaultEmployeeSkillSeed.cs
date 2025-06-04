using System;
using DevLife.Domain.Modules.Employees;
using DevLife.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DevLife.Infrastructure.Modules.Employees.Seeds.Defaults;

public static class DefaultEmployeeSkillSeed
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (!await context.EmployeeSkill.AnyAsync())
        {
            var modificators = await context.EmployeeSkillModificator.ToListAsync();
            if (modificators.Count == 0) return;

            var skills = new List<EmployeeSkill>
            {
                new() {
                    Name = "C#",
                    Description = "Backend development with C#",
                    SkillModificators = [modificators[0]]
                },
                new() {
                    Name = "React",
                    Description = "Frontend with React",
                    SkillModificators = [modificators[1]]
                },
                new() {
                    Name = "Docker",
                    Description = "Containerization tool",
                    SkillModificators = [modificators[0], modificators[1]]
                }
            };

            context.EmployeeSkill.AddRange(skills);
            await context.SaveChangesAsync();
        }
    }
}
