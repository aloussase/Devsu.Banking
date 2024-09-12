namespace Devsu.Banking.Clients.Dto;

public class NewClienteDto
{
    public required string Nombre { get; set; }
    public required string Direccion { get; set; }
    public required string Telefono { get; set; }
    public required string Contrasena { get; set; }
    public required bool Estado { get; set; }
}