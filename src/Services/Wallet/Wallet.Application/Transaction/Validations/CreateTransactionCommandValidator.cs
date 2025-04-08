using FluentValidation;
using Wallet.Application.Transaction.Commands;

namespace Wallet.Application.Transaction.Validations;

public class CreateTransactionCommandValidator: AbstractValidator<CreateTransactionCommand>
{
    public CreateTransactionCommandValidator()
    {
        RuleFor(t => t.WalletId)
            .NotEmpty().WithMessage("The walletId must not be empty.");

        RuleFor(t => t.TransactionType)
            .NotEmpty().WithMessage("The transaction type must not be empty.")
            .Must(value => value == "credit" || value == "debit")
            .WithMessage("The transaction type must be either 'credit' or 'debit'.");
        
        RuleFor(t => t.Amount)
            .NotEmpty().WithMessage("The amount must not be empty.")
            .GreaterThan(0).WithMessage("The amount must be greater than zero.");
    }
}