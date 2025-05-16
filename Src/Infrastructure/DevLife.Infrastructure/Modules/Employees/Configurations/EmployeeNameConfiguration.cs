using System;
using DevLife.Domain.Modules.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevLife.Infrastructure.Modules.Employees.Configurations;

public class EmployeeNameConfiguration : IEntityTypeConfiguration<EmployeeName>
{
    public void Configure(EntityTypeBuilder<EmployeeName> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasIndex(e => e.Name).IsUnique();

        builder.Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();
    }
}
