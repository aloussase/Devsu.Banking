namespace Devsu.Banking.Clients.Models;

public class Cliente: Persona
{
   public string? ClienteId { get; set; }
   public required string Contrasena { get; set; }
   public required bool Estado { get; set; }
}