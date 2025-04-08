namespace Wallet.Domain.Specification;

public class FilterField<T> where T : class
{
    public string FieldName { get; }
    
    public FilterField(string fieldName)
    {
        FieldName = fieldName;
    }
}