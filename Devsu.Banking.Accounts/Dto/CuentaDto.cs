using System.Text.Json.Serialization;

namespace Devsu.Banking.Accounts.Dto;

public class CuentaDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("numero_cuenta")]
    public string Numero { get; set; } = null!;

    [JsonPropertyName("tipo")]
    public string Tipo { get; set; } = null!;

    [JsonPropertyName("saldo_inicial")]
    public decimal SaldoInicial { get; set; }

    [JsonPropertyName("saldo_actual")]
    public decimal Saldo { get; set; }

    [JsonPropertyName("estado")]
    public bool Estado { get; set; }

    [JsonPropertyName("nombre_cliente")]
    public string NombreCliente { get; set; } = null!;
}