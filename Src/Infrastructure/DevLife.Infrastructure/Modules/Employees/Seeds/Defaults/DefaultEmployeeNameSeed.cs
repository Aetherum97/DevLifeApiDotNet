using System;
using DevLife.Domain.Modules.Employees;
using DevLife.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DevLife.Infrastructure.Modules.Employees.Seeds.Default;

public static class DefaultEmployeeNameSeed
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (!await context.EmployeeName.AnyAsync())
        {
            var names = new List<EmployeeName>
            {
                new() { Name = "John Doe" },
                new() { Name = "Jane Smith" }
            };

            context.EmployeeName.AddRange(names);
            await context.SaveChangesAsync();
        }
    }
}
