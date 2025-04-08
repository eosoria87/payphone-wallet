using FluentValidation;
using Wallet.Application.Wallet.Commands;

namespace Wallet.Application.Wallet.Validations;

public class UpdateWalletCommandValidator: AbstractValidator<UpdateWalletCommand>
{
    public UpdateWalletCommandValidator()
    {
        RuleFor(t => t.Id)
            .NotEmpty().WithMessage("The wallet id must not be empty.")
            .GreaterThan(0).WithMessage("The wallet id must be greater than zero.");
        
        RuleFor(t => t.DocumentId)
            .NotEmpty().WithMessage("The documentId must not be empty.");

        RuleFor(t => t.Name)
            .NotEmpty().WithMessage("The name must not be empty.");
        
        RuleFor(t => t.Balance)
            .NotEmpty().WithMessage("The balance must not be empty.")
            .GreaterThan(0).WithMessage("Thebalance must be greater than zero.");
    }
}