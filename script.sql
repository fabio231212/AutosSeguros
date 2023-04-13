CREATE PROCEDURE usp_Verificar_Login
	@Correo varchar(50),
	@Clave varchar(50)
AS
BEGIN
	select * from Usuario where @correo = Correo and @Clave = Clave
END



CREATE PROCEDURE usp_DELETE_DetallePolizaByIdTipoPoliza
	@IdTipoPoliza int
AS
BEGIN
	delete from DetallePoliza where IdTipoPoliza = @IdTipoPoliza
END

select * from TipoPoliza
select * from DetallePoliza
delete from DetallePoliza where IdTipoPoliza = 123


-----------------------------------------------------------------------------------------------------------------

--Obtener coberturas agregadas al tipo de poliza
CREATE PROCEDURE usp_coberturasAgregadas
	@IdTipoPoliza int
AS
BEGIN
	select DetallePoliza.IdCobertura, Cobertura.Descripcion, Cobertura.Precio,Cobertura.Total from DetallePoliza inner join  Cobertura on DetallePoliza.IdCobertura = Cobertura.Id 
	where DetallePoliza.IdTipoPoliza = @IdTipoPoliza
END

select * from TipoPoliza
select * from DetallePoliza
delete from DetallePoliza where IdTipoPoliza = 123

----------------------------------------------------------------------------------------------------------------------------------------
--Usuario by filtro
CREATE PROCEDURE [dbo].[usp_ObtenerUsuarioByFiltro]
	@filtro nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	select * from  [Usuario] where [Nombre] like @filtro and IdTipoUsuario = 2
END
GO


select * from Poliza
select *from EncabezadoFactura
select * from DetallePoliza


------------------------------------------------------------------------------------------------
--Obtener reporteFactura
CREATE PROCEDURE [dbo].[usp_ObtenerFacturaReporte]
	@IdFactura int
AS
BEGIN
	SET NOCOUNT ON;
	
SELECT        Usuario.Id, Usuario.Nombre, Usuario.Apellido1,Usuario.Apellido2, Factura.Id[IdFactura], Factura.FechaFacturacion, Factura.TotalDolares, Factura.TotalColones,Poliza.Id[IdPoliza]
              ,Poliza.Descripcion,Poliza.FechaVencimiento,TipoPoliza.Id[IdTipoPoliza],TipoPoliza.Descripcion[DescripcionTipoPoliza],Poliza.Descripcion[DescripcionPoliza],DetallePoliza.IdCobertura,
			  Cobertura.Descripcion[DescripcionCobertura],Cobertura.Total[CoberturaTotal]
FROM            Usuario INNER JOIN
                         Factura ON Usuario.Id = Factura.IdUsuario INNER JOIN
                         Poliza ON Poliza.Id= Factura.IdPoliza inner join TipoPoliza on TipoPoliza.Id = Poliza.IdTipoPoliza inner join DetallePoliza on DetallePoliza.IdTipoPoliza = TipoPoliza.Id
						 inner join Cobertura on Cobertura.Id = DetallePoliza.IdCobertura

						 where Factura.Id = @IdFactura
END
GO

SELECT        Usuario.Id, Usuario.Nombre, Usuario.Apellido1,Usuario.Apellido2, Factura.Id[IdFactura], Factura.FechaFacturacion, Factura.TotalDolares, Factura.TotalColones,Poliza.Id[IdPoliza]
              ,Poliza.Descripcion,Poliza.FechaVencimiento,TipoPoliza.Id[IdTipoPoliza],TipoPoliza.Descripcion[DescripcionTipoPoliza],Poliza.Descripcion[DescripcionPoliza],DetallePoliza.IdCobertura,
			  Cobertura.Descripcion[DescripcionCobertura],Cobertura.Total[CoberturaTotal]
FROM            Usuario INNER JOIN
                         Factura ON Usuario.Id = Factura.IdUsuario INNER JOIN
                         Poliza ON Poliza.Id= Factura.IdPoliza inner join TipoPoliza on TipoPoliza.Id = Poliza.IdTipoPoliza inner join DetallePoliza on DetallePoliza.IdTipoPoliza = TipoPoliza.Id
						 inner join Cobertura on Cobertura.Id = DetallePoliza.IdCobertura

						 where Factura.Id = 40
select * from Factura
						
------------------------------------------------------------------------------------------------------------
--UsuarioByIdFac
CREATE PROCEDURE [dbo].[usp_UsuarioByFactura]
	@IdFactura int
AS
BEGIN
	SET NOCOUNT ON;
	
select Usuario.Id from Usuario inner join Factura on Usuario.Id = Factura.IdUsuario where Factura.Id = @IdFactura
END
GO


-------------------------------------------------------------------------------------
--Select suma facturas by Rango fecha
CREATE PROCEDURE [dbo].[usp_PolizaTotalByFechas]
	@Desde Datetime,
	@Hasta Datetime
AS
BEGIN
	SET NOCOUNT ON;
Select Factura.Id,IdPoliza,Factura.TotalColones,Factura.TotalDolares,Poliza.Descripcion from Factura INNER JOIN Poliza on Poliza.Id = Factura.IdPoliza
where FechaFacturacion between @Desde and @Hasta 
END
GO





select * from Factura

--------------------------------------------------------------------------------------
--POlizas por usuario
Select Factura.IdUsuario,Factura.IdPoliza,Factura.IdUsuario,Factura.TotalColones,Factura.TotalDolares,Usuario.Nombre,Usuario.Apellido1,Poliza.Descripcion from Factura
inner join Usuario on Factura.IdUsuario = Usuario.Id inner join Poliza on Factura.IdPoliza = Poliza.Id where Factura.IdUsuario = @IdUsuario
CREATE PROCEDURE [dbo].[usp_PolizaByIdUsuario]
	@IdUsuario varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
Select Factura.IdUsuario,Factura.IdPoliza,Factura.IdUsuario,Factura.TotalColones,Factura.TotalDolares,Usuario.Nombre,Usuario.Apellido1,Poliza.Descripcion from Factura
inner join Usuario on Factura.IdUsuario = Usuario.Id inner join Poliza on Factura.IdPoliza = Poliza.Id where Factura.IdUsuario = @IdUsuario
END
GO
----------------------------------------------------------------------------------------------------------------------------
--Factura de hoy para anular
Select Factura.IdUsuario,Factura.IdPoliza,Factura.IdUsuario,Factura.TotalColones,Factura.TotalDolares,Usuario.Nombre,Usuario.Apellido1,Poliza.Descripcion from Factura
inner join Usuario on Factura.IdUsuario = Usuario.Id inner join Poliza on Factura.IdPoliza = Poliza.Id where Factura.IdUsuario = @IdUsuario
CREATE PROCEDURE [dbo].[usp_ObtenerFacturaHoy]
		@Desde Datetime,
	@Hasta Datetime
AS
BEGIN
	SET NOCOUNT ON;
select * from Factura where FechaFacturacion between @Desde and @Hasta and Activo = 1
END
GO

select * from Factura where FechaFacturacion between '2022-11-20 00:00:00' and '2022-11-20 23:59:59'

-----------------------------------------------------------------------------------------------------------------------------------------------
--Actualizar factura inactiva
CREATE PROCEDURE [dbo].[usp_UPDATE_ActivoFactura]
		@IdFactura int
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE Factura set Activo = 0 WHERE Factura.Id = @IdFactura;
END
GO
-----------------------------------------------------------------------------------------------------
--mostrar facturas anuladas
CREATE PROCEDURE [dbo].[usp_SELECT_FacturasAnuladas]
AS
BEGIN
	SET NOCOUNT ON;
	select * from Factura where Activo = 0
END
GO

------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--ventas dias
CREATE PROCEDURE [dbo].[usp_SELECT_VentasByDia]
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Mes TINYINT = DATEPART(MONTH,GETDATE());
DECLARE @Anio INT =DATEPART(YEAR,GETDATE());
DECLARE @dia TINYINT = 1;
DECLARE @PrimerDiaMesActual date = cast(convert(datetime,convert(varchar(10),@Anio) + '-' + convert(varchar(10),@mes) + '-' + convert(varchar(10),@dia), 101) as date);
DECLARE @UtimoDiaMesActual date = DATEADD(day,-1,DATEADD(MONTH,1,@PrimerDiaMesActual))
DECLARE @UltimoDia INT = DATEPART(DAY, @UtimoDiaMesActual);

delete from  fechas

WHILE (@dia <= @ultimoDia)
BEGIN
    PRINT @dia 
    INSERT INTO fechas (fecha) VALUES (cast(convert(datetime,convert(varchar(10),@Anio) + '-' + convert(varchar(10),@mes) + '-' + convert(varchar(10),@dia), 101) as date))
    SET @dia=@dia+1;
END 
SELECT F.fecha, ISNULL((SELECT SUM(VMP.TotalDolares) from Factura VMP  WHERE CONVERT(varchar(10), VMP.FechaFacturacion, 112) = CONVERT(varchar(10), F.fecha, 112)),0) AS Total FROM Fechas F


END
GO
--------------------------------------------------------------------------------------------

--select iva más reciente



CREATE PROCEDURE [dbo].[usp_SELECT_IVA_Reciente]
AS
BEGIN
	SET NOCOUNT ON;
	Select * from IVA
WHERE Fecha  = (
    SELECT MAX(Fecha)
    FROM IVA
)
END
GO