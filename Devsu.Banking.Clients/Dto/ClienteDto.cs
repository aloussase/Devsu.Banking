using System.Text.Json.Serialization;

namespace Devsu.Banking.Clients.Dto;

public class ClienteDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("nombre")]
    public string? Nombre { get; set; }

    [JsonPropertyName("direccion")]
    public string? Direccion { get; set; }

    [JsonPropertyName("telefono")]
    public string? Telefono { get; set; }

    [JsonPropertyName("contrasena")]
    public string? Contrasena { get; set; }

    [JsonPropertyName("estado")]
    public bool Estado { get; set; }

    [JsonPropertyName("genero")]
    public string? Genero { get; set; }

    [JsonPropertyName("edad")]
    public int Edad { get; set; }

    [JsonPropertyName("identificacion")]
    public string? Identificacion { get; set; }
}