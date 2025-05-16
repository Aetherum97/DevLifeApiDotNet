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
    public class ContractTemplateConfiguration : IEntityTypeConfiguration<ContractTemplate>
    {
        public void Configure(EntityTypeBuilder<ContractTemplate> builder)
        {
            builder.HasKey(ct => ct.Id);

            builder.Property(ct => ct.Title)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(ct => ct.ImageUrl)
                .IsRequired()
                .HasMaxLength(800);
            builder.Property(ct => ct.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasOne(c => c.ContractTypes)
                .WithMany(ct => ct.Contracts)
                .HasForeignKey(c => c.TypeId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
