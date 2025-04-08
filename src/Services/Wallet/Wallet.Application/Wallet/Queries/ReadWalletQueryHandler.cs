using MediatR;
using Wallet.Application.Wallet.Dto;
using Wallet.Domain.Interfaces;
using Wallet.Domain.Models;

namespace Wallet.Application.Wallet.Queries;

public class ReadWalletQueryHandler : IRequestHandler<ReadWalletQuery,
    ProcessResponse<WalletResponse>>
{
    #region Constructor & Properties

    private readonly IWalletRepository _walletRepository;

    public ReadWalletQueryHandler(IWalletRepository walletRepository)
    {
        _walletRepository = walletRepository;
    }

    #endregion

    #region Public Methods

    public async Task<ProcessResponse<WalletResponse>> Handle(ReadWalletQuery query,
        CancellationToken cancellationToken)
    {
        var validateWallet = await _walletRepository.GetById(query.WalletId);
        if (validateWallet == null)
        {
            return ProcessResponse<WalletResponse>.Error("The wallet not found");
        }

        var response = WalletResponse.FromEntity(validateWallet);
        return ProcessResponse.Success(response);
    }

    #endregion
}