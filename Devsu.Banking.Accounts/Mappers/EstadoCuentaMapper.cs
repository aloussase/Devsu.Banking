using Devsu.Banking.Accounts.Dto;
using Devsu.Banking.Accounts.Models;
using Riok.Mapperly.Abstractions;

namespace Devsu.Banking.Accounts.Mappers;

[Mapper]
public partial class EstadoCuentaMapper
{
    public partial EstadoCuentaDto EstadoCuentaToEstadoCuentaDto(EstadoCuenta estadoCuenta);
}