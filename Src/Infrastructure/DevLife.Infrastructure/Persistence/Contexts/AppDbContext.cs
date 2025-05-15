using DevLife.Application.Commons.Interfaces.Services;
using DevLife.Domain.Commons.Entity;
using DevLife.Domain.Modules.Companies;
using DevLife.Domain.Modules.Contracts.Entity;
using DevLife.Domain.Modules.Employees;
using DevLife.Domain.Modules.Materials.Entity;
using DevLife.Infrastructure.Commons.Configurations;
using DevLife.Infrastructure.Commons.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DevLife.Infrastructure.Persistence.Contexts;

public class AppDbContext(DbContextOptions<AppDbContext> options, IAuthenticatedUserService authenticatedUser) : DbContext(options)
{

    // Comons 
    public DbSet<CompanyContractEmployee> CompanyContractEmployee { get; set; } = null!;
    public DbSet<CompanyMaterialEmployee> CompanyMaterialEmployee { get; set; } = null!;
    public DbSet<CompanyEmployee> CompanyEmployee { get; set; } = null!;

    // Employees Module

    public DbSet<Employee> Employee { get; set; } = null!;

    // Contracts Module

    public DbSet<Contract> Contract { get; set; } = null!;

    // Companies Module

    public DbSet<Company> Company { get; set; } = null!;

    // Materials Module

    public DbSet<Material> Material { get; set; } = null!;


    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        ChangeTracker.ApplyAuditing(authenticatedUser);
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Comons 

        builder.ApplyConfiguration(new CompanyContractEmployeeConfiguration());
        builder.ApplyConfiguration(new CompanyMaterialEmployeeConfiguration());
        builder.ApplyConfiguration(new CompanyEmployeeConfiguration());

        // Employees Module

        // Contracts Module

        // Companies Module
        
        // Materials Module

    }
}
