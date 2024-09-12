using Devsu.Banking.Accounts.Entities;
using Microsoft.EntityFrameworkCore;

namespace Devsu.Banking.Accounts.Database;

public class AccountsDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public AccountsDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<CuentaEntity> Cuentas { get; set; }
    public DbSet<MovimientoEntity> Movimientos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CuentaEntity>()
            .HasMany(x => x.Movimientos)
            .WithOne(x => x.Cuenta)
            .HasForeignKey(x => x.NumeroCuenta)
            .HasPrincipalKey(x => x.Numero);
    }
}