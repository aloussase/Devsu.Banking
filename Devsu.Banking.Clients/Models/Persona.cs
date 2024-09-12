namespace Devsu.Banking.Clients.Models;

public class Persona
{
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public string? Genero { get; set; }
    public int Edad { get; set; }
    public string? Identificacion { get; set; }
    public required string Direccion { get; set; }
    public required string Telefono { get; set; }
}