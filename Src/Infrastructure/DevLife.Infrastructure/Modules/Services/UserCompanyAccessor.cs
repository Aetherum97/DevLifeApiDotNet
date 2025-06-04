using System;
using DevLife.Application.Commons.Interfaces.Services.Accessors;
using DevLife.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DevLife.Infrastructure.Modules.Services;

public class UserCompanyAccessor(AppDbContext context) : IUserCompanyAccessor
{
    public async Task<Guid> GetCompanyIdForUserAsync(Guid userId)
    {
        var player = await context.Player
            .Where(p => p.UserId == userId)
            .Include(p => p.Compagny)
            .FirstOrDefaultAsync() ?? throw new InvalidOperationException($"No company found for user with ID '{userId}'.");
        return player!.Compagny!.Id;
    }
}