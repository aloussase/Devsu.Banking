using System.Text.Json.Serialization;

namespace Devsu.Banking.Clients.Dto;

public class ClienteDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("nombre")]
    public required string Nombre { get; set; }

    [JsonPropertyName("direccion")]
    public required string Direccion { get; set; }

    [JsonPropertyName("telefono")]
    public required string Telefono { get; set; }

    [JsonPropertyName("contrasena")]
    public required string Contrasena { get; set; }

    [JsonPropertyName("estado")]
    public required bool Estado { get; set; }

    [JsonPropertyName("genero")]
    public string? Genero { get; set; }

    [JsonPropertyName("edad")]
    public int Edad { get; set; }

    [JsonPropertyName("identificacion")]
    public string? Identificacion { get; set; }
}