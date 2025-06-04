using System;
using DevLife.Domain.Modules.Companies;
using DevLife.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DevLife.Infrastructure.Modules.Companies.Seeds;

public static class DefaultPlayerSeed
{
    public static async Task SeedAsync(AppDbContext context, Guid userId)
    {
        if (!await context.Player.AnyAsync())
        {
            var company = await context.Company.FirstOrDefaultAsync() ?? throw new InvalidOperationException("Company must exist before seeding Player.");
            var player = new Player
            {
                PlayerName = "default",
                IsTutorialFinished = false,
                CompanyId = company.Id,
                UserId = userId
            };

            context.Player.Add(player);
            await context.SaveChangesAsync();
        }
    }
}
