using DevLife.Domain.Modules.Contracts;
using DevLife.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
namespace DevLife.Infrastructure.Modules.Contracts.Seeds.Defaults;

public static class DefaultContractTemplateSeed
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (await context.Set<ContractTemplate>().AnyAsync())
            return;

        var firstType = await context.Set<ContractType>()
                                     .AsNoTracking()
                                     .FirstOrDefaultAsync();
        if (firstType == null)
            throw new InvalidOperationException("ContractType must be exist before seeding.");

        var contractTemplates = new List<ContractTemplate>
            {
                new() {
                    TypeId = firstType.Id,
                    Title = "Landing Page Template",
                    ImageUrl = "https://example.com/images/landing.png",
                    Description = "Template pour pages de présentation de site vitrine"
                },
                new() {
                    TypeId = firstType.Id,
                    Title = "REST API Boilerplate",
                    ImageUrl = "https://example.com/images/api_boilerplate.png",
                    Description = "Template pour démarrer rapidement une API REST en .NET"
                }
            };

        context.Set<ContractTemplate>().AddRange(contractTemplates);
        await context.SaveChangesAsync();
    }
}