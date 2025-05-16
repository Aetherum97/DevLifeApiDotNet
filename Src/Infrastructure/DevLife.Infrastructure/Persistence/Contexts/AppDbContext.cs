using DevLife.Application.Commons.Interfaces.Services;
using DevLife.Domain.Commons.Entity;
using DevLife.Domain.Modules.Companies;
using DevLife.Domain.Modules.Contracts;
using DevLife.Domain.Modules.Employees;
using DevLife.Domain.Modules.Materials;
using DevLife.Infrastructure.Commons.Configurations;
using DevLife.Infrastructure.Commons.Extensions;
using DevLife.Infrastructure.Modules.Contracts.Configurations;
using DevLife.Infrastructure.Modules.Employees.Configurations;
using DevLife.Infrastructure.Modules.Materials.Configurations;
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
    public DbSet<EmployeeName> EmployeeName { get; set; } = null!;
    public DbSet<EmployeeSkill> EmployeeSkill { get; set; } = null!;
    public DbSet<EmployeeSkillModificator> EmployeeSkillModificator { get; set; } = null!;

    // Contracts Module

    public DbSet<Contract> Contract { get; set; } = null!;
    public DbSet<ContractTemplate> ContractTemplate { get; set; } = null!;
    public DbSet<ContractType> ContractType { get; set; } = null!;

    // Companies Module

    public DbSet<Company> Company { get; set; } = null!;

    // Materials Module

    public DbSet<Material> Material { get; set; } = null!;
    public DbSet<MaterialSkill> MaterialSkill { get; set; } = null!;
    public DbSet<MaterialTemplate> MaterialTemplate { get; set; } = null!;


    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        ChangeTracker.ApplyAuditing(authenticatedUser);
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Comons 

        modelBuilder.ApplyConfiguration(new CompanyContractEmployeeConfiguration());
        modelBuilder.ApplyConfiguration(new CompanyMaterialEmployeeConfiguration());
        modelBuilder.ApplyConfiguration(new CompanyEmployeeConfiguration());

        // Employees Module

        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeNameConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeSkillConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeSkillModificatorConfiguration());

        // Contracts Module
        modelBuilder.ApplyConfiguration(new ContractConfiguration());
        modelBuilder.ApplyConfiguration(new ContractTemplateConfiguration());
        modelBuilder.ApplyConfiguration(new ContractTypeConfiguration());

        // Companies Module

        // Materials Module
        modelBuilder.ApplyConfiguration(new MaterialConfiguration());
        modelBuilder.ApplyConfiguration(new MaterialSkillConfiguration());
        modelBuilder.ApplyConfiguration(new MaterialTemplateConfiguration());

    }
}
