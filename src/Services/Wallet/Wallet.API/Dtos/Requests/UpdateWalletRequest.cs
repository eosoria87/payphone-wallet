using Wallet.Application.Wallet.Commands;

namespace Wallet.API.Dtos.Requests;

public record UpdateWalletRequest(string DocumentId, string Name, decimal InitialBalance)
{
    public UpdateWalletCommand ToApplicationRequest(int id)
    {
        return new UpdateWalletCommand(id, DocumentId, Name, InitialBalance);
    }
}