using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Wallet.Infrastructure.EntityConfigurations;

public class MovementHistoryConfig : IEntityTypeConfiguration<Domain.Entities.MovementHistory>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.MovementHistory> builder)
    {
        builder.ToTable("movement_history");

        builder.HasKey(t => t.Id);
    }
}