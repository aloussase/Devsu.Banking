using Devsu.Banking.Accounts.Dto;
using Devsu.Banking.Accounts.Mappers;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace Devsu.Banking.Accounts.Endpoints;

[AllowAnonymous]
[HttpPost("/cuentas")]
public class CreateCuentaEndpoint : Endpoint<NewCuentaDto, CuentaDto>
{
    public IMediator Mediator { get; set; } = null!;
    public CuentasMapper Mapper { get; set; } = null!;

    public override async Task<CuentaDto> ExecuteAsync(NewCuentaDto req, CancellationToken ct)
    {
        var command = Mapper.NewCuentaDtoToCreateCuentaCommand(req);
        var result = await Mediator.Send(command, ct);
        var response = Mapper.CuentaToCuentaDto(result.Value);
        return response;
    }
}