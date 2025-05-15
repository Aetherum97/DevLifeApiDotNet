using System;
using DevLife.Domain.Commons.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevLife.Infrastructure.Commons.Configurations;

public class CompanyMaterialEmployeeConfiguration : IEntityTypeConfiguration<CompanyMaterialEmployee>
{
    public void Configure(EntityTypeBuilder<CompanyMaterialEmployee> builder)
    {

        builder.HasIndex(cme => new { cme.MaterialId, cme.EmployeeId })
            .IsUnique()
            .HasFilter("[MaterialId] IS NOT NULL");

        builder.HasIndex(cme => new { cme.MaterialId, cme.CompanyId })
            .IsUnique()
            .HasFilter("[MaterialId] IS NOT NULL");

        builder.HasOne(cme => cme.Company)
            .WithMany(c => c.CompanyMaterialEmployees)
            .HasForeignKey(cme => cme.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(cme => cme.Employee)
            .WithMany(e => e.CompanyMaterialEmployees)
            .HasForeignKey(cme => cme.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(cme => cme.Material)
            .WithMany(m => m.CompanyMaterialEmployees)
            .HasForeignKey(cme => cme.MaterialId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
