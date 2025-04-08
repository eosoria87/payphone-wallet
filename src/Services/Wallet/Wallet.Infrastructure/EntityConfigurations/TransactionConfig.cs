using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wallet.Domain.Entities;

namespace Wallet.Infrastructure.EntityConfigurations;

public class TransactionConfig : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("transactions");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .ValueGeneratedOnAdd(); 

        builder.Property(t => t.WalletId)
            .IsRequired();

        builder.Property(t => t.Amount)
            .IsRequired()
            .HasColumnType("decimal(18,2)"); 

        builder.Property(t => t.TransactionType)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(t => t.CreatedAt)
            .IsRequired()
            .HasColumnType("timestamp with time zone");

        builder.Property(t => t.UpdatedAt)
            .IsRequired()
            .HasColumnType("timestamp with time zone");
    }
}