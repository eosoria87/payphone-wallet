namespace Wallet.Domain.Specification;

public class Order
{
    public OrderField OrderField { get; }
    public OrderType OrderType { get; }
    
    public Order(OrderField orderField, OrderType orderType)
    {
        OrderField = orderField;
        OrderType = orderType;
    }
}