namespace Wallet.Application.TransactionWallet.Dto;

public class TransactionResponse
{
    public int WalletId { get; set; }
    public string WalletName { get; set; }
    public decimal Amount { get; set; }
    public string TransactionType { get; set; }

    public TransactionResponse(int walletId, string walletName, decimal amount, string transactionType)
    {
        WalletId = walletId;
        WalletName = walletName;
        Amount = amount;
        TransactionType = transactionType;
    }

    public static TransactionResponse FromEntity(Domain.Entities.Transaction entity)
    {
        return new TransactionResponse(entity.Id, entity.Wallet.Name, entity.Amount, entity.TransactionType);
    }
}