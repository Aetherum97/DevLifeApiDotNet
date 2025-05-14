using DevLife.Domain.Modules.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLife.Infrastructure.Modules.Contracts.Configurations
{
    public class ContractConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.ToTable("Contract");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.IdType)
                .IsRequired()
                .HasColumnName("IdType");
            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(c => c.ImageUrl)
                .IsRequired()
                .HasMaxLength(800);
            builder.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasOne(c => c.ContractTypes)
                .WithMany(ct => ct.Contracts)
                .HasForeignKey(c => c.IdType)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
