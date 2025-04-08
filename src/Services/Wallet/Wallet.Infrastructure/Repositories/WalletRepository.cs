using Wallet.Domain.Interfaces;
using Wallet.Domain.SeedWork;
using Wallet.Infrastructure.Repositories.Base;

namespace Wallet.Infrastructure.Repositories;

public class WalletRepository : EntitySqlRepository<Domain.Entities.Wallet>, IWalletRepository
{
    private readonly WalletDbContext _dbContext;

    public WalletRepository(WalletDbContext dbContext,
        IEntityFrameworkBuilder<Domain.Entities.Wallet> entityFrameworkBuilder)
        : base(dbContext, entityFrameworkBuilder)
    {
        _dbContext = dbContext;
    }

    public IUnitOfWork UnitOfWork => _dbContext;
}