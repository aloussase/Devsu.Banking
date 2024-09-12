using Devsu.Banking.Clients.Models;
using Devsu.Banking.Clients.Repository;
using MediatR;

namespace Devsu.Banking.Clients.Queries;

public class GetAllClientesQuery: IRequest<IEnumerable<Cliente>>
{
    public class Handler : IRequestHandler<GetAllClientesQuery, IEnumerable<Cliente>>
    {
        private readonly IClientesRepository _clientes;

        public Handler(IClientesRepository repository)
        {
            _clientes = repository;
        }

        public async Task<IEnumerable<Cliente>> Handle(
            GetAllClientesQuery query,
            CancellationToken cancellationToken)
        {
            return await _clientes.GetAll(cancellationToken);
        }
    }
}