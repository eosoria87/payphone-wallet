namespace Wallet.Domain.Specification;

public class Filter
{
    public string Field { get; private set; }
    public FilterComparer Comparer { get; }
    public object? Value { get; }
    public FilterConcatenate Concatenate { get; }

    public short Group { get; private set; }

    public Filter(string field, FilterComparer comparer, FilterConcatenate? concatenate = null, object? value = null,
        short group = 0)
    {
        Field = field;
        Comparer = comparer;
        Value = value;
        Concatenate = concatenate ?? FilterConcatenate.And;
        Group = group;
    }

    public void SetField(string value)
    {
        Field = value;
    }
}