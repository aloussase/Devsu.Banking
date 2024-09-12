using Devsu.Banking.Clients.Repository;
using ErrorOr;
using MediatR;

namespace Devsu.Banking.Clients.Commands;

public class DeleteClienteCommand : IRequest<ErrorOr<bool>>
{
    public DeleteClienteCommand(string clienteNombre)
    {
        ClienteNombre = clienteNombre;
    }

    public string ClienteNombre { get; set; } = null!;

    public class Handler : IRequestHandler<DeleteClienteCommand, ErrorOr<bool>>
    {
        private readonly IClientesRepository _clientes;

        public Handler(IClientesRepository clientes)
        {
            _clientes = clientes;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            return await _clientes.Delete(request.ClienteNombre, cancellationToken);
        }
    }
}