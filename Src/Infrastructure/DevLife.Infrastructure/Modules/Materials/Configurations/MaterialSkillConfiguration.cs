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
    public class MaterialSkillConfiguration : IEntityTypeConfiguration<MaterialSkill>
    {
        public void Configure(EntityTypeBuilder<MaterialSkill> builder)
        {
            builder.HasKey(ms => ms.Id);
            builder.Property(ms => ms.Name)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(ms => ms.Modificator)
                .IsRequired();

            builder.HasMany(ms => ms.Materials)
                .WithOne(m => m.MaterialSkill)
                .HasForeignKey(m => m.IdMaterialSkill)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
