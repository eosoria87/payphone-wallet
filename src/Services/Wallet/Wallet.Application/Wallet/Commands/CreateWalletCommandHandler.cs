using MediatR;
using Wallet.Domain.Interfaces;
using Wallet.Domain.Models;

namespace Wallet.Application.Wallet.Commands;

public class CreateWalletCommandHandler : IRequestHandler<CreateWalletCommand, ProcessResponse<bool>>
{
    #region Constructor & Properties

    private readonly IWalletRepository _walletRepository;

    public CreateWalletCommandHandler(IWalletRepository walletRepository)
    {
        _walletRepository = walletRepository;
    }

    #endregion

    #region Public Methods

    public async Task<ProcessResponse<bool>> Handle(CreateWalletCommand command,
        CancellationToken cancellationToken)
    {
        // 1. Validate Identification already Exist and validate Name
        // 3. Create wallet
        await CreateWallet(command, cancellationToken);

        return ProcessResponse.Success(true);
    }

    #endregion

    #region Private methods

    private async Task CreateWallet(CreateWalletCommand command,
        CancellationToken cancellationToken)
    {
        var wallet = new Domain.Entities.Wallet(command.DocumentId, command.Name, command.InitialBalance);

        _walletRepository.Add(wallet);
        await _walletRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }

    #endregion
}