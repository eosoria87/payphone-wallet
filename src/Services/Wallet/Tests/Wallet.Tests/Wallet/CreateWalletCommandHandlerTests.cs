using Moq;
using Wallet.Application.Wallet.Commands;
using Wallet.Domain.Interfaces;

namespace Wallet.Tests.Wallet;

using System.Threading;
using System.Threading.Tasks;
using Xunit;

public class CreateWalletCommandHandlerTests
{
    private readonly Mock<IWalletRepository> _walletRepositoryMock;
    private readonly CreateWalletCommandHandler _handler;

    public CreateWalletCommandHandlerTests()
    {
        _walletRepositoryMock = new Mock<IWalletRepository>();
        _handler = new CreateWalletCommandHandler(_walletRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldCreateWalletSuccessfully()
    {
        // Arrange
        var command = new CreateWalletCommand("123456789", "Test Wallet", 100.00m);

        _walletRepositoryMock
            .Setup(repo => repo.UnitOfWork.SaveEntitiesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result.IsSuccess);
        _walletRepositoryMock.Verify(repo => repo.Add(It.IsAny<Domain.Entities.Wallet>()), Times.Once);
        _walletRepositoryMock.Verify(repo => repo.UnitOfWork.SaveEntitiesAsync(It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldReturnFailure_WhenExceptionIsThrown()
    {
        // Arrange
        var command = new CreateWalletCommand("123456789", "Test Wallet", 100.00m);

        _walletRepositoryMock
            .Setup(repo => repo.UnitOfWork.SaveEntitiesAsync(It.IsAny<CancellationToken>()))
            .ThrowsAsync(new System.Exception("Database error"));

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Equal("Database error", result.ErrorResponse.Message);
    }
}