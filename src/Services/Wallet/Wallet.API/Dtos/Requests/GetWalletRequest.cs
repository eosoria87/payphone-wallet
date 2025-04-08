using Wallet.Application.Wallet.Queries;

namespace Wallet.API.Dtos.Requests;

public record GetWalletRequest
{
    public ReadWalletQuery ToApplicationRequest(int walletId)
    {
        return new ReadWalletQuery(walletId);
    }
}