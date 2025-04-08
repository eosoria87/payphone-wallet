using Wallet.Domain.Entities;
using Wallet.Domain.SeedWork;

namespace Wallet.Domain.Interfaces;

public interface IMovementHistoryRepository: IRepository<MovementHistory>, IEntitySqlRepository<Entities.MovementHistory>
{
    
}