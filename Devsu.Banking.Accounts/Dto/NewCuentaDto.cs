using System.Text.Json.Serialization;

namespace Devsu.Banking.Accounts.Dto;

public class NewCuentaDto
{
    [JsonPropertyName("tipo")]
    public string Tipo { get; set; } = null!;

    [JsonPropertyName("saldo_inicial")]
    public decimal SaldoInicial { get; set; }

    [JsonPropertyName("estado")]
    public bool Estado { get; set; } = true;

    [JsonPropertyName("nombre_cliente")]
    public string NombreCliente { get; set; } = null!;
}