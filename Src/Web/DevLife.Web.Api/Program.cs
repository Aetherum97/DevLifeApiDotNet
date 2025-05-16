using DevLife.Application;
using DevLife.Infrastructure;
using DevLife.Infrastructure.Identity;
using DevLife.Infrastructure.Identity.Entity;
using DevLife.Infrastructure.Identity.Persistence.Contexts;
using DevLife.Infrastructure.Identity.Persistence.Seeds;
using DevLife.Infrastructure.Persistence.Contexts;
using DevLife.Web.Api.Commons.Extenssions;
using DevLife.Web.Api.Commons.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


bool useInMemoryDatabase = builder.Configuration.GetValue<bool>("UseInMemoryDatabase");

builder.Services.AddIdentityInfrastructureLayer(builder.Configuration, useInMemoryDatabase);
builder.Services.AddInfrastructureLayer(builder.Configuration, useInMemoryDatabase);
builder.Services.AddApplicationLayer();
builder.Services.AddPresentationWebApiLayer();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerExtensions();
builder.Services.AddCorsExtenssions();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    if (!useInMemoryDatabase)
    {
        var identityDb = services.GetRequiredService<AppIdentityDbContext>();
        var appDb = services.GetRequiredService<AppDbContext>();

        // await DatabaseHelper.EnsureDatabaseReadyAsync(identityDb);
        // await DatabaseHelper.EnsureDatabaseReadyAsync(appDb);

        if ((await identityDb.Database.GetPendingMigrationsAsync()).Any())

            await identityDb.Database.MigrateAsync();

        if ((await appDb.Database.GetPendingMigrationsAsync()).Any())
            await appDb.Database.MigrateAsync();
    }

    var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
    var userManager = services.GetRequiredService<UserManager<AppUser>>();

    await DefaultRole.SeedAsync(roleManager);
    await DefaultUser.SeedAsync(userManager);
}

app.UseDevelopementCors();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseSwaggerExtensions();
app.MapControllers();

await app.RunAsync();
