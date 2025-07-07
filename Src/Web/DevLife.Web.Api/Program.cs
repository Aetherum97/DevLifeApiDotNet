using DevLife.Application;
using DevLife.Application.Commons.Interfaces.Services;
using DevLife.Application.Modules.Auth.Interfaces.Services;
using DevLife.Infrastructure;
using DevLife.Infrastructure.Identity;
using DevLife.Infrastructure.Identity.Entity;
using DevLife.Infrastructure.Identity.Persistence.Contexts;
using DevLife.Infrastructure.Identity.Persistence.Seeds;
using DevLife.Infrastructure.Modules.Companies.Handlers;
using DevLife.Infrastructure.Modules.Companies.Seeds;
using DevLife.Infrastructure.Modules.Contracts.Seeds.Defaults;
using DevLife.Infrastructure.Modules.Employees.Seeds.Default;
using DevLife.Infrastructure.Modules.Employees.Seeds.Defaults;
using DevLife.Infrastructure.Modules.Materials.Seeds.Defaults;
using DevLife.Infrastructure.Persistence.Contexts;
using DevLife.Shared.Mapper;
using DevLife.Web.Api;
using DevLife.Web.Api.Commons.Extenssions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

bool useInMemoryDatabase = builder.Configuration.GetValue<bool>("UseInMemoryDatabase");

builder.Services.AddIdentityInfrastructureLayer(builder.Configuration, useInMemoryDatabase);
builder.Services.AddInfrastructureLayer(builder.Configuration, useInMemoryDatabase);
builder.Services.AddScoped<ICustomMapper, CustomMapperService>();
builder.Services.AddScoped<IEmailConfirmationHandler, EmailConfirmationHandler>();
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
    var identityDb = services.GetRequiredService<AppIdentityDbContext>();
    var appDb = services.GetRequiredService<AppDbContext>();

    if (!useInMemoryDatabase)
    {

        if ((await identityDb.Database.GetPendingMigrationsAsync()).Any())

            await identityDb.Database.MigrateAsync();

        if ((await appDb.Database.GetPendingMigrationsAsync()).Any())
            await appDb.Database.MigrateAsync();
    }

    var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
    var userManager = services.GetRequiredService<UserManager<AppUser>>();


    await DefaultRole.SeedAsync(roleManager);
    await DefaultUser.SeedAsync(userManager);

    var user = await userManager.FindByNameAsync("admin");

    await DefaultCompanySeed.SeedAsync(appDb);
    await DefaultPlayerSeed.SeedAsync(appDb, user!.Id);

    await DefaultEmployeeSkillModificatorSeed.SeedAsync(appDb);
    await DefaultEmployeeSkillSeed.SeedAsync(appDb);
    await DefaultEmployeeNameSeed.SeedAsync(appDb);
    await DefaultEmployeeSeed.SeedAsync(appDb);

    await DefaultContractTypeSeed.SeedAsync(appDb);
    await DefaultContractTemplateSeed.SeedAsync(appDb);
    await DefaultContractSeed.SeedAsync(appDb);

    await DefaultMaterialSkillSeed.SeedAsync(appDb);
    await DefaultMaterialTemplateSeed.SeedAsync(appDb);
    await DefaultMaterialSeed.SeedAsync(appDb);

    var cacheService = scope.ServiceProvider.GetRequiredService<IReferenceDataCacheService>();
    await cacheService.InitializeAsync();
}

app.UseDevelopementCors();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseSwaggerExtensions();
app.MapControllers();

await app.RunAsync();
