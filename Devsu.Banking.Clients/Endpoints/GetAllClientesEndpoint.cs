using Devsu.Banking.Clients.Dto;
using Devsu.Banking.Clients.Mappers;
using Devsu.Banking.Clients.Queries;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Devsu.Banking.Clients.Endpoints;

[AllowAnonymous]
[HttpGet("/clientes")]
public class GetAllClientesEndpoint : EndpointWithoutRequest<Ok<IEnumerable<ClienteDto>>>
{
    public IMediator Mediator { get; set; } = null!;
    public ClienteMapper Mapper { get; set; } = null!;

    public override async Task<Ok<IEnumerable<ClienteDto>>> ExecuteAsync(CancellationToken ct)
    {
        var query = new GetAllClientesQuery();
        var result = await Mediator.Send(query, ct);
        var response = result.Select(x => Mapper.ClienteToClienteDto(x));
        return TypedResults.Ok(response);
    }
}