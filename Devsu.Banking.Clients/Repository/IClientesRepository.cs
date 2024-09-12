using Devsu.Banking.Clients.Entities;
using Devsu.Banking.Clients.Models;
using ErrorOr;

namespace Devsu.Banking.Clients.Repository;

public interface IClientesRepository
{
    Task<ErrorOr<Cliente>> Create(ClienteEntity entity, CancellationToken cancellationToken = default);
    Task<ErrorOr<Cliente>> Update(string nombre, ClienteEntity entity, CancellationToken cancellationToken = default);
    Task<ErrorOr<bool>> Delete(string nombre, CancellationToken cancellationToken = default);
    Task<IEnumerable<Cliente>> GetAll(CancellationToken cancellationToken = default);
}