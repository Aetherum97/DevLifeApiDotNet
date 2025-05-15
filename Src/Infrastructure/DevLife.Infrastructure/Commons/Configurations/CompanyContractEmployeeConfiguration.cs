using System;
using DevLife.Domain.Commons.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DevLife.Infrastructure.Commons.Configurations;

public class CompanyContractEmployeeConfiguration : IEntityTypeConfiguration<CompanyContractEmployee>
{
    public void Configure(EntityTypeBuilder<CompanyContractEmployee> builder)
    {
        builder.HasKey(cce => cce.Id);

        builder.HasIndex(cce => new { cce.ContractId, cce.EmployeeId })
            .IsUnique()
            .HasFilter("[EmployeeId] IS NOT NULL");

        builder.HasIndex(cce => new { cce.CompanyId, cce.EmployeeId })
            .IsUnique()
            .HasFilter("[EmployeeId] IS NOT NULL");

        builder.HasOne(cce => cce.Company)
            .WithMany(c => c.CompanyContractEmployees)
            .HasForeignKey(cce => cce.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(cce => cce.Employee)
            .WithMany(e => e.CompanyContractEmployees)
            .HasForeignKey(cce => cce.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(cce => cce.Contract)
            .WithMany(c => c.CompanyContractEmployees)
            .HasForeignKey(cce => cce.ContractId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
