using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Wallet.Domain.Entities;
using Wallet.Domain.Interfaces;
using Wallet.Domain.Specification;

namespace Wallet.Infrastructure.Repositories.Base;

public class EntitySqlRepository<T> : IEntitySqlRepository<T>
    where T : BaseEntity
{
    private readonly DbContext _dbContext;
    private readonly IEntityFrameworkBuilder<T> _entityFrameworkBuilder;

    protected EntitySqlRepository(DbContext dbContext, IEntityFrameworkBuilder<T> entityFrameworkBuilder)
    {
        _dbContext = dbContext;
        _entityFrameworkBuilder = entityFrameworkBuilder;
    }

    protected async Task<IReadOnlyCollection<T>> GetAllWithInclude(IQueryable<T> baseQuery, Criteria<T> criteria)
    {
        var whereExpression = _entityFrameworkBuilder.GetWhereExpression(criteria.Specifications);
        if (whereExpression != null)
        {
            baseQuery = baseQuery.Where(whereExpression);
        }

        var result = await _entityFrameworkBuilder.ToListOrderedPagedValues(baseQuery, criteria);
        return result;
    }

    public virtual async Task<IReadOnlyCollection<T>> GetAllWithReload(Criteria<T>? criteria = null)
    {
        criteria ??= new Criteria<T>();

        foreach (var entity in _dbContext.ChangeTracker.Entries<T>().ToList())
        {
            await entity.ReloadAsync();
        }

        return await GetAll(criteria);
    }


    public virtual async Task<T?> GetById(Guid id)
    {
        return await _dbContext.Set<T>().FirstOrDefaultAsync(e => e.Id.Equals(id));
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

    public virtual void UpdateRange(IEnumerable<T> entities)
    {
        _dbContext.Set<T>().UpdateRange(entities);
    }

    public virtual void Remove(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
    }

    public virtual async Task Remove(Guid id)
    {
        var entity = await GetById(id);
        if (entity != null)
        {
            Remove(entity);
        }
    }

    public virtual void RemoveRange(IEnumerable<T> entities)
    {
        _dbContext.Set<T>().RemoveRange(entities);
    }

    public async Task<IReadOnlyCollection<T>> GetAll(Criteria<T> criteria = null,
        List<Expression<Func<T, object>>> includes = null, List<string> includesStr = null, bool asNoTracking = true)
    {
        criteria ??= new Criteria<T>();

        var baseQuery = asNoTracking
            ? _dbContext.Set<T>().AsQueryable().AsNoTracking()
            : _dbContext.Set<T>().AsQueryable();

        if (includes != null && includes.Any())
        {
            baseQuery = includes.Aggregate(baseQuery, (current, include) => current.Include(include));
        }

        if (includesStr != null && includesStr.Any())
        {
            baseQuery = includesStr.Aggregate(baseQuery, (current, include) => current.Include(include));
        }

        if (!criteria.Orders.Any(o => o.OrderField.FieldName.Equals("CreatedAt")))
        {
            criteria.AddOrder(new OrderBy("CreatedAt", OrderType.Desc));
        }

        var whereExpression = _entityFrameworkBuilder.GetWhereExpression(criteria.Specifications);
        if (whereExpression != null)
        {
            baseQuery = baseQuery.Where(whereExpression);
        }

        if (criteria.Where != null)
        {
            baseQuery = baseQuery.Where(criteria.Where);
        }

        var result = await _entityFrameworkBuilder.ToListOrderedPagedValues(baseQuery, criteria);

        return result;
    }

    public async Task<int> Count(Criteria<T> criteria = null, List<Expression<Func<T, object>>> includes = null,
        List<string> includesStr = null)
    {
        var baseQuery = _dbContext.Set<T>().AsQueryable().AsNoTracking();

        if (includes != null && includes.Any())
        {
            baseQuery = includes.Aggregate(baseQuery, (current, include) => current.Include(include));
        }

        if (includesStr != null && includesStr.Any())
        {
            baseQuery = includesStr.Aggregate(baseQuery, (current, include) => current.Include(include));
        }

        var whereExpression = _entityFrameworkBuilder.GetWhereExpression(criteria?.Specifications);
        if (whereExpression != null)
        {
            baseQuery = baseQuery.Where(whereExpression);
        }

        if (criteria?.Where != null)
        {
            baseQuery = baseQuery.Where(criteria.Where);
        }

        return await baseQuery.CountAsync();
    }
}