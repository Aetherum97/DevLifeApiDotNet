using DevLife.Domain.Commons.Entity;
using DevLife.Domain.Modules.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevLife.Infrastructure.Commons.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Salary).IsRequired();
        builder.Property(e => e.Experience).IsRequired();
        builder.Property(e => e.Level).IsRequired();
        builder.Property(e => e.CFrontEnd).IsRequired();
        builder.Property(e => e.CBackEnd).IsRequired();
        builder.Property(e => e.CDevops).IsRequired();
        builder.Property(e => e.CDatabase).IsRequired();
        builder.Property(e => e.IsAvalaible).IsRequired();

    }
}

