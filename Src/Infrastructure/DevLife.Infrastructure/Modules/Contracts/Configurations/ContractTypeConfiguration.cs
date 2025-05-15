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
    public class ContractTypeConfiguration : IEntityTypeConfiguration<ContractType>
    {
        public void Configure(EntityTypeBuilder<ContractType> builder)
        {
            builder.HasKey(ct => ct.Id);
            builder.Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasMany(ct => ct.Contracts)
                .WithOne(c => c.ContractTypes)
                .HasForeignKey(ct => ct.IdType)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
