using MediatR;
using Wallet.Domain.Models;

namespace Wallet.Application.Wallet.Commands;

public class CreateWalletCommand: IRequest<ProcessResponse<bool>>
{
    public string DocumentId { get; set; }
    public string Name { get; set; }
    public decimal InitialBalance { get; set; }

    public CreateWalletCommand( string documentId, string name, decimal initialBalance)
    {
        DocumentId = documentId;
        Name = name;
        InitialBalance = initialBalance;
    }
}