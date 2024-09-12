using System.Text.Json.Serialization;

namespace Devsu.Banking.Accounts.Dto;

public class NewMovimientoDto
{
    [JsonPropertyName("valor")]
    public required decimal Valor { get; set; }

    [JsonPropertyName("tipo")]
    public required string Tipo { get; set; }

    [JsonPropertyName("numero_cuenta")]
    public required string NumeroCuenta { get; set; }
}