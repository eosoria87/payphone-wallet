namespace Wallet.Domain.Entities;

public class Transaction : BaseEntity
{
    public int WalletId { get; set; }
    public Wallet Wallet { get; set; }
    public decimal Amount { get; set; }
    public string TransactionType { get; set; }

    public Transaction()
    {
    }

    public Transaction(int walletId, decimal amount, string transactionType) : this()
    {
        WalletId = walletId;
        Amount = amount;
        TransactionType = transactionType;
    }
}