using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wallet.API.Dtos.Requests;
using Wallet.Application.Wallet.Dto;
using Wallet.Domain.Models;

namespace Wallet.API.Controllers;

[Route("wallets")]
[ApiController]
public class WalletController : ControllerBase
{
    #region Constructor & properties

    private readonly ILogger<WalletController> _logger;
    private readonly IMediator _mediator;

    public WalletController(ILogger<WalletController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    #endregion

    #region Public methods

    /// <summary>
    ///     Create wallet
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     POST /wallets
    ///     {
    ///         "documentId": "094938383",
    ///         "name": "Name",
    ///         "initialBalance": 3
    ///     }
    /// </remarks>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [Produces(typeof(bool))]
    [ProducesErrorResponseType(typeof(ErrorResponse))]
    public async Task<IActionResult> CreateWallet([FromBody] CreateWalletRequest request)
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

        return CreatedAtAction(nameof(CreateWallet), new { id = Guid.NewGuid() }, response.Value);
    }

    /// <summary>
    ///     Update wallet
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     PUT  /wallets/:Id
    ///     {
    ///         "id": 1,
    ///         "documentId": "094938383",
    ///         "name": "Name",
    ///         "initialBalance": 8
    ///     }
    /// </remarks>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesErrorResponseType(typeof(ErrorResponse))]
    [Route("{id:int}")]
    public async Task<IActionResult> UpdateWallet(int id, [FromBody] UpdateWalletRequest request)
    {
        var command = request.ToApplicationRequest(id);

        _logger.LogInformation(
            "----- Sending command: {CommandName} {@Command})",
            nameof(command),
            command);

        var response = await _mediator.Send(command);
        if (!response.IsSuccess)
        {
            return BadRequest(response.ErrorResponse);
        }

        return Ok();
    }

    /// <summary>
    ///     Delete a wallet
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     DELETE  /wallets/:Id
    /// </remarks>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesErrorResponseType(typeof(ErrorResponse))]
    [Route("{id:int}")]
    public async Task<IActionResult> DeleteWallet(int id)
    {
        var request = new DeleteWalletRequest();
        var command = request.ToApplicationRequest(id);

        _logger.LogInformation(
            "----- Sending command: {CommandName} {@Command})",
            nameof(command),
            command);

        var response = await _mediator.Send(command);
        if (!response.IsSuccess)
        {
            return BadRequest(response.ErrorResponse);
        }

        return Ok();
    }


    /// <summary>
    /// Get a wallet by Id
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET  /wallets/:id
    /// </remarks>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [Produces(typeof(bool))]
    [ProducesErrorResponseType(typeof(ErrorResponse))]
    [Route("{id:int}")]
    public async Task<IActionResult> GetWallet(int id)
    {
        var request = new GetWalletRequest();
        var query = request.ToApplicationRequest(id);

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


    /// <summary>
    /// Get wallet by document id
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// 
    ///     GET  /wallets/:documentId
    /// </remarks>
    /// <param name="documentId"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [Produces(typeof(List<WalletResponse>))]
    [ProducesErrorResponseType(typeof(ErrorResponse))]
    public async Task<IActionResult> GetWallets([FromQuery] string documentId)
    {
        var request = new GetWalletsRequest();
        var query = request.ToApplicationRequest(documentId);

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

    #endregion
}