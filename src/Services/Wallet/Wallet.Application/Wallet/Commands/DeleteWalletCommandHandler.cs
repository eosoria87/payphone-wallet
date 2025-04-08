using MediatR;
using Wallet.Domain.Interfaces;
using Wallet.Domain.Models;

namespace Wallet.Application.Wallet.Commands;

public class DeleteWalletCommandHandler: IRequestHandler<DeleteWalletCommand, ProcessResponse<bool>>
{
    #region Constructor & Properties

    private readonly IWalletRepository _walletRepository;

    public DeleteWalletCommandHandler(IWalletRepository patientRepository)
    {
        _walletRepository = patientRepository;
    }

    #endregion

    #region Public Methods

    public async Task<ProcessResponse<bool>> Handle(DeleteWalletCommand command,
        CancellationToken cancellationToken)
    {
        var validateWallet = await _walletRepository.GetById(command.Id);
        if (validateWallet == null)
        {
            return ProcessResponse<bool>.Error("The wallet not found");
        }

        _walletRepository.Remove(validateWallet);
        await _walletRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        return ProcessResponse.Success(true);
    }

    #endregion
}