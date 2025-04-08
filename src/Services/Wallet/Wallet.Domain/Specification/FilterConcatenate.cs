using Wallet.Domain.SeedWork;

namespace Wallet.Domain.Specification;

public class FilterConcatenate : Enumeration
{
    public static FilterConcatenate And = new (1, nameof(And).ToLowerInvariant());
    public static FilterConcatenate Or = new (2, nameof(Or).ToLowerInvariant());

    public FilterConcatenate(int id, string name) : base(id, name)
    {
    }

    public static IEnumerable<FilterConcatenate> List()
    {
        return new[] {And, Or};
    }

    public static FilterConcatenate FromName(string name)
    {
        var state = List()
            .SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.InvariantCultureIgnoreCase));

        if (state == null)
            throw new Exception($"Possible values for comparer: {string.Join(",", List().Select(s => s.Name))}");

        return state;
    }

    public static FilterConcatenate From(int id)
    {
        var state = List().SingleOrDefault(s => s.Id == id);

        if (state == null)
            throw new Exception($"Possible values for comparer: {string.Join(",", List().Select(s => s.Name))}");

        return state;
    }
}