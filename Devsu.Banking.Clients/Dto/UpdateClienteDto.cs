namespace Devsu.Banking.Clients.Dto;

public class UpdateClienteDto : ClienteDto
{
    // This comes from the route parameter when using FastEndpoints
    public string ClienteNombre { get; set; } = null!;
}