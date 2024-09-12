using Devsu.Banking.Clients.Dto;
using Devsu.Banking.Clients.Mappers;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Devsu.Banking.Clients.Endpoints;

[AllowAnonymous]
[HttpPost("/clientes")]
public class CreateClienteEndpoint : Endpoint<NewClienteDto, Results<Created<ClienteDto>, NotFound>>
{
    public IMediator Mediator { get; set; } = null!;
    public ClienteMapper Mapper { get; set; } = null!;

    public override async Task<Results<Created<ClienteDto>, NotFound>> ExecuteAsync(
        NewClienteDto req,
        CancellationToken ct)
    {
        var command = Mapper.NewClienteDtoToCreateClienteCommand(req);
        var result = await Mediator.Send(command, ct);
        var response = Mapper.ClienteToClienteDto(result.Value);
        return TypedResults.Created($"/clients/{response.Id}", response);
    }
}