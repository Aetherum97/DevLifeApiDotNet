using System;
using DevLife.Domain.Commons.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevLife.Infrastructure.Commons.Configurations;

public class CompanyEmployeeConfiguration : IEntityTypeConfiguration<CompanyEmployee>
{
    public void Configure(EntityTypeBuilder<CompanyEmployee> builder)
    {
        builder.HasKey(ce => new { ce.EmployeeId, ce.CompanyId });
        builder.HasIndex(ce => ce.EmployeeId).IsUnique();

        builder.HasOne(ce => ce.Company)
            .WithMany(c => c.CompanyEmployees)
            .HasForeignKey(ce => ce.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ce => ce.Employee)
            .WithOne(e => e.CompanyEmployee)
            .HasForeignKey<CompanyEmployee>(ce => ce.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
