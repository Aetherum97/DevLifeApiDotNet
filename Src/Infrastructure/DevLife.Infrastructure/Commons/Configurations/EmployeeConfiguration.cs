using DevLife.Domain.Commons.Entity;
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

        builder.HasOne(e => e.Company)
            .WithMany()
            .HasForeignKey(e => e.CompanyId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.EmployeeName)
            .WithMany()
            .HasForeignKey(e => e.NameId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(e => e.CompanyContracts).WithMany();

        builder.HasMany(e => e.EmployeeSkills).WithMany();

        builder.HasMany(e => e.MaterialsCompany)
              .WithOne()
              .HasForeignKey(mc => mc.IdEmployee)
              .IsRequired()
              .OnDelete(DeleteBehavior.Cascade);
    }
}

