using Wallet.Application.Transaction.Queries;

namespace Wallet.API.Dtos.Requests;

public record GetTransactionsRequest
{
    public ReadTransactionQuery ToApplicationRequest(int walletId)
    {
        return new ReadTransactionQuery(walletId);
    }
}