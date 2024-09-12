using Devsu.Banking.Accounts.Mappers;
using Devsu.Banking.Accounts.Models;
using Devsu.Banking.Accounts.Repository;
using ErrorOr;
using MediatR;

namespace Devsu.Banking.Accounts.Commands;

public class CreateCuentaCommand : IRequest<ErrorOr<Cuenta>>
{
    public string Tipo { get; set; } = null!;
    public decimal SaldoInicial { get; set; }
    public bool Estado { get; set; } = true;
    public string NombreCliente { get; set; } = null!;

    public class Handler : IRequestHandler<CreateCuentaCommand, ErrorOr<Cuenta>>
    {
        private readonly ICuentasRepository _cuentas;
        private readonly CuentasMapper _mapper;

        public Handler(ICuentasRepository cuentas, CuentasMapper mapper)
        {
            _cuentas = cuentas;
            _mapper = mapper;
        }

        public async Task<ErrorOr<Cuenta>> Handle(
            CreateCuentaCommand command,
            CancellationToken cancellationToken)
        {
            var entity = _mapper.CreateCuentaCommandToCuentaEntity(command);
            var numeroCuenta = Guid.NewGuid().ToString();
            entity.Numero = numeroCuenta;
            entity.Saldo = command.SaldoInicial;
            var result = await _cuentas.Create(entity, cancellationToken);
            return result;
        }
    }
}