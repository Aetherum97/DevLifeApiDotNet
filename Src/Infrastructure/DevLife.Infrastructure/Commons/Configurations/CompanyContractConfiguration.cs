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
    public class CompanyContractConfiguration : IEntityTypeConfiguration<CompanyContract>
    {
        public void Configure(EntityTypeBuilder<CompanyContract> builder)
        {
            builder.ToTable("CompanyContract");
            builder.HasKey(cc => cc.Id);
            builder.Property(cc => cc.IdCompany)
                .IsRequired()
                .HasColumnName("IdCompany");
            builder.Property(cc => cc.IdContract)
                .IsRequired()
                .HasColumnName("IdContract");
            builder.Property(cc => cc.Deadline);
            builder.Property(cc => cc.IsAccepted);
            builder.Property(cc => cc.IsCompleted);
            builder.Property(cc => cc.Progress);
            builder.Property(cc => cc.StartDate);
            builder.Property(cc => cc.Reward);

            //TODO: Add Relation for company and employee

                
        }
    }
}
