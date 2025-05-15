using System;
using DevLife.Domain.Modules.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevLife.Infrastructure.Modules.Employees.Configurations;

public class EmployeeSkillConfiguration : IEntityTypeConfiguration<EmployeeSkill>
{
    public void Configure(EntityTypeBuilder<EmployeeSkill> builder)
    {
        builder.HasKey(es => es.Id);

        builder.Property(es => es.Name).IsRequired();
        builder.Property(es => es.Description).IsRequired();

        builder.HasMany(es => es.SkillModificators)
            .WithMany(sm => sm.EmployeeSkills);
    }
}
