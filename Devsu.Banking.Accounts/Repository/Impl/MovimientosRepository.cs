using Devsu.Banking.Accounts.Database;
using Devsu.Banking.Accounts.Entities;
using Devsu.Banking.Accounts.Mappers;
using Devsu.Banking.Accounts.Models;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace Devsu.Banking.Accounts.Repository.Impl;

public class MovimientosRepository : IMovimientosRepository
{
    private readonly AccountsDbContext _db;
    private readonly MovimientosMapper _mapper;

    public MovimientosRepository(AccountsDbContext db, MovimientosMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<ErrorOr<Movimiento>> Create(
        MovimientoEntity entity,
        CancellationToken cancellationToken = default)
    {
        var cuenta = await _db.Cuentas.FirstOrDefaultAsync(x => x.Numero == entity.NumeroCuenta, cancellationToken);
        ArgumentNullException.ThrowIfNull(cuenta);
        cuenta.Saldo += entity.Valor;
        var result = await _db.Movimientos.AddAsync(entity, cancellationToken);
        await _db.SaveChangesAsync(cancellationToken);
        return _mapper.MovimientoEntityToMovimiento(result.Entity);
    }

    public Task<IEnumerable<Movimiento>> GetAll(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}