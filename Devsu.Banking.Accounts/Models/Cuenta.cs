namespace Devsu.Banking.Accounts.Models;

public class Cuenta
{
    public int Id { get; set; }
    public string Numero { get; set; } = null!;
    public string Tipo { get; set; } = null!;
    public decimal SaldoInicial { get; set; }
    public decimal Saldo { get; set; }
    public bool Estado { get; set; }
    public string NombreCliente { get; set; } = null!;
}