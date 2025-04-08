using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Wallet.Infrastructure.EntityConfigurations;

public class WalletConfig : IEntityTypeConfiguration<Domain.Entities.Wallet>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Wallet> builder)
    {
        builder.ToTable("wallets"); 

        builder.HasKey(w => w.Id);

        builder.Property(w => w.Id)
            .ValueGeneratedOnAdd(); 

        builder.Property(w => w.DocumentId)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(w => w.Name)
            .IsRequired()
            .HasMaxLength(100); 

        builder.Property(w => w.Balance)
            .IsRequired()
            .HasColumnType("decimal(18,2)"); 

        builder.Property(w => w.CreatedAt)
            .IsRequired()
            .HasColumnType("timestamp with time zone");

        builder.Property(w => w.UpdatedAt)
            .IsRequired()
            .HasColumnType("timestamp with time zone");

        builder.HasIndex(w => w.DocumentId)
            .IsUnique();
    }
}