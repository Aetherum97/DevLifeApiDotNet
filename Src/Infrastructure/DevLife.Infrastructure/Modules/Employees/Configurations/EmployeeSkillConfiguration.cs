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
        builder.HasIndex(es => es.Name).IsUnique();

        builder.Property(es => es.Name)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(es => es.Description)
            .HasMaxLength(500)
            .IsRequired();

        builder.HasMany(es => es.SkillModificators)
            .WithMany(sm => sm.EmployeeSkills);
    }
}
