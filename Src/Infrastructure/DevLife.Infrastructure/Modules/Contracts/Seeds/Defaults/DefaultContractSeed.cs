using DevLife.Domain.Commons.Entity;
using DevLife.Domain.Modules.Companies;
using DevLife.Domain.Modules.Contracts;
using DevLife.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;

namespace DevLife.Infrastructure.Modules.Contracts.Seeds.Defaults;

public class DefaultContractSeed
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (await context.Set<Contract>().AnyAsync())
            return;

        var firstCompany = await context.Set<Company>()
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync();
        if (firstCompany == null)
            throw new InvalidOperationException("Company must be exist before seeding.");

        var firstTemplate = await context.Set<ContractTemplate>()
                                         .AsNoTracking()
                                         .FirstOrDefaultAsync();
        if (firstTemplate == null)
            throw new InvalidOperationException("ContractTemplate must be exist before seeding.");

        var now = DateTime.UtcNow;

        var contract = new Contract
        {
            ContractTemplateId = firstTemplate.Id,
            StartDate = now,
            Deadline = now.AddDays(7),
            Reward = 1500,
            IsAccepted = false,
            IsCompleted = false,
            Progress = 0
        };

        var companyContract = new CompanyContract
        {
            ContractId = contract.Id,
            CompanyId = firstCompany.Id,
            Contract = contract
        };

        context.Set<Contract>().Add(contract);
        context.Set<CompanyContract>().Add(companyContract);
        await context.SaveChangesAsync();
    }
}
