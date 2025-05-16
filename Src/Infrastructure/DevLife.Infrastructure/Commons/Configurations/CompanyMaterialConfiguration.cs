using System;
using DevLife.Domain.Commons.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevLife.Infrastructure.Commons.Configurations;

public class CompanyMaterialConfiguration : IEntityTypeConfiguration<CompanyMaterial>
{
    public void Configure(EntityTypeBuilder<CompanyMaterial> builder)
    {
        builder.HasKey(cm => new { cm.MaterialId, cm.CompanyId });
        builder.HasIndex(cm => cm.MaterialId).IsUnique();

        builder.HasOne(cm => cm.Company)
            .WithMany(c => c.CompanyMaterials)
            .HasForeignKey(cm => cm.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(cm => cm.Material)
            .WithOne(m => m.CompanyMaterial)
            .HasForeignKey<CompanyMaterial>(cm => cm.MaterialId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
