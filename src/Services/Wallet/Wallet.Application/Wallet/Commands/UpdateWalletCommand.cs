using MediatR;
using Wallet.Domain.Models;

namespace Wallet.Application.Wallet.Commands;

public class UpdateWalletCommand: IRequest<ProcessResponse<bool>>
{
    public int Id { get; set; }
    public string DocumentId { get; set; }
    public string Name { get; set; }
    public decimal Balance { get; set; }

    public UpdateWalletCommand( int id, string documentId, string name, decimal balance)
    {
        Id = id;
        DocumentId = documentId;
        Name = name;
        Balance = balance;
    }
}