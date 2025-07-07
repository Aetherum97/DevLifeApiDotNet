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
        builder.HasIndex(cce => new { cce.EmployeeId, cce.ContractId }).IsUnique();

        builder.HasOne(cce => cce.CompanyEmployee)
            .WithMany(e => e.ContractAssignments)
            .HasForeignKey(cce => new { cce.CompanyId, cce.EmployeeId })
            .HasPrincipalKey(ce => new { ce.CompanyId, ce.EmployeeId })
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(cce => cce.CompanyContract)
            .WithMany(cc => cc.AssignedEmployees)
            .HasForeignKey(cce => new { cce.CompanyId, cce.ContractId })
            .HasPrincipalKey(cc => new { cc.CompanyId, cc.ContractId })
            .OnDelete(DeleteBehavior.Restrict);
    }
}
