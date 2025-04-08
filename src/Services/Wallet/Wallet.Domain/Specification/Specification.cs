namespace Wallet.Domain.Specification;

public class Specification<T> where T : class
{
    public FilterField<T> FilterField { get; }
    public FilterComparer Comparer { get; }
    public FilterConcatenate Concatenate { get; }
    public object Value { get; }
    public short Group { get; }
    
    public Specification(FilterField<T> filterField, FilterComparer comparer,
        FilterConcatenate concatenate, object value, short group)
    {
        FilterField = filterField;
        Comparer = comparer;
        Concatenate = concatenate;
        Value = value;
        Group = group;
    }
}