using Devsu.Banking.Accounts.Database;
using Devsu.Banking.Accounts.Mappers;
using Devsu.Banking.Accounts.Repository;
using Devsu.Banking.Accounts.Repository.Impl;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

builder.Services.AddDbContext<AccountsDbContext>();

builder.Services.AddScoped<ICuentasRepository, CuentasRepository>();
builder.Services.AddScoped<IMovimientosRepository, MovimientosRepository>();

builder.Services.AddSingleton<CuentasMapper>();
builder.Services.AddSingleton<MovimientosMapper>();
builder.Services.AddSingleton<EstadoCuentaMapper>();

var app = builder.Build();

app.UseFastEndpoints();

app.Run();