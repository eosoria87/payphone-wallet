using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Wallet.Infrastructure.EntityConfigurations;

public class TransactionConfig : IEntityTypeConfiguration<Domain.Entities.Transaction>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Transaction> builder)
    {
        builder.ToTable("transactions");

        builder.HasKey(t => t.Id);
    }
}