using System;
using DevLife.Domain.Commons.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevLife.Infrastructure.Commons.Configurations;

public class CompanyMaterialEmployeeConfiguration : IEntityTypeConfiguration<CompanyMaterialEmployee>
{
    public void Configure(EntityTypeBuilder<CompanyMaterialEmployee> builder)
    {

        builder.HasKey(cme => cme.Id);
        builder.HasIndex(cme => new { cme.EmployeeId, cme.MaterialId }).IsUnique();

        builder.HasOne(cme => cme.CompanyEmployee)
           .WithMany(e => e.MaterialAssignments)
           .HasForeignKey(cme => new { cme.CompanyId, cme.EmployeeId })
           .HasPrincipalKey(e => new { e.CompanyId, e.EmployeeId })
           .OnDelete(DeleteBehavior.Restrict);


        builder.HasOne(cme => cme.CompanyMaterial)
            .WithMany(c => c.AssignedMaterial)
            .HasForeignKey(cme => new { cme.CompanyId, cme.MaterialId })
            .HasPrincipalKey(c => new { c.CompanyId, c.MaterialId })
            .OnDelete(DeleteBehavior.Restrict);

        builder.Ignore(cme => cme.CreatedAt);
        builder.Ignore(cme => cme.CreatedBy);
        builder.Ignore(cme => cme.ModifiedAt);
        builder.Ignore(cme => cme.LastModifiedBy);
    }
}

