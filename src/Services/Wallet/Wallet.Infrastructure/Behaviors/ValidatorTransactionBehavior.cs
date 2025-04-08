using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Wallet.Infrastructure.Behaviors;

public class ValidatorTransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<ValidatorTransactionBehavior<TRequest, TResponse>> _logger;
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidatorTransactionBehavior(IEnumerable<IValidator<TRequest>> validators,
        ILogger<ValidatorTransactionBehavior<TRequest, TResponse>> logger)
    {
        _validators = validators ?? throw new ArgumentNullException(nameof(validators));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            _logger.LogInformation("No validators found for request: {RequestType}", request.GetType().Name);
            return await next();
        }

        var typeName = request.GetType().Name;

        _logger.LogInformation("Validating request: {RequestType}", typeName);

        var context = new ValidationContext<TRequest>(request);
        var validationResults = await Task.WhenAll(
            _validators.Select(v => v.ValidateAsync(context, cancellationToken))
        );
        var failures = validationResults
            .SelectMany(result => result.Errors)
            .Where(error => error != null)
            .ToList();

        if (!failures.Any())
        {
            _logger.LogInformation("Validation passed for request: {RequestType}", typeName);
            return await next();
        }

        _logger.LogError(
            "Validation errors for request: {RequestType} - Request: {@Request} - Errors: {@ValidationErrors}",
            typeName, request, failures);

        throw new FluentValidation.ValidationException(failures);
    }
}

public static class TypeExtensions
{
    public static string GetGenericTypeName(this object obj)
    {
        var type = obj.GetType();
        if (!type.IsGenericType)
            return type.Name;

        var genericArguments = type.GetGenericArguments();
        var typeName = type.Name.Substring(0, type.Name.IndexOf('`'));
        var argumentNames = genericArguments.Select(t => t.Name).ToArray();
        return $"{typeName}<{string.Join(", ", argumentNames)}>";
    }
}