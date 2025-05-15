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
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Deadline);
            builder.Property(c => c.StartDate);
            builder.Property(c => c.IsAccepted);
            builder.Property(c => c.IsCompleted);
            builder.Property(c => c.Progress);
            builder.Property(c => c.Reward);
            builder.Property(c => c.IsDeleted);

            builder.HasOne(c => c.ContractTemplate)
                .WithMany(ct => ct.Contracts)
                .HasForeignKey(c => c.IdContractTemplate)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
