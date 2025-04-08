using MediatR;
using Wallet.Application.Wallet.Dto;
using Wallet.Domain.Interfaces;
using Wallet.Domain.Models;

namespace Wallet.Application.Wallet.Queries;

public class ReadWalletsQueryHandler : IRequestHandler<ReadWalletsQuery,
    ProcessResponse<List<WalletResponse>>>
{
    #region Constructor & Properties

    private readonly IWalletRepository _walletRepository;

    public ReadWalletsQueryHandler(IWalletRepository walletRepository)
    {
        _walletRepository = walletRepository;
    }

    #endregion

    #region Public Methods

    public async Task<ProcessResponse<List<WalletResponse>>> Handle(ReadWalletsQuery query,
        CancellationToken cancellationToken)
    {
        var wallets = await _walletRepository.GetWalletsByDocument(query.DocumentId);

        var walletResponse = wallets.Select(WalletResponse.FromEntity).ToList();

        return ProcessResponse.Success(walletResponse);
    }

    #endregion
}