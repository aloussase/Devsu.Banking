using Devsu.Banking.Accounts.Dto;
using Devsu.Banking.Accounts.Mappers;
using ErrorOr;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Devsu.Banking.Accounts.Endpoints;

[AllowAnonymous]
[HttpPost("/movimientos")]
public class CreateMovimientoEndpoint :
    Endpoint<NewMovimientoDto, Results<Created<MovimientoDto>, BadRequest<string>, NotFound>>
{
    public IMediator Mediator { get; set; } = null!;
    public MovimientosMapper Mapper { get; set; } = null!;

    public override async Task<Results<Created<MovimientoDto>, BadRequest<string>, NotFound>> ExecuteAsync(
        NewMovimientoDto req,
        CancellationToken ct)
    {
        var command = Mapper.NewMovimientoDtoToCreateMovimientoCommand(req);
        var result = await Mediator.Send(command, ct);

        if (result is { IsError: true, FirstError.Type: ErrorType.NotFound })
            return TypedResults.NotFound();

        if (result is { IsError: true, FirstError.Type: ErrorType.Validation })
            return TypedResults.BadRequest(result.FirstError.Description);

        var response = Mapper.MovimientoToMovimientoDto(result.Value);
        return TypedResults.Created($"/movimientos/{response.Id}", response);
    }
}