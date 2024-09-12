using Devsu.Banking.Accounts.Entities;
using Devsu.Banking.Accounts.Models;
using ErrorOr;

namespace Devsu.Banking.Accounts.Repository;

public interface IMovimientosRepository
{
    Task<ErrorOr<Movimiento>> Create(MovimientoEntity entity, CancellationToken cancellationToken = default);

    Task<IEnumerable<Movimiento>> GetByCuentaAndFecha(
        string numeroCuenta,
        DateTime fecha,
        CancellationToken cancellationToken = default);
}