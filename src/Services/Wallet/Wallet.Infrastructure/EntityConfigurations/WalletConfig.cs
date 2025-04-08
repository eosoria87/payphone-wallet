using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Wallet.Infrastructure.EntityConfigurations;

public class WalletConfig: IEntityTypeConfiguration<Domain.Entities.Wallet>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Wallet> builder)
    {
        builder.ToTable("wallet");

        builder.HasKey(t => t.Id);
    }
}