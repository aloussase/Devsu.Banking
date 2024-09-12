namespace Devsu.Banking.Accounts.Models;

public class Movimiento
{
    public const string TIPO_RETIRO = "Retiro";
    public const string TIPO_DEPOSITO = "Deposito";

    public int Id { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now.ToUniversalTime();
    public decimal Valor { get; set; }
    public decimal Saldo { get; set; }
    public string Tipo { get; set; } = null!;
    public string NumeroCuenta { get; set; } = null!;
}