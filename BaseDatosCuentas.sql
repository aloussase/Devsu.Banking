create table cuentas
(
    "Id"            serial primary key,
    "Numero"        varchar(100),
    "Tipo"          varchar(10),
    "Saldo"         decimal(10, 2),
    "Estado"        boolean,
    "NombreCliente" varchar(100)
);

create table movimientos
(
    "Id"           serial primary key,
    "Fecha"        timestamp,
    "Valor"        decimal(10, 2),
    "Saldo"        decimal(10, 2),
    "Tipo"         varchar(10),
    "NumeroCuenta" integer
);