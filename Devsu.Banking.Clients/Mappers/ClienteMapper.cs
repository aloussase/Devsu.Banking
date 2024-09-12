using Devsu.Banking.Clients.Commands;
using Devsu.Banking.Clients.Dto;
using Devsu.Banking.Clients.Entities;
using Devsu.Banking.Clients.Models;
using Riok.Mapperly.Abstractions;

namespace Devsu.Banking.Clients.Mappers;

[Mapper]
public partial class ClienteMapper
{
    public partial Cliente NewClienteDtoToCliente(NewClienteDto dto);
    public partial CreateClienteCommand NewClienteDtoToCreateClienteCommand(NewClienteDto dto);
    public partial ClienteEntity CreateClienteCommandToClienteEntity(CreateClienteCommand command);
    public partial Cliente ClienteEntityToCliente(ClienteEntity entity);
    public partial ClienteDto ClienteToClienteDto(Cliente cliente);
    public partial ClienteEntity UpdateClienteDtoToClienteEntity(UpdateClienteDto dto);
}