using Wallet.Domain.Specification;

namespace Wallet.Domain.Interfaces;

public interface IEntitySqlRepository<T> : IBaseRepository<T> where T : class
{
    Task<IReadOnlyCollection<T>> GetAllWithReload(Criteria<T>? criteria = null);
    Task<T?> GetById(Guid id);
    T Add(T entity);
    Task AddRange(IEnumerable<T> entities);
    T Update(T entity);
    void UpdateRange(IEnumerable<T> entities);
    void Remove(T entity);
    Task Remove(Guid id);
    void RemoveRange(IEnumerable<T> entities);
}