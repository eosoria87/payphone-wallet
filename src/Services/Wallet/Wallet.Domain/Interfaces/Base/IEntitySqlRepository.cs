
namespace Wallet.Domain.Interfaces.Base;

public interface IEntitySqlRepository<T> : IBaseRepository<T> where T : class
{
    Task<T?> GetById(int id);
    T Add(T entity);
    T Update(T entity);
    void Remove(T entity);
}