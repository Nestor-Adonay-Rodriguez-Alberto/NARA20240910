
-- Creacion DB:
Create DataBase dbNARA20240910;
Go

-- Usar DB:
Use dbNARA20240910;
Go

-- Crear Tabla:
Create Table ProductsNARA
(
Id Int Identity(1,1) Primary Key,
NombreNARA VARCHAR(50) not null,
DescripcionNARA VARCHAR(50) null,
Precio decimal(10,2) not null
);
Go