using Devsu.Banking.Clients.Commands;
using Devsu.Banking.Clients.Dto;
using ErrorOr;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Devsu.Banking.Clients.Endpoints;

[AllowAnonymous]
[HttpDelete("/clientes/{ClienteNombre}")]
public class DeleteClienteEndpoint : Endpoint<DeleteClienteDto, Results<NoContent, NotFound>>
{
    public IMediator Mediator { get; set; } = null!;

    public override async Task<Results<NoContent, NotFound>> ExecuteAsync(DeleteClienteDto req, CancellationToken ct)
    {
        var command = new DeleteClienteCommand(req.ClienteNombre);
        var result = await Mediator.Send(command);
        if (result is { IsError: true, FirstError.Type: ErrorType.NotFound })
            return TypedResults.NotFound();
        return TypedResults.NoContent();
    }
}