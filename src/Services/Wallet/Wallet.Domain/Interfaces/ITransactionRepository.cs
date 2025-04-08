using Wallet.Domain.Entities;
using Wallet.Domain.Interfaces.Base;
using Wallet.Domain.SeedWork;

namespace Wallet.Domain.Interfaces;

public interface ITransactionRepository: IRepository<Transaction>, IEntitySqlRepository<Transaction>
{
    Task<IReadOnlyCollection<Transaction>> GetTransactions(int walletId);
}