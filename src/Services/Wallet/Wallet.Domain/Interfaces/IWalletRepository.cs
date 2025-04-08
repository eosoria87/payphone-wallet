using Wallet.Domain.SeedWork;

namespace Wallet.Domain.Interfaces;

public interface IWalletRepository: IRepository<Entities.Wallet>, IEntitySqlRepository<Entities.Wallet>
{
    
}