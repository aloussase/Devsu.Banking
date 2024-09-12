using Devsu.Banking.Accounts.Models;
using Devsu.Banking.Accounts.Repository;
using ErrorOr;
using MediatR;

namespace Devsu.Banking.Accounts.Queries;

public class EstadoCuentaQuery : IRequest<ErrorOr<IEnumerable<EstadoCuenta>>>
{
    public EstadoCuentaQuery(string cliente, DateTime fecha)
    {
        Cliente = cliente;
        Fecha = fecha;
    }

    public DateTime Fecha { get; set; }
    public string Cliente { get; set; }

    public class Handler : IRequestHandler<EstadoCuentaQuery, ErrorOr<IEnumerable<EstadoCuenta>>>
    {
        private readonly ICuentasRepository _cuentas;
        private readonly IMovimientosRepository _movimientos;

        public Handler(ICuentasRepository cuentas, IMovimientosRepository movimientos)
        {
            _cuentas = cuentas;
            _movimientos = movimientos;
        }

        public async Task<ErrorOr<IEnumerable<EstadoCuenta>>> Handle(
            EstadoCuentaQuery command,
            CancellationToken cancellationToken)
        {
            var cuenta = await _cuentas.GetByNombreCliente(command.Cliente, cancellationToken);
            if (cuenta is null)
                return Error.NotFound(description: "Cuenta no encontrada");

            var movimientos = await _movimientos.GetByCuentaAndFecha(cuenta.Numero, command.Fecha, cancellationToken);
            var estadoCuenta = movimientos.Select(x => new EstadoCuenta
            {
                Fecha = x.Fecha,
                Cliente = cuenta.NombreCliente,
                NumeroCuenta = cuenta.Numero,
                Tipo = x.Tipo,
                SaldoInicial = cuenta.SaldoInicial,
                Estado = cuenta.Estado,
                Movimiento = x.Valor,
                SaldoDisponible = x.Saldo
            });

            return estadoCuenta.ToErrorOr();
        }
    }
}