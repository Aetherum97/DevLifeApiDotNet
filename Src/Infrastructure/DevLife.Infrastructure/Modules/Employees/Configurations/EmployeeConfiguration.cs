using DevLife.Domain.Modules.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevLife.Infrastructure.Modules.Employees.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(en => en.Id);

        builder.Property(en=> en.Salary).IsRequired();
        builder.Property(en => en.Experience).IsRequired();
        builder.Property(en => en.Level).IsRequired();
        builder.Property(en => en.CFrontEnd).IsRequired();
        builder.Property(en => en.CBackEnd).IsRequired();
        builder.Property(en => en.CDevops).IsRequired();
        builder.Property(en => en.CDatabase).IsRequired();
        builder.Property(en => en.IsAvalaible).IsRequired();

        builder.HasOne(en => en.EmployeeName)
            .WithMany(en => en.Employees)
            .HasForeignKey(e => e.EmployeeNameId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(e => e.EmployeeSkills)
            .WithMany(s => s.Employees);
    }
}

