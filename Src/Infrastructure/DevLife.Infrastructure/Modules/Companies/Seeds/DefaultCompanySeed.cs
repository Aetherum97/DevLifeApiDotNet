using System;
using DevLife.Domain.Modules.Companies;
using DevLife.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DevLife.Infrastructure.Modules.Companies.Seeds;

public static class DefaultCompanySeed
{
    public static async Task SeedAsync(AppDbContext context)
    {

        if (!await context.Company.AnyAsync())
        {
            var company = new Company
            {
                Name = "default",
                Experience = 0,
            };

            context.Company.Add(company);
            await context.SaveChangesAsync();
        }


    }
}
