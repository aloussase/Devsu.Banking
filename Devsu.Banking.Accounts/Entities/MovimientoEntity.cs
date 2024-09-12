using System.ComponentModel.DataAnnotations.Schema;

namespace Devsu.Banking.Accounts.Entities;

[Table("movimientos")]
public class MovimientoEntity
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public decimal Valor { get; set; }
    public decimal Saldo { get; set; }
    public string Tipo { get; set; } = null!;
    public string NumeroCuenta { get; set; } = null!;

    public CuentaEntity Cuenta { get; set; } = null!;
}