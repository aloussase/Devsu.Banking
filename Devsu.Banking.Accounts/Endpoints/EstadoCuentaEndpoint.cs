using Devsu.Banking.Accounts.Dto;
using Devsu.Banking.Accounts.Mappers;
using Devsu.Banking.Accounts.Queries;
using ErrorOr;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Devsu.Banking.Accounts.Endpoints;

[AllowAnonymous]
[HttpGet("/reportes")]
public class EstadoCuentaEndpoint :
    Endpoint<GenerateEstadoCuentaDto, Results<NotFound, Ok<IEnumerable<EstadoCuentaDto>>, BadRequest>>
{
    public IMediator Mediator { get; set; } = null!;
    public EstadoCuentaMapper Mapper { get; set; } = null!;

    public override async Task<Results<NotFound, Ok<IEnumerable<EstadoCuentaDto>>, BadRequest>> ExecuteAsync(
        GenerateEstadoCuentaDto req,
        CancellationToken ct)
    {
        if (req.Cliente is null || req.Fecha is null)
            return TypedResults.BadRequest();

        var date = DateTime.ParseExact(req.Fecha, "dd/MM/yyyy", null).ToUniversalTime();
        var query = new EstadoCuentaQuery(req.Cliente, date);
        var result = await Mediator.Send(query, ct);
        if (result is { IsError: true, FirstError.Type: ErrorType.NotFound })
            return TypedResults.NotFound();

        var response = result.Value.Select(x => Mapper.EstadoCuentaToEstadoCuentaDto(x));
        return TypedResults.Ok(response);
    }
}