using MediatR;
using Wallet.Domain.Models;

namespace Wallet.Application.Wallet.Commands;

public class DeleteWalletCommand: IRequest<ProcessResponse<bool>>
{
    public int Id { get; }

    public DeleteWalletCommand(int id)
    {
        Id = id;
    }
}