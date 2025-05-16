using DevLife.Domain.Modules.Companies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevLife.Infrastructure.Modules.Companies.Configurations;

public class PlayerConfiguration : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.HasKey(p => p.Id);
        builder.HasIndex(p => p.UserId).IsUnique();
        builder.HasIndex(p => p.CompanyId);

        builder.Property(p => p.PlayerName)
            .HasMaxLength(100)
            .IsRequired(); 

        builder.Property(p => p.IsTutorialFinished)
            .IsRequired()
            .HasColumnType("bit")
            .HasDefaultValue(true);

        builder.Property(p => p.UserId)
            .IsRequired();

        builder.HasOne(p => p.Compagny)
            .WithOne(c => c.Player)
            .HasForeignKey<Player>(p => p.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
