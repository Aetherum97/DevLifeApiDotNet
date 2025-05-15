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

        builder.Property(esm => esm.Name).IsRequired();
        builder.Property(esm => esm.Description).IsRequired();
        builder.Property(esm => esm.Modificator).IsRequired();
    }
}
