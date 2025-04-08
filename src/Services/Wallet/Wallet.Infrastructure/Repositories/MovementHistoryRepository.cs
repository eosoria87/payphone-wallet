using Wallet.Domain.Interfaces;
using Wallet.Domain.SeedWork;
using Wallet.Infrastructure.Repositories.Base;

namespace Wallet.Infrastructure.Repositories;

public class MovementHistoryRepository: EntitySqlRepository<Domain.Entities.MovementHistory>, IMovementHistoryRepository
{
    private readonly WalletDbContext _dbContext;

    public MovementHistoryRepository(WalletDbContext dbContext,
        IEntityFrameworkBuilder<Domain.Entities.MovementHistory> entityFrameworkBuilder)
        : base(dbContext, entityFrameworkBuilder)
    {
        _dbContext = dbContext;
    }

    public IUnitOfWork UnitOfWork => _dbContext;
}