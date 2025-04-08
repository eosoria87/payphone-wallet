using Wallet.Domain.Interfaces;
using Wallet.Domain.Interfaces.Base;
using Wallet.Domain.SeedWork;
using Wallet.Infrastructure.Repositories.Base;

namespace Wallet.Infrastructure.Repositories;

public class WalletRepository : EntitySqlRepository<Domain.Entities.Wallet>, IWalletRepository
{
    private readonly WalletDbContext _dbContext;

    public WalletRepository(WalletDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public IUnitOfWork UnitOfWork => _dbContext;
    
    
    public async Task<IReadOnlyCollection<Domain.Entities.Wallet>> GetWalletsByDocument(string documentId)
    {
        var wallets =  _dbContext.Wallet.Where(x => x.DocumentId.Equals(documentId)).ToList();

        return wallets;
    }
}