using MediatR;
using Wallet.Application.Transaction.Dto;
using Wallet.Domain.Interfaces;
using Wallet.Domain.Models;

namespace Wallet.Application.Transaction.Queries;

public class ReadTransactionQueryHandler : IRequestHandler<ReadTransactionQuery,
    ProcessResponse<List<TransactionResponse>>>
{
    #region Constructor & Properties

    private readonly IWalletRepository _walletRepository;
    private readonly ITransactionRepository _transactionRepository;

    public ReadTransactionQueryHandler(IWalletRepository walletRepository, ITransactionRepository transactionRepository)
    {
        _walletRepository = walletRepository;
        _transactionRepository = transactionRepository;
    }

    #endregion

    #region Public Methods

    public async Task<ProcessResponse<List<TransactionResponse>>> Handle(ReadTransactionQuery query,
        CancellationToken cancellationToken)
    {
        var validateWallet = await _walletRepository.GetById(query.WalletId);
        if (validateWallet == null)
        {
            return ProcessResponse<List<TransactionResponse>>.Error("The wallet not found");
        }

        var transactions = await _transactionRepository.GetTransactions(query.WalletId);
        var response = transactions.Select(TransactionResponse.FromEntity).ToList();

        return ProcessResponse.Success(response);
    }

    #endregion
}