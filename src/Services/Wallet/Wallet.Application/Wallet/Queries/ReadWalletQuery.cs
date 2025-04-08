using MediatR;
using Wallet.Application.Wallet.Dto;
using Wallet.Domain.Models;

namespace Wallet.Application.Wallet.Queries;

public class ReadWalletQuery: IRequest<ProcessResponse<WalletResponse>>
{
    public int WalletId { get; }

    public ReadWalletQuery(int walletId)
    {
        WalletId = walletId;
    }
}