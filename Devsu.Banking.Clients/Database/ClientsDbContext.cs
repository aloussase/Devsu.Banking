using Devsu.Banking.Clients.Entities;
using Microsoft.EntityFrameworkCore;

namespace Devsu.Banking.Clients.Database;

public class ClientsDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public ClientsDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<ClienteEntity> Clients { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
    }
}