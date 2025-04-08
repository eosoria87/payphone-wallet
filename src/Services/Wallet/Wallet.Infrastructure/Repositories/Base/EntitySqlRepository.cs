using Microsoft.EntityFrameworkCore;
using Wallet.Domain.Entities;
using Wallet.Domain.Interfaces;
using Wallet.Domain.Interfaces.Base;

namespace Wallet.Infrastructure.Repositories.Base;

public class EntitySqlRepository<T> : IEntitySqlRepository<T>
    where T : BaseEntity
{
    private readonly DbContext _dbContext;

    protected EntitySqlRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<T?> GetById(int id)
    {
        return await _dbContext.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
    }

    public virtual T Add(T entity)
    {
        return _dbContext.Set<T>().Add(entity).Entity;
    }

    public virtual async Task AddRange(IEnumerable<T> entities)
    {
        await _dbContext.Set<T>().AddRangeAsync(entities);
    }

    public virtual T Update(T entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;
        return _dbContext.Set<T>().Update(entity).Entity;
    }

    public virtual void Remove(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
    }
}