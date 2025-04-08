using FluentValidation;
using Wallet.Application.Wallet.Commands;

namespace Wallet.Application.Wallet.Validations;

public class DeleteWalletCommandValidator : AbstractValidator<DeleteWalletCommand>
{
    public DeleteWalletCommandValidator()
    {
        RuleFor(t => t.Id)
            .NotEmpty().WithMessage("The Id must not be empty.")
            .GreaterThan(0).WithMessage("The Id must be greater than zero.");
    }
}