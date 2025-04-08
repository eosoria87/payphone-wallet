using MediatR;
using Wallet.Application.TransactionWallet.Dto;
using Wallet.Domain.Models;

namespace Wallet.Application.TransactionWallet.Queries;

public class ReadTransactionQuery: IRequest<ProcessResponse<List<TransactionResponse>>>
{
    public int WalletId { get; }

    public ReadTransactionQuery(int walletId)
    {
        WalletId = walletId;
    }
}