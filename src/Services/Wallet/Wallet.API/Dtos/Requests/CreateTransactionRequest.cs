using Wallet.Application.Transaction.Commands;

namespace Wallet.API.Dtos.Requests;

public record CreateTransactionRequest(int WalletId, string TransactionType, decimal Amount)
{
    public CreateTransactionCommand ToApplicationRequest()
    {
        return new CreateTransactionCommand(WalletId, Amount, TransactionType);
    }
}