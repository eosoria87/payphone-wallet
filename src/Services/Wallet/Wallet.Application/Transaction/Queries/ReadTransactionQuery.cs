using MediatR;
using Wallet.Application.Transaction.Dto;
using Wallet.Domain.Models;

namespace Wallet.Application.Transaction.Queries;

public class ReadTransactionQuery: IRequest<ProcessResponse<List<TransactionResponse>>>
{
    public int WalletId { get; }

    public ReadTransactionQuery(int walletId)
    {
        WalletId = walletId;
    }
}