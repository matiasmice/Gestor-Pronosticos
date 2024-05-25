----------------------------------------LDD------------------------------------------------------------------------
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

---------------------------------------------------STORE PROCEDURE-------------------------------------------------
use GestorPronosticos 
GO

-------------------------------------PAIS--------------------------------------------

--Agrega un nuevo Pais, retorna -1 si es vacio cod o nombre
--retorna 1 en si hay �xito.
Create Procedure sp_AltaPais @Cod varchar (3), @Nom varchar(30)
AS	
	if @Cod='' or @Nom =''
		return -1
	if exists (select * from Pais where CodPais= @cod)
		return -2
	Begin try
		insert into Pais (CodPais,Nombre) values (@Cod,@Nom)
		return 1
	end try
	Begin catch
		declare @er int
		set @er = @@ERROR
		return @er
	End catch
Go

Create Procedure sp_EditPais @Cod varchar(3), @Nom varchar(30)
As
	Begin try
		if @Cod='' or @Nom ='' return -1
		if not exists (select * from Pais where codPais=@Cod ) return -2

		Update Pais set Nombre =@Nom
		where CodPais = @Cod
		return 1
	end try
	begin catch
		declare @er int
		set @er = @@ERROR
		return @er
	end catch
GO

--Elimina el pa�s si este no tiene pron�sticos asociados
--Si tiene asociados retorna -1. Retorna 1 si hay �xito.
Create Procedure sp_BajaPais @Cod varchar(3)
As
	if @cod ='' return -1

	if not exists (select * from Pais where codPais=@Cod )
		return -2
	if exists (select * from Pronostico where CodPais = @Cod)				
		return -3
		
	Begin Tran
	Begin try
		
		Delete from Ciudad where CodPais =@Cod

		Delete from Pais where CodPais= @Cod

		Commit tran
		return 1
	End try
	Begin catch
		rollback tran
		declare @er int
		set @er = @@ERROR
		return @er
	End catch
Go

--Devuelve todos los paises
Create Procedure sp_TodosLosPaises
As
	select * from Pais
Go

--Devuelve los datos del pa�s buscado
Create Procedure sp_BuscarPais @CodPais varchar (3)
AS
	select * from Pais where CodPais= @CodPais
Go

----------------------------------USUARIO------------------------------------------------

--Agrega un nuevo Usuario, retorna -1 si algun par�metro es vac�o
--retorna 1 en si hay �xito.
Create Procedure sp_AltaUsuario @Usr varchar(30), @Nom varchar(30), @Ape varchar(30), @Ctr varchar(8)
AS
	if @Usr ='' or @Nom ='' or @Ape ='' or @Ctr =''
		return -1
	if exists (select * from Usuario where Usuario=@Usr)
		return -2

	Begin try
		insert into Usuario (Usuario ,Nombre,Apellido,Contrasenia)
		Values (@Usr ,@Nom,@Ape,@Ctr)
		return 1
	End try
	Begin Catch
		declare @er int
		set @er = @@ERROR
		return @er
	End catch
Go

Create Procedure sp_EditUsuario @Usr varchar(30), @Nom varchar(30), @Ape varchar(30), @Ctr varchar(8)
AS
	if @Usr ='' or @Nom ='' or @Ape ='' or @Ctr =''
		return-1
	if not exists(select * from Usuario where Usuario= @Usr)
		return -2
	Begin try
		Update Usuario set Nombre= @Nom, Apellido= @Ape, Contrasenia= @Ctr
		where Usuario= @Usr
		return 1
	end try
	begin catch
		declare @er int
		set @er = @@ERROR
		return @er
	end catch
GO

--Elimina el usuario si �ste no tiene pron�sticos asociados
--Si tiene asosciados retorna -3. Retorna 1 si hay �xito.
Create Procedure sp_BajaUsuario @Usr varchar(30)
AS
	if @Usr ='' return -1

	if not exists (select * from Usuario where Usuario=@Usr)
		return -2
	if exists (select * from Pronostico where Usuario = @Usr)
		return -3
	Begin try
		delete from Usuario where Usuario= @Usr
		return 1
	end try
	begin catch
		declare @er int
		set @er = @@ERROR
		return @er
	end catch
GO

Create Procedure sp_LogueoUsuario @Usr varchar(30), @Ctr varchar(8)
As
	
	select * from usuario where Usuario=@Usr and Contrasenia =@Ctr 

Go

--Retorna todos los datos del usuario buscado
Create Procedure sp_BuscarUsuario @Usr varchar(30)
As
	select * from Usuario where Usuario = @Usr
Go

-------------------------------------------CIUDAD---------------------------------------------

--Agrega una nueva Ciudad, retorna -1 si algun par�metro es vac�o
--retorna 1 en si hay �xito.
Create Procedure sp_AltaCiudad @CodCiud varchar(3), @Nom varchar(30), @CodPais varchar(3)
AS
	if @CodCiud ='' or @Nom ='' or @CodPais =''
		return -1
	if not exists (select * from Pais where CodPais= @CodPais)
		return -2
	if exists (select * from Ciudad where CodCiudad = @CodCiud and CodPais =@CodPais)
		return -3
	Begin try
		insert into Ciudad (CodCiudad, Nombre, CodPais)
		Values (@CodCiud,@Nom,@CodPais)
		return 1
	End try
	Begin Catch
		declare @er int
		set @er = @@ERROR
		return @er
	End catch
Go

Create Procedure sp_EditCiudad @CodCiud varchar(3), @Nom varchar(30), @CodPais varchar(3)
AS
	if @CodCiud ='' or @Nom ='' or @CodPais =''
		return -1
	if not exists(select * from Ciudad where CodCiudad =@CodCiud and CodPais=@CodPais)
		return -2

	Begin try 
		update Ciudad set Nombre= @Nom 
		where CodCiudad= @CodCiud and CodPais=@CodPais
		return 1
	End try
	Begin Catch
		declare @er int
		set @er = @@ERROR
		return @er
	End catch
Go

--Elimina la ciudad y sus pron�sticos asociados
Create Procedure sp_BajaCiudad @CodCiud varchar(3), @CodPais varchar(3)
As
	if @CodCiud ='' or @CodPais='' return -1
	if not exists (select * from Ciudad where CodCiudad=@CodCiud and CodPais=@CodPais)
		return -2

	Begin tran
	Begin try
		
			delete from Pronostico where CodCiudad=@CodCiud and @CodPais=@CodPais

		delete from Ciudad where CodCiudad = @CodCiud and CodPais=@CodPais 
		commit tran
		return 1
	End try
	Begin Catch
		rollback tran
		declare @er int
		set @er = @@ERROR
		return @er
	End catch
Go

--Retorna todas las Ciudades
Create Procedure sp_TodasLasCiudades
AS
	select * from Ciudad 
Go

--Retorna todos los datos de la ciudad buscada
Create Procedure sp_BuscarCiudad @CodCiud varchar(3), @CodPais varchar(3)
As
	select * from Ciudad where CodCiudad= @CodCiud and CodPais=@CodPais
Go

--Retorna todas las ciudades de cierto Pais
Create Procedure sp_CiudadesPais @CodPais varchar (3)
As
	
	select * from Ciudad where CodPais=@CodPais 
Go

-------------------------------------PRÓNOSTICO--------------------------------------------

--Agrega un nuevo Prónostico, 
Create proc sp_AgregarPronostico
@Usr varchar(30),@CodCiud varchar(3), @CodPais varchar(3), @Fecha datetime,@VelViento int,@ProbLluvia smallint,@ProbTormenta smallint,@TMax int, @TMin int, @TipodeCielo varchar(30)
	
As
	IF NOT EXISTS(SELECT * FROM Ciudad WHERE CodCiudad = @CodCiud and codPais= @codPais )
		return -1
	--VALIDAR FECHA y CodCiudad para no repetir pronosticto
	IF EXISTS( select * from Pronostico where fecha= @fecha and CodCiudad= @CodCiud)
		return -2  

	IF @Fecha ='' or @VelViento ='' or @ProbLluvia =''or @ProbTormenta ='' or @TMax =''or @TMin ='' or @TipodeCielo = ''
				return -3

		Begin try
		
			
			INSERT INTO Pronostico (Usuario,CodCiudad,CodPais,Fecha,VelViento,ProbLluvia,ProbTormenta,TempMax,TempMin,TipodeCielo)
			values (@Usr,@CodCiud,@CodPais,@Fecha,@VelViento,@ProbLluvia,@ProbTormenta,@TMax,@TMin,@TipodeCielo)
		
						
	
			
			RETURN 1
					
				
		End try
		begin catch
			declare @er int
			set @er = @@ERROR
			return @er
		end catch
GO
---Retornar Pronosticos por ciudad
Create procedure sp_PronosticoPorCiudad @CodCiud varchar(3), @CodPais varchar (3)
AS
select * from Pronostico where CodCiudad =@CodCiud and CodPais=@CodPais
order by Pronostico.Fecha 
go


---Retornar Pronosticos por fecha (DEBE COINCIDIR LA FECHA Y LA HORA)
Create procedure sp_PronosticoPorFecha @fecha datetime
AS

select * from Pronostico where Fecha =@fecha
order by Pronostico.Fecha

go

--RETORNA TODOS LOS PRONOSTIOS PARA LA FECHA (SIN IMPORTAR SU HORA)
Create procedure sp_PronosticosParaFecha @fecha date
AS
    select * from pronostico where 
	YEAR (Fecha)= YEAR (@fecha) AND MONTH (Fecha)= MONTH (@fecha) AND DAY (Fecha)=DAY(@fecha)
Go