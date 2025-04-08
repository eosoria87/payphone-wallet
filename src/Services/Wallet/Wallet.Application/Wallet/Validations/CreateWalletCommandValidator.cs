using Wallet.Application.Wallet.Commands;
using FluentValidation;

namespace Wallet.Application.Wallet.Validations;

public class CreateWalletCommandValidator: AbstractValidator<CreateWalletCommand>
{
    public CreateWalletCommandValidator()
    {
        RuleFor(t => t.DocumentId)
            .NotEmpty().WithMessage("The documentId must not be empty.");

        RuleFor(t => t.Name)
            .NotEmpty().WithMessage("The name must not be empty.");
        
        RuleFor(t => t.InitialBalance)
            .NotEmpty().WithMessage("The initial balance must not be empty.")
            .GreaterThan(0).WithMessage("The initial balance must be greater than zero.");
    }
}