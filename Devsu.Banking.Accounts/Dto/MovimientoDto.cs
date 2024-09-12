using System.Text.Json.Serialization;

namespace Devsu.Banking.Accounts.Dto;

public class MovimientoDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("fecha")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }

    [JsonPropertyName("saldo")]
    public decimal Saldo { get; set; }

    [JsonPropertyName("tipo")]
    public string Tipo { get; set; } = null!;

    [JsonPropertyName("numero_cuenta")]
    public string NumeroCuenta { get; set; } = null!;
}