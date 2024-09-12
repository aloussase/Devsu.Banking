using Devsu.Banking.Accounts.Mappers;
using Devsu.Banking.Accounts.Models;
using Devsu.Banking.Accounts.Repository;
using ErrorOr;
using MediatR;

namespace Devsu.Banking.Accounts.Commands;

public class CreateMovimientoCommand : IRequest<ErrorOr<Movimiento>>
{
    public CreateMovimientoCommand(string numeroCuenta, string tipo, decimal valor)
    {
        NumeroCuenta = numeroCuenta;
        Tipo = tipo;
        Valor = valor;
    }

    public decimal Valor { get; set; }
    public string Tipo { get; set; }
    public string NumeroCuenta { get; set; }

    public class Handler : IRequestHandler<CreateMovimientoCommand, ErrorOr<Movimiento>>
    {
        private readonly ICuentasRepository _cuentas;
        private readonly MovimientosMapper _mapper;
        private readonly IMovimientosRepository _movimientos;

        public Handler(ICuentasRepository cuentas, IMovimientosRepository movimientos, MovimientosMapper mapper)
        {
            _cuentas = cuentas;
            _movimientos = movimientos;
            _mapper = mapper;
        }

        public async Task<ErrorOr<Movimiento>> Handle(
            CreateMovimientoCommand command,
            CancellationToken cancellationToken)
        {
            var cuenta = await _cuentas.GetByNumeroCuenta(command.NumeroCuenta, cancellationToken);
            if (cuenta is null)
                return Error.NotFound(description: "Cuenta no encontrada");

            if (command.Tipo is not (Movimiento.TIPO_RETIRO or Movimiento.TIPO_DEPOSITO))
                return Error.Validation(description: "Tipo de movimiento no válido");

            if (command.Tipo == Movimiento.TIPO_RETIRO && cuenta.Saldo - decimal.Abs(command.Valor) < 0)
                return Error.Validation(description: "Saldo no disponible");

            var movimientoEntity = _mapper.CreateMovimientoCommandToMovimientoEntity(command);
            movimientoEntity.Saldo = cuenta.Saldo;

            var movimiento = await _movimientos.Create(movimientoEntity, cancellationToken);
            return movimiento;
        }
    }
}