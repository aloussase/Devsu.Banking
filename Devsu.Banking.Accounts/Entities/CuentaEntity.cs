using System.ComponentModel.DataAnnotations.Schema;

namespace Devsu.Banking.Accounts.Entities;

[Table("cuentas")]
public class CuentaEntity
{
    public int Id { get; set; }
    public string Numero { get; set; } = null!;
    public string Tipo { get; set; } = null!;
    public decimal SaldoInicial { get; set; }
    public decimal Saldo { get; set; }
    public bool Estado { get; set; }
    public string NombreCliente { get; set; } = null!;

    public ICollection<MovimientoEntity> Movimientos { get; set; } = new List<MovimientoEntity>();
}