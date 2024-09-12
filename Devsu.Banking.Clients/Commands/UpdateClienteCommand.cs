using Devsu.Banking.Clients.Entities;
using Devsu.Banking.Clients.Models;
using Devsu.Banking.Clients.Repository;
using ErrorOr;
using MediatR;

namespace Devsu.Banking.Clients.Commands;

public class UpdateClienteCommand : IRequest<ErrorOr<Cliente>>
{
    public UpdateClienteCommand(string nombre, ClienteEntity entity)
    {
        Nombre = nombre;
        Entity = entity;
    }

    public string Nombre { get; set; }
    public ClienteEntity Entity { get; set; } = null!;

    public class Handler : IRequestHandler<UpdateClienteCommand, ErrorOr<Cliente>>
    {
        private readonly IClientesRepository _clientes;

        public Handler(IClientesRepository clientes)
        {
            _clientes = clientes;
        }

        public async Task<ErrorOr<Cliente>> Handle(
            UpdateClienteCommand command,
            CancellationToken cancellationToken)
        {
            return await _clientes.Update(command.Nombre, command.Entity, cancellationToken);
        }
    }
}