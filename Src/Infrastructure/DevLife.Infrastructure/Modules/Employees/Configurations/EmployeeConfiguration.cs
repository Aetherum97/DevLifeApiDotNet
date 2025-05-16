using DevLife.Domain.Modules.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevLife.Infrastructure.Modules.Employees.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(en => en.Id);

        builder.Property(en => en.Salary)
            .IsRequired()
            .HasColumnType("int")
            .HasDefaultValue(0);

        builder.Property(en => en.Experience)
            .IsRequired()
            .HasColumnType("int")
            .HasDefaultValue(0);

        builder.Property(en => en.Level)
            .IsRequired()
            .HasColumnType("int")
            .HasDefaultValue(1);

        builder.Property(en => en.CFrontEnd)
            .IsRequired()
            .HasColumnType("int")
            .HasDefaultValue(0);

        builder.Property(en => en.CBackEnd)
            .IsRequired()
            .HasColumnType("int")
            .HasDefaultValue(0);

        builder.Property(en => en.CDevops)
            .IsRequired()
            .HasColumnType("int")
            .HasDefaultValue(0);

        builder.Property(en => en.CDatabase)
            .IsRequired()
            .HasColumnType("int")
            .HasDefaultValue(0);

        builder.Property(en => en.IsAvalaible)
            .IsRequired()
            .HasColumnType("bit")
            .HasDefaultValue(true);

        builder.HasOne(en => en.EmployeeName)
            .WithMany(en => en.Employees)
            .HasForeignKey(e => e.EmployeeNameId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(e => e.EmployeeSkills)
            .WithMany(s => s.Employees);
    }
}

