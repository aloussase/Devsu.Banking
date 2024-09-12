using Devsu.Banking.Clients.Commands;
using Devsu.Banking.Clients.Entities;
using Devsu.Banking.Clients.Mappers;
using Devsu.Banking.Clients.Models;
using Devsu.Banking.Clients.Repository;
using FluentAssertions;
using Moq;

namespace Devsu.Banking.UnitTests;

public class CreateClienteTests
{
    [Fact]
    public async void Test_CreatingAClient_WithValidInformation_ReturnsTheClient()
    {
        // NOTE: In real life I would've used a test data generator like Bogus.

        var command = new CreateClienteCommand("John Doe", "123 Main St", "555-555-5555", "password", true);

        var clientesMock = new Mock<IClientesRepository>();
        clientesMock
            .Setup(x => x.Create(It.IsAny<ClienteEntity>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Cliente
            {
                ClienteId = "123",
                Nombre = "John Doe",
                Direccion = "123 Main St",
                Telefono = "555-555-5555",
                Contrasena = "password",
                Estado = true
            })
            .Verifiable();

        var commandHandler = new CreateClienteCommand.Handler(clientesMock.Object, new ClienteMapper());
        var result = await commandHandler.Handle(command, default);

        result.IsError.Should().BeFalse();
        result.Value.Nombre.Should().Be("John Doe");
        result.Value.Estado.Should().Be(true);

        clientesMock.Verify();
    }
}