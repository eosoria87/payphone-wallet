using MediatR;
using Wallet.Application.Wallet.Dto;
using Wallet.Domain.Models;

namespace Wallet.Application.Wallet.Queries;

public class ReadWalletsQuery: IRequest<ProcessResponse<List<WalletResponse>>>
{
    public string DocumentId { get; }

    public ReadWalletsQuery(string documentId)
    {
        DocumentId = documentId;
    }
}