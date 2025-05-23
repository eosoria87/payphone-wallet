using Wallet.Domain.Interfaces;
using Wallet.Domain.SeedWork;
using Wallet.Infrastructure.Repositories.Base;

namespace Wallet.Infrastructure.Repositories;

public class TransactionRepository: EntitySqlRepository<Domain.Entities.Transaction>, ITransactionRepository
{
    private readonly WalletDbContext _dbContext;

    public TransactionRepository(WalletDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public IUnitOfWork UnitOfWork => _dbContext;
    
    public async Task<IReadOnlyCollection<Domain.Entities.Transaction>> GetTransactions(int walletId)
    {
        var transaction =  _dbContext.Transactions.Where(x => x.WalletId ==  walletId).ToList();

        return transaction;
    }
}