using System.Text.Json.Serialization;

namespace Devsu.Banking.Accounts.Dto;

public class EstadoCuentaDto
{
    [JsonPropertyName("id")]
    public DateTime Fecha { get; set; }

    [JsonPropertyName("cliente")]
    public string Cliente { get; set; } = null!;

    [JsonPropertyName("numero_cuenta")]
    public string NumeroCuenta { get; set; } = null!;

    [JsonPropertyName("tipo")]
    public string Tipo { get; set; } = null!;

    [JsonPropertyName("saldo_inicial")]
    public decimal SaldoInicial { get; set; }

    [JsonPropertyName("estado")]
    public bool Estado { get; set; }

    [JsonPropertyName("movimiento")]
    public decimal Movimiento { get; set; }

    [JsonPropertyName("saldo_disponible")]
    public decimal SaldoDisponible { get; set; }
}