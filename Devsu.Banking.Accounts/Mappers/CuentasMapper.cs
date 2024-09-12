using Devsu.Banking.Accounts.Commands;
using Devsu.Banking.Accounts.Dto;
using Devsu.Banking.Accounts.Entities;
using Devsu.Banking.Accounts.Models;
using Riok.Mapperly.Abstractions;

namespace Devsu.Banking.Accounts.Mappers;

[Mapper]
public partial class CuentasMapper
{
    public partial CuentaEntity CuentaToCuentaEntity(Cuenta cuenta);
    public partial Cuenta CuentaEntityToCuenta(CuentaEntity cuentaEntity);
    public partial CuentaEntity CreateCuentaCommandToCuentaEntity(CreateCuentaCommand command);
    public partial CreateCuentaCommand NewCuentaDtoToCreateCuentaCommand(NewCuentaDto dto);
    public partial CuentaDto CuentaToCuentaDto(Cuenta cuenta);
}