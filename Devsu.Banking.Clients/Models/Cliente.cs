namespace Devsu.Banking.Clients.Models;

public class Cliente : Persona
{
    public string? ClienteId { get; set; }
    public string Contrasena { get; set; } = "secret";
    public bool Estado { get; set; } = true;
}