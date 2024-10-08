﻿using Devsu.Banking.Clients.Mappers;
using Devsu.Banking.Clients.Models;
using Devsu.Banking.Clients.Repository;
using ErrorOr;
using MediatR;

namespace Devsu.Banking.Clients.Commands;

public class CreateClienteCommand : IRequest<ErrorOr<Cliente>>
{
    public CreateClienteCommand(string nombre, string direccion, string telefono, string contrasena, bool estado)
    {
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        Contrasena = contrasena;
        Estado = estado;
    }

    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public string Contrasena { get; set; }
    public bool Estado { get; set; }

    public class Handler : IRequestHandler<CreateClienteCommand, ErrorOr<Cliente>>
    {
        private readonly IClientesRepository _clientes;
        private readonly ClienteMapper _mapper;

        public Handler(IClientesRepository clientes, ClienteMapper mapper)
        {
            _clientes = clientes;
            _mapper = mapper;
        }

        public async Task<ErrorOr<Cliente>> Handle(
            CreateClienteCommand command,
            CancellationToken cancellationToken)
        {
            var entity = _mapper.CreateClienteCommandToClienteEntity(command);
            var cliente = await _clientes.Create(entity, cancellationToken);
            return cliente;
        }
    }
}