create table clientes
(
    "Id"             serial primary key,
    "Nombre"         varchar(100),
    "Genero"         varchar(10),
    "Edad"           integer     default 0,
    "Identificacion" varchar(50),
    "Telefono"       varchar(100),
    "Direccion"      varchar(100),
    "Estado"         boolean,
    "Contrasena"     varchar(100),
    "ClienteId"      varchar(36) default gen_random_uuid()
);