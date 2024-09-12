using Devsu.Banking.Accounts.Database;
using Devsu.Banking.Accounts.Entities;
using Devsu.Banking.Accounts.Mappers;
using Devsu.Banking.Accounts.Models;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace Devsu.Banking.Accounts.Repository.Impl;

public class CuentasRepository : ICuentasRepository
{
    private readonly AccountsDbContext _db;
    private readonly CuentasMapper _mapper;

    public CuentasRepository(AccountsDbContext db, CuentasMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<ErrorOr<Cuenta>> Create(CuentaEntity entity, CancellationToken cancellationToken = default)
    {
        var result = await _db.Cuentas.AddAsync(entity, cancellationToken);
        await _db.SaveChangesAsync(cancellationToken);
        return _mapper.CuentaEntityToCuenta(result.Entity);
    }

    public async Task<Cuenta?> GetByNumeroCuenta(string numeroCuenta, CancellationToken cancellationToken = default)
    {
        var entity = await _db.Cuentas.FirstOrDefaultAsync(x => x.Numero == numeroCuenta, cancellationToken);
        return entity is null ? null : _mapper.CuentaEntityToCuenta(entity);
    }

    public async Task<Cuenta?> GetByNombreCliente(string nombreCliente, CancellationToken cancellationToken = default)
    {
        var entity = await _db.Cuentas.FirstOrDefaultAsync(x => x.NombreCliente == nombreCliente, cancellationToken);
        return entity is null ? null : _mapper.CuentaEntityToCuenta(entity);
    }
}