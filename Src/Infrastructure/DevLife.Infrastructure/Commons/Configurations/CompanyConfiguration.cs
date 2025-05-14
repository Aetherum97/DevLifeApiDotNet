using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevLife.Domain.Commons.Entity;
using DevLife.Domain.Modules.Players;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevLife.Infrastructure.Commons.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).IsRequired();
        builder.Property(c => c.Experience).IsRequired();


        builder.HasMany(c => c.Employees)
            .WithOne()
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.MaterialCompany)
            .WithOne()
            .HasForeignKey(mc => mc.IdCompany)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

