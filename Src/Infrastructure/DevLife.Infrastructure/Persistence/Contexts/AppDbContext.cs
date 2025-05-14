using DevLife.Application.Commons.Interfaces.Services;
using DevLife.Infrastructure.Commons.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DevLife.Infrastructure.Persistence.Contexts;

public class AppDbContext(DbContextOptions<AppDbContext> options, IAuthenticatedUserService authenticatedUser) : DbContext(options)
{
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        ChangeTracker.ApplyAuditing(authenticatedUser);
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
