using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Wallet.Domain.Entities;
using Wallet.Domain.SeedWork;
using Wallet.Infrastructure.EntityConfigurations;

namespace Wallet.Infrastructure;

public class WalletDbContext : DbContext, IUnitOfWork
{
    private readonly IConfiguration _configuration;

    public WalletDbContext(DbContextOptions<WalletDbContext> options, IConfiguration configuration) :
        base(options)
    {
        _configuration = configuration;
    }

    public WalletDbContext(DbContextOptions<WalletDbContext> options, IMediator mediator,
        IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    public DbSet<Domain.Entities.Wallet> Wallet { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        await base.SaveChangesAsync(cancellationToken);
        return true;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new WalletConfig());
        modelBuilder.ApplyConfiguration(new TransactionConfig());
    }
}