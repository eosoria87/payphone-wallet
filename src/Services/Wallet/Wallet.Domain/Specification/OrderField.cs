namespace Wallet.Domain.Specification;

public class OrderField
{
    public string FieldName { get; }
    
    public OrderField(string fieldName)
    {
        FieldName = fieldName;
    }
}