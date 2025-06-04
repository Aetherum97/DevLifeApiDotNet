using DevLife.Domain.Modules.Contracts;
using DevLife.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
namespace DevLife.Infrastructure.Modules.Contracts.Seeds.Defaults;

public static class DefaultContractTypeSeed
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (await context.Set<ContractType>().AnyAsync())
            return;

        var contractTypes = new List<ContractType>
            {
                new() { Name = "Website Development" },
                new() { Name = "API Integration" },
                new() { Name = "Mobile App" }
            };

        context.Set<ContractType>().AddRange(contractTypes);
        await context.SaveChangesAsync();
    }
}