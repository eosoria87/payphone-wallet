using MediatR;
using Wallet.Domain.Interfaces;
using Wallet.Domain.Models;

namespace Wallet.Application.TransactionWallet.Commands;

public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, ProcessResponse<bool>>
{
    #region Constructor & Properties

    private readonly IWalletRepository _walletRepository;
    private readonly ITransactionRepository _transactionRepository;

    public CreateTransactionCommandHandler(IWalletRepository walletRepository,
        ITransactionRepository transactionRepository)
    {
        _walletRepository = walletRepository;
        _transactionRepository = transactionRepository;
    }

    #endregion

    #region Public Methods

    public async Task<ProcessResponse<bool>> Handle(CreateTransactionCommand command,
        CancellationToken cancellationToken)
    {
        var validateWallet = await _walletRepository.GetById(command.WalletId);
        if (validateWallet == null)
        {
            return ProcessResponse<bool>.Error("The wallet not found");
        }

        var transactionProcess = await TransactionProcess(command, cancellationToken, validateWallet);
        if (!transactionProcess.IsSuccess)
        {
            return ProcessResponse<bool>.Error(transactionProcess);
        }

        return ProcessResponse.Success(true);
    }

    private async Task<ProcessResponse<bool>> TransactionProcess(CreateTransactionCommand command,
        CancellationToken cancellationToken,
        Domain.Entities.Wallet validateWallet)
    {
        if (command.TransactionType.Equals("credit"))
        {
            validateWallet.Balance += command.Amount;
        }

        if (command.TransactionType.Equals("debit"))
        {
            if (validateWallet.Balance < command.Amount)
            {
                return ProcessResponse<bool>.Error("The wallet does not have enough balance");
            }

            validateWallet.Balance -= command.Amount;
        }

        await Update(validateWallet, cancellationToken);
        await CreateTransaction(command, cancellationToken);
        
        return ProcessResponse.Success(true);
    }

    #endregion

    #region Private methods

    private async Task Update(Domain.Entities.Wallet wallet, CancellationToken cancellationToken)
    {
        _walletRepository.Update(wallet);
        await _walletRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }

    private async Task CreateTransaction(CreateTransactionCommand command, CancellationToken cancellationToken)
    {
        var transaction =
            new Domain.Entities.Transaction(command.WalletId, command.Amount, command.TransactionType);

        _transactionRepository.Add(transaction);
        await _walletRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
    }

    #endregion
}