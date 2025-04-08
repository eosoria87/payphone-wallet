using Wallet.Application.Wallet.Commands;

namespace Wallet.API.Dtos.Requests;

public record CreateWalletRequest(string DocumentId, string Name, decimal InitialBalance)
{
    public CreateWalletCommand ToApplicationRequest()
    {
        return new CreateWalletCommand(DocumentId, Name, InitialBalance);
    }
}