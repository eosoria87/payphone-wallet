using System.Linq.Expressions;
using Wallet.Domain.Specification;

namespace Wallet.Domain.Interfaces.Base;

public interface IEntityFrameworkBuilder<T> where T : class
{
    Expression<Func<T, bool>>? GetWhereExpression(List<Specification<T>> specifications);

    Task<List<T>> ToListOrderedPagedValues(IQueryable<T> query, Criteria<T> criteria);
}