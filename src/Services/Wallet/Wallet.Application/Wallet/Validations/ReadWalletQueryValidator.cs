using FluentValidation;
using Wallet.Application.Wallet.Queries;

namespace Wallet.Application.Wallet.Validations;

public class ReadWalletQueryValidator: AbstractValidator<ReadWalletQuery>
{
    public ReadWalletQueryValidator()
    {
        RuleFor(t => t.WalletId)
            .NotEmpty().WithMessage("The wallet id must not be empty.")
            .GreaterThan(0).WithMessage("The wallet id must be greater than zero.");
    }
}