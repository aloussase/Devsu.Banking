using Devsu.Banking.Accounts.Commands;
using Devsu.Banking.Accounts.Dto;
using Devsu.Banking.Accounts.Entities;
using Devsu.Banking.Accounts.Models;
using Riok.Mapperly.Abstractions;

namespace Devsu.Banking.Accounts.Mappers;

[Mapper]
public partial class MovimientosMapper
{
    public partial MovimientoEntity MovimientoToMovimientoEntity(Movimiento movimiento);
    public partial Movimiento MovimientoEntityToMovimiento(MovimientoEntity movimientoEntity);
    public partial MovimientoEntity CreateMovimientoCommandToMovimientoEntity(CreateMovimientoCommand command);
    public partial CreateMovimientoCommand NewMovimientoDtoToCreateMovimientoCommand(NewMovimientoDto dto);
    public partial MovimientoDto MovimientoToMovimientoDto(Movimiento movimiento);
}