using System.Linq.Expressions;
using Wallet.Domain.SeedWork;

namespace Wallet.Domain.Specification;

public class FilterComparer : Enumeration
{
    #region Enumerators

    public static FilterComparer Equal = new (1, "=", Expression.Equal);
    public static FilterComparer NotEqual = new (2, "!=", Expression.NotEqual);
    public static FilterComparer GreaterThanOrEqual = new (3, ">=", Expression.GreaterThanOrEqual);
    public static FilterComparer LessThanOrEqual = new (4, "<=", Expression.LessThanOrEqual);
    public static FilterComparer GreaterThan = new (5, ">", Expression.GreaterThan);
    public static FilterComparer LessThan = new (6, "<", Expression.LessThan);
    public static FilterComparer Contains = new (7, nameof(Contains));
    public static FilterComparer NotContains = new (8, nameof(NotContains), isNegative: true);
    public static FilterComparer EqualString = new (9, nameof(EqualString));

    #endregion

    #region Constructor & properties

    public Func<Expression, Expression, BinaryExpression>? OperatorExpression { get; }
    public bool IsNegative { get; }

    public FilterComparer(int id, string name, Func<Expression, Expression, BinaryExpression>? expression = null,
        bool isNegative = false) : base(id, name)
    {
        OperatorExpression = expression;
        IsNegative = isNegative;
    }

    public static FilterComparer FromName(string name)
    {
        var state = List()
            .SingleOrDefault(filterOperator =>
                string.Equals(filterOperator.Name, name, StringComparison.InvariantCultureIgnoreCase));

        if (state == null)
        {
            throw new Exception($"Possible values for operator: {string.Join(",", List().Select(s => s.Name))}");
        }

        return state;
    }

    public static FilterComparer From(int id)
    {
        var state = List().SingleOrDefault(s => s.Id == id);

        if (state == null)
            throw new Exception($"Possible values for operator: {string.Join(",", List().Select(s => s.Name))}");

        return state;
    }

    public static IEnumerable<FilterComparer> List()
    {
        return new[]
        {
            Equal, NotEqual, GreaterThan, LessThan, GreaterThanOrEqual, LessThanOrEqual, Contains,
            NotContains, EqualString
        };
    }

    #endregion
}