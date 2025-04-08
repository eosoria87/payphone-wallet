using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wallet.API.Dtos.Requests;
using Wallet.Application.Transaction.Dto;
using Wallet.Domain.Models;

namespace Wallet.API.Controllers;

[Route("transactions")]
[ApiController]
public class TransactionController : ControllerBase
{
    #region Constructor & properties

    private readonly ILogger<TransactionController> _logger;
    private readonly IMediator _mediator;

    public TransactionController(ILogger<TransactionController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    #endregion


    /// <summary>
    ///     Create transaction
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     POST /transactions
    ///     {
    ///         "walletId": 1,
    ///         "transactionType": "credit",
    ///         "amount": 10
    ///     }
    /// </remarks>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Produces(typeof(bool))]
    [ProducesErrorResponseType(typeof(ErrorResponse))]
    public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionRequest request)
    {
        var command = request.ToApplicationRequest();

        _logger.LogInformation(
            "----- Sending command: {CommandName} {@Command})",
            nameof(command),
            command);

        var response = await _mediator.Send(command);
        if (!response.IsSuccess)
        {
            return BadRequest(response.ErrorResponse);
        }

        return CreatedAtAction(nameof(CreateTransaction), new { id = Guid.NewGuid() }, response.Value);
    }


    /// <summary>
    /// Get transactions by wallet id
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET  /transactions/:walletId
    /// </remarks>
    /// <param name="walletId"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [Produces(typeof(List<TransactionResponse>))]
    [ProducesErrorResponseType(typeof(ErrorResponse))]
    public async Task<IActionResult> GetTransactions([FromQuery] int walletId)
    {
        var request = new GetTransactionsRequest();
        var query = request.ToApplicationRequest(walletId);

        _logger.LogInformation(
            "----- Sending query: {QueryName} {@Query})",
            nameof(query),
            query);

        var response = await _mediator.Send(query);
        if (!response.IsSuccess)
        {
            return BadRequest(response.ErrorResponse);
        }

        return Ok(response.Value);
    }
}