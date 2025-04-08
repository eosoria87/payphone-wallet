using System.Linq.Expressions;

namespace Wallet.Domain.Specification;

public class Criteria<T> where T : class
{
    public List<Specification<T>> Specifications { get; }
    public List<Order> Orders { get; }
    public int Page { get; private set; }
    public int PageSize { get; private set; }
    public Expression<Func<T, bool>>? Where { get; }

    public Criteria(List<Filter>? filters = null, List<OrderBy>? orderByList = null, int? page = null,
        int? pageSize = null, Expression<Func<T, bool>>? where = null)
    {
        filters ??= new List<Filter>();
        Specifications = GetSpecifications(filters);
        orderByList ??= new List<OrderBy>();
        Orders = GetOrders(orderByList);
        Page = page ?? 0;
        PageSize = pageSize ?? int.MaxValue;
        Where = where;
    }

    public void AddFilter(Filter filter)
    {
        Specifications.Add(GetSpecification(filter));
    }

    public void AddFilters(IEnumerable<Filter> filters)
    {
        Specifications.AddRange(filters.Select(GetSpecification).ToList());
    }

    private static Specification<T> GetSpecification(Filter filter)
    {
        return new Specification<T>(
            new FilterField<T>(filter.Field),
            filter.Comparer,
            filter.Concatenate,
            filter.Value,
            filter.Group);
    }

    private static List<Specification<T>> GetSpecifications(IEnumerable<Filter> filters)
    {
        return filters.Select(GetSpecification).ToList();
    }

    public void AddOrder(OrderBy orderBy)
    {
        Orders.Add(GetOrder(orderBy));
    }

    private static Order GetOrder(OrderBy orderBy)
    {
        return new Order(new OrderField(orderBy.Field), orderBy.OrderType);
    }

    private static List<Order> GetOrders(IEnumerable<OrderBy> orderByList)
    {
        return orderByList.Select(GetOrder).ToList();
    }

    public void SetPage(int value)
    {
        Page = value;
    }

    public void SetPageSize(int value)
    {
        PageSize = value;
    }
}