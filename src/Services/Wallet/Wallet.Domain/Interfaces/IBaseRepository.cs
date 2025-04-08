using System.Linq.Expressions;
using Wallet.Domain.Specification;

namespace Wallet.Domain.Interfaces;

public interface IBaseRepository<T> where T : class
{
    Task<IReadOnlyCollection<T>> GetAll(Criteria<T>? criteria = null, List<Expression<Func<T, object>>>? includes = null, List<string>? includesStr = null, bool asNoTracking = true);
    Task<int> Count(Criteria<T>? criteria = null, List<Expression<Func<T, object>>>? includes = null, List<string>? includesStr = null);
}