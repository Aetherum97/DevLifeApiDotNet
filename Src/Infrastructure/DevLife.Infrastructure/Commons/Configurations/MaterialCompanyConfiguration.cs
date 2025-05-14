using DevLife.Domain.Commons.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Infrastructure.Commons.Configurations
{
    public class MaterialCompanyConfiguration : IEntityTypeConfiguration<MaterialCompany>
    {
        public void Configure(EntityTypeBuilder<MaterialCompany> builder)
        {
            builder.ToTable("MaterialCompany");
            builder.HasKey(mc => mc.Id);

            builder.HasOne(mc => mc.Employee)
                .WithMany(e => e.MaterialsCompany)
                .HasForeignKey(mc => mc.IdEmployee)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(mc => mc.Company)
                .WithMany(c => c.MaterialCompany)
                .HasForeignKey(mc => mc.IdCompany)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(mc => mc.Material)
                .WithMany(m => m.MaterialCompany)
                .HasForeignKey(mc => mc.IdMaterial)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
