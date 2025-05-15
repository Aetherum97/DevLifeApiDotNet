using System;
using DevLife.Domain.Commons.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevLife.Infrastructure.Commons.Configurations;

public class CompanyContractConfiguration : IEntityTypeConfiguration<CompanyContract>
{
    public void Configure(EntityTypeBuilder<CompanyContract> builder)
    {
        builder.HasKey(cc => new { cc.ContractId, cc.CompanyId });
        builder.HasIndex(cc => cc.ContractId).IsUnique();

        builder.HasOne(cc => cc.Company)
            .WithMany(c => c.CompanyContracts)
            .HasForeignKey(cc => cc.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(cc => cc.Contract)
            .WithOne(c => c.CompanyContract)
            .HasForeignKey<CompanyContract>(cc => cc.ContractId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
