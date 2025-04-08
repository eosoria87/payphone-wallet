using Wallet.Application.Wallet.Commands;

namespace Wallet.API.Dtos.Requests;

public record DeleteWalletRequest
{
    public DeleteWalletCommand ToApplicationRequest(int walletId)
    {
        return new DeleteWalletCommand(walletId);
    }
}