using MediatR;
using Microsoft.Extensions.Logging;
using Wallet.Domain.Models;

namespace Wallet.Infrastructure.Behaviors;

public class ResponseTransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<ResponseTransactionBehavior<TRequest, TResponse>> _logger;

    public ResponseTransactionBehavior(ILogger<ResponseTransactionBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var requestType = request.GetType().Name;
        _logger.LogInformation("Processing request: {RequestType}", requestType);

        var response = await next();

        if (response is ProcessResponse { IsSuccess: false } entityResponse)
        {
            _logger.LogError(
                "Request {RequestType} failed with error - Code: {ErrorCode}, Message: {ErrorMessage}",
                requestType,
                entityResponse.ErrorResponse?.Code,
                entityResponse.ErrorResponse?.Message);
        }
        else if (response is ProcessResponse { IsSuccess: true } successResponse)
        {
            _logger.LogInformation(
                "Request {RequestType} processed successfully",
                requestType);
        }
        else
        {
            _logger.LogWarning(
                "Request {RequestType} response is not a ProcessResponse: {ResponseType}",
                requestType,
                response?.GetType().Name ?? "null");
        }

        return response;
    }
}

