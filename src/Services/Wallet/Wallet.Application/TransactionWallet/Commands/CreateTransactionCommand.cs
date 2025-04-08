using MediatR;
using Wallet.Domain.Models;

namespace Wallet.Application.TransactionWallet.Commands;

public class CreateTransactionCommand: IRequest<ProcessResponse<bool>>
{
    public int WalletId { get; set; }
    public decimal Amount { get; set; }
    public string TransactionType { get; set; }

    public CreateTransactionCommand(int walletId, decimal amount, string transactionType)
    {
        WalletId = walletId;
        Amount = amount;
        TransactionType = transactionType;
    }
}