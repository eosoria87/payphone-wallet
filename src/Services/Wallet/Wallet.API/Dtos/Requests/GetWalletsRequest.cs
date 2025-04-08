using Wallet.Application.Wallet.Queries;

namespace Wallet.API.Dtos.Requests;

public record GetWalletsRequest
{
    public ReadWalletsQuery ToApplicationRequest(string documentId)
    {
        return new ReadWalletsQuery(documentId);
    }
}