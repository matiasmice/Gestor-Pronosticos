use master
go
Create Database GestorPronosticos
go
use GestorPronosticos
go
Create table Usuario(
	Usuario varchar(30) primary key,
	Nombre varchar(30) not null,
	Apellido varchar(30) not null,
	Contrasenia varchar(8) not null
)
go

Create table Pais(
	CodPais varchar(3) not null Primary Key,
	Nombre varchar(30) not null 
)
go

Create table Ciudad(
	CodCiudad varchar(3) not null,
	Nombre varchar(30) not null,
	CodPais varchar(3) FOREIGN Key references Pais(CodPais), 
	Primary Key(CodCiudad,CodPais)
)
go

Create table Pronostico(
	CodAuto int identity (1,1) Primary key,
	Usuario varchar(30) Foreign Key references Usuario(Usuario),
	CodCiudad varchar(3),
	CodPais varchar(3),
	Fecha DateTime not null,
	VelViento int not null,
	ProbLluvia smallint not null,
	ProbTormenta smallint not null,
	TempMax int not null,
	TempMin int not null,
	TipodeCielo varchar(30) not null,
	Foreign Key (CodCiudad,CodPais) references Ciudad(CodCiudad,CodPais)
)
go