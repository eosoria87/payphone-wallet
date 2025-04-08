using MediatR;
using Wallet.Domain.Interfaces;
using Wallet.Domain.Models;

namespace Wallet.Application.Wallet.Commands;

public class UpdateWalletCommandHandler : IRequestHandler<UpdateWalletCommand, ProcessResponse<bool>>
{
    #region Constructor & Properties

    private readonly IWalletRepository _walletRepository;

    public UpdateWalletCommandHandler(IWalletRepository patientRepository)
    {
        _walletRepository = patientRepository;
    }

    #endregion

    #region Public Methods

    public async Task<ProcessResponse<bool>> Handle(UpdateWalletCommand command,
        CancellationToken cancellationToken)
    {
        var validateWallet = await _walletRepository.GetById(command.Id);
        if (validateWallet == null)
        {
            return ProcessResponse<bool>.Error("The wallet not found");
        }
        
        validateWallet.Name = command.Name;
        validateWallet.Balance = command.Balance;

        _walletRepository.Update(validateWallet);
        await _walletRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        return ProcessResponse.Success(true);
    }

    #endregion
}