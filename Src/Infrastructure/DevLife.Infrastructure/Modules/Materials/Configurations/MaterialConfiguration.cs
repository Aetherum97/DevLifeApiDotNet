using DevLife.Domain.Modules.Materials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Infrastructure.Modules.Materials.Configurations
{
    public class MaterialConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.ToTable("Material");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.IdMaterialSkill)
                .IsRequired()
                .HasColumnName("IdMaterialSkill");
            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(m => m.Description)
                .IsRequired()
                .HasMaxLength(500);
            builder.Property(m => m.ImageUrl)
                .IsRequired()
                .HasMaxLength(800);

            builder.HasOne(m => m.MaterialSkill)
                .WithMany(ms => ms.Materials)
                .HasForeignKey(m => m.IdMaterialSkill)
                .OnDelete(DeleteBehavior.Cascade);

            //TODO: Add MaterialCompany Relation
        }
    }
}
