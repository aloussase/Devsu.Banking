using Devsu.Banking.Clients.Commands;
using Devsu.Banking.Clients.Dto;
using Devsu.Banking.Clients.Mappers;
using ErrorOr;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Devsu.Banking.Clients.Endpoints;

[AllowAnonymous]
[HttpPut("/clientes/{ClienteNombre}")]
public class UpdateClienteEndpoint : Endpoint<UpdateClienteDto, Results<Ok<ClienteDto>, NotFound>>
{
    public IMediator Mediator { get; set; } = null!;
    public ClienteMapper Mapper { get; set; } = null!;

    public override async Task<Results<Ok<ClienteDto>, NotFound>> ExecuteAsync(
        UpdateClienteDto req,
        CancellationToken ct)
    {
        var entity = Mapper.UpdateClienteDtoToClienteEntity(req);
        var command = new UpdateClienteCommand(req.ClienteNombre, entity);
        var result = await Mediator.Send(command, ct);

        if (result is { IsError: true, FirstError.Type: ErrorType.NotFound })
            return TypedResults.NotFound();

        var response = Mapper.ClienteToClienteDto(result.Value);
        return TypedResults.Ok(response);
    }
}