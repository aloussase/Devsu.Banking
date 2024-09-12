using Devsu.Banking.Accounts.Entities;
using Devsu.Banking.Accounts.Models;
using ErrorOr;

namespace Devsu.Banking.Accounts.Repository;

public interface ICuentasRepository
{
    Task<ErrorOr<Cuenta>> Create(CuentaEntity entity, CancellationToken cancellationToken = default);
    Task<IEnumerable<Cuenta>> GetAll(CancellationToken cancellationToken = default);
    Task<Cuenta?> GetByNumeroCuenta(string numeroCuenta, CancellationToken cancellationToken = default);
}