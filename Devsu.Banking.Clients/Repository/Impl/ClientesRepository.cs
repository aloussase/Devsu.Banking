using Devsu.Banking.Clients.Database;
using Devsu.Banking.Clients.Entities;
using Devsu.Banking.Clients.Mappers;
using Devsu.Banking.Clients.Models;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace Devsu.Banking.Clients.Repository.Impl;

public class ClientesRepository: IClientesRepository
{
    private readonly ClientsDbContext _db;
    private readonly ClienteMapper _mapper;

    public ClientesRepository(ClientsDbContext db, ClienteMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<ErrorOr<Cliente>> Create(ClienteEntity entity, CancellationToken cancellationToken)
    {
        var result = await _db.Clients.AddAsync(entity);
        await _db.SaveChangesAsync(cancellationToken);
        return _mapper.ClienteEntityToCliente(result.Entity);
    }

    public async Task<ErrorOr<Cliente>> Update(string nombre, ClienteEntity entity, CancellationToken cancellationToken)
    {
        var existing = await _db.Clients.FirstOrDefaultAsync(x => x.Nombre == nombre);
        if (existing is null)
            return Error.NotFound(description: "No existe cliente con ese id");

        entity.Id = existing.Id;
        var result = _db.Update(entity);
        await _db.SaveChangesAsync(cancellationToken);
        return _mapper.ClienteEntityToCliente(result.Entity);
    }

    public async Task<ErrorOr<bool>> Delete(string nombre, CancellationToken cancellationToken)
    {
        var entity = await _db.Clients.FirstOrDefaultAsync(x => x.Nombre == nombre);
        if (entity is null)
            return Error.NotFound(description: "No existe cliente con ese id");

        _db.Clients.Remove(entity);
        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<IEnumerable<Cliente>> GetAll(CancellationToken cancellationToken)
    {
        return await _db.Clients
            .Select(x => _mapper.ClienteEntityToCliente(x))
            .ToListAsync(cancellationToken);
    }
}