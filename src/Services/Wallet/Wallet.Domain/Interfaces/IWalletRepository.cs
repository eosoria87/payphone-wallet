using Wallet.Domain.Interfaces.Base;
using Wallet.Domain.SeedWork;

namespace Wallet.Domain.Interfaces;

public interface IWalletRepository: IRepository<Entities.Wallet>, IEntitySqlRepository<Entities.Wallet>
{
     Task<IReadOnlyCollection<Domain.Entities.Wallet>> GetWalletsByDocument(string documentId);
}