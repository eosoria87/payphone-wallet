namespace Wallet.Domain.Entities;

public class MovementHistory : BaseEntity
{
    public int WalletId { get; set; }
    public Wallet Wallet { get; set; }
    public decimal Amount { get; set; }
    public MovementType Type { get; set; }

    public MovementHistory()
    {
    }

    public MovementHistory(int walletId, decimal amount, MovementType type) : this()
    {
        WalletId = walletId;
        Amount = amount;
        Type = type;
    }
}