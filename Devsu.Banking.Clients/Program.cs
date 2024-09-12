using Devsu.Banking.Clients.Database;
using Devsu.Banking.Clients.Mappers;
using Devsu.Banking.Clients.Repository;
using Devsu.Banking.Clients.Repository.Impl;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddDbContext<ClientsDbContext>();
builder.Services.AddScoped<IClientesRepository, ClientesRepository>();
builder.Services.AddSingleton<ClienteMapper>();

var app = builder.Build();

app.UseFastEndpoints();

app.Run();