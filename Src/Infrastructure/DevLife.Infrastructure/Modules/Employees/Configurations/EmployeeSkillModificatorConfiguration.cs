using System;
using DevLife.Domain.Modules.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevLife.Infrastructure.Modules.Employees.Configurations;

public class EmployeeSkillModificatorConfiguration : IEntityTypeConfiguration<EmployeeSkillModificator>
{
    public void Configure(EntityTypeBuilder<EmployeeSkillModificator> builder)
    {
        builder.HasKey(esm => esm.Id);
        builder.HasIndex(esm => esm.Name).IsUnique();

        builder.Property(esm => esm.Name).IsRequired()
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(esm => esm.Description).IsRequired()
            .HasMaxLength(500)
            .IsRequired();
        builder.Property(esm => esm.Modificator)
            .HasColumnType("decimal(3, 2)")
            .IsRequired();
    }
}
