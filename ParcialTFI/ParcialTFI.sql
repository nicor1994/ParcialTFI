USE [master]
GO
/****** Object:  Database [ParcialTFI]    Script Date: 22/09/2020 1:16:51 ******/
CREATE DATABASE [ParcialTFI]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ParcialTFI', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ParcialTFI.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ParcialTFI_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\ParcialTFI_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ParcialTFI] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ParcialTFI].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ParcialTFI] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ParcialTFI] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ParcialTFI] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ParcialTFI] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ParcialTFI] SET ARITHABORT OFF 
GO
ALTER DATABASE [ParcialTFI] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ParcialTFI] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ParcialTFI] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ParcialTFI] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ParcialTFI] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ParcialTFI] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ParcialTFI] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ParcialTFI] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ParcialTFI] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ParcialTFI] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ParcialTFI] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ParcialTFI] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ParcialTFI] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ParcialTFI] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ParcialTFI] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ParcialTFI] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ParcialTFI] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ParcialTFI] SET RECOVERY FULL 
GO
ALTER DATABASE [ParcialTFI] SET  MULTI_USER 
GO
ALTER DATABASE [ParcialTFI] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ParcialTFI] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ParcialTFI] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ParcialTFI] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ParcialTFI] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ParcialTFI', N'ON'
GO
ALTER DATABASE [ParcialTFI] SET QUERY_STORE = OFF
GO
USE [ParcialTFI]
GO
/****** Object:  Table [dbo].[Banco]    Script Date: 22/09/2020 1:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banco](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Banco] [varchar](50) NULL,
 CONSTRAINT [PK_Banco] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 22/09/2020 1:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Categoria] [varchar](50) NULL,
	[ID_Division] [int] NULL,
	[Sueldo] [float] NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Concepto]    Script Date: 22/09/2020 1:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Concepto](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_Tipo] [int] NULL,
	[Valor] [float] NULL,
	[ID_Valor] [int] NULL,
	[Nombre] [varchar](50) NULL,
	[Borrado] [int] NULL,
 CONSTRAINT [PK_Concepto] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departamento]    Script Date: 22/09/2020 1:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamento](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Departamento] [varchar](50) NULL,
 CONSTRAINT [PK_Departamento] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Division]    Script Date: 22/09/2020 1:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Division](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Division] [varchar](50) NULL,
	[ID_Departamento] [int] NULL,
 CONSTRAINT [PK_Division] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 22/09/2020 1:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[Legajo] [int] NULL,
	[CUIL] [int] NULL,
	[ID_Categoria] [int] NULL,
	[FechaIngreso] [date] NULL,
	[Cuenta] [float] NULL,
	[ID_Banco] [int] NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmpleadoDespedido]    Script Date: 22/09/2020 1:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpleadoDespedido](
	[ID] [int] NOT NULL,
	[FechaDespido] [date] NULL,
 CONSTRAINT [PK_EmpleadoDespedido] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recibo]    Script Date: 22/09/2020 1:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recibo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_Empleado] [int] NULL,
	[Subtotal_ConRet] [float] NULL,
	[Subtotal_Exentas] [float] NULL,
	[Subtotal_Deducciones] [float] NULL,
	[Total] [float] NULL,
	[TipoLiquidacion] [varchar](50) NULL,
	[Fecha] [date] NULL,
	[Periodo] [varchar](50) NULL,
	[Banco] [varchar](50) NULL,
 CONSTRAINT [PK_Recibo] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recibo_Concepto]    Script Date: 22/09/2020 1:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recibo_Concepto](
	[ID_Recibo] [int] NOT NULL,
	[ID_Concepto] [int] NOT NULL,
	[Valor] [float] NULL,
 CONSTRAINT [PK_Recibo_Concepto] PRIMARY KEY CLUSTERED 
(
	[ID_Recibo] ASC,
	[ID_Concepto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Concepto]    Script Date: 22/09/2020 1:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Concepto](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [varchar](50) NULL,
 CONSTRAINT [PK_Tipo_Concepto] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Valor_Concepto]    Script Date: 22/09/2020 1:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Valor_Concepto](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TipoValor] [varchar](50) NULL,
 CONSTRAINT [PK_Valor_Concepto] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Categoria]  WITH CHECK ADD  CONSTRAINT [FK_Categoria_Division] FOREIGN KEY([ID_Division])
REFERENCES [dbo].[Division] ([ID])
GO
ALTER TABLE [dbo].[Categoria] CHECK CONSTRAINT [FK_Categoria_Division]
GO
ALTER TABLE [dbo].[Concepto]  WITH CHECK ADD  CONSTRAINT [FK_Concepto_Tipo_Concepto] FOREIGN KEY([ID_Tipo])
REFERENCES [dbo].[Tipo_Concepto] ([ID])
GO
ALTER TABLE [dbo].[Concepto] CHECK CONSTRAINT [FK_Concepto_Tipo_Concepto]
GO
ALTER TABLE [dbo].[Concepto]  WITH CHECK ADD  CONSTRAINT [FK_Concepto_Valor_Concepto] FOREIGN KEY([ID_Valor])
REFERENCES [dbo].[Valor_Concepto] ([ID])
GO
ALTER TABLE [dbo].[Concepto] CHECK CONSTRAINT [FK_Concepto_Valor_Concepto]
GO
ALTER TABLE [dbo].[Division]  WITH CHECK ADD  CONSTRAINT [FK_Division_Departamento] FOREIGN KEY([ID_Departamento])
REFERENCES [dbo].[Departamento] ([ID])
GO
ALTER TABLE [dbo].[Division] CHECK CONSTRAINT [FK_Division_Departamento]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_Empleado_Banco] FOREIGN KEY([ID_Banco])
REFERENCES [dbo].[Banco] ([ID])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_Empleado_Banco]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_Empleado_Categoria] FOREIGN KEY([ID_Categoria])
REFERENCES [dbo].[Categoria] ([ID])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_Empleado_Categoria]
GO
ALTER TABLE [dbo].[EmpleadoDespedido]  WITH CHECK ADD  CONSTRAINT [FK_EmpleadoDespedido_Empleado] FOREIGN KEY([ID])
REFERENCES [dbo].[Empleado] ([ID])
GO
ALTER TABLE [dbo].[EmpleadoDespedido] CHECK CONSTRAINT [FK_EmpleadoDespedido_Empleado]
GO
ALTER TABLE [dbo].[Recibo]  WITH CHECK ADD  CONSTRAINT [FK_Recibo_Empleado] FOREIGN KEY([ID_Empleado])
REFERENCES [dbo].[Empleado] ([ID])
GO
ALTER TABLE [dbo].[Recibo] CHECK CONSTRAINT [FK_Recibo_Empleado]
GO
ALTER TABLE [dbo].[Recibo_Concepto]  WITH CHECK ADD  CONSTRAINT [FK_Recibo_Concepto_Concepto] FOREIGN KEY([ID_Concepto])
REFERENCES [dbo].[Concepto] ([ID])
GO
ALTER TABLE [dbo].[Recibo_Concepto] CHECK CONSTRAINT [FK_Recibo_Concepto_Concepto]
GO
ALTER TABLE [dbo].[Recibo_Concepto]  WITH CHECK ADD  CONSTRAINT [FK_Recibo_Concepto_Recibo] FOREIGN KEY([ID_Recibo])
REFERENCES [dbo].[Recibo] ([ID])
GO
ALTER TABLE [dbo].[Recibo_Concepto] CHECK CONSTRAINT [FK_Recibo_Concepto_Recibo]
GO
/****** Object:  StoredProcedure [dbo].[Concepto_Agregar]    Script Date: 22/09/2020 1:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Concepto_Agregar] 
	@IDTipo int, @Valor float, @IDValor int, @Nombre varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	Insert into Concepto(ID_Tipo, Valor, ID_Valor, Nombre, Borrado)
	values(@IDTipo, @Valor, @IDValor, @Nombre, 0)

END
GO
/****** Object:  StoredProcedure [dbo].[Concepto_Baja]    Script Date: 22/09/2020 1:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Concepto_Baja] 
	@ID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	Update Concepto
	set Borrado = 1
	where ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[Concepto_Modificar]    Script Date: 22/09/2020 1:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[Concepto_Modificar]
	@IDTipo int, @Valor float, @IDValor int, @Nombre varchar(50), @id int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	
	Update Concepto
	set ID_Tipo = @IDTipo, Valor = @valor, ID_Valor = @IDValor, Nombre = @Nombre
	where ID = @id
END   
GO
/****** Object:  StoredProcedure [dbo].[Empleado_Agregar]    Script Date: 22/09/2020 1:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Empleado_Agregar]
	@nombre varchar(50), @apellido varchar(50), @legajo int, @cuil int, @cuenta int, @idbanco int, @ingreso date, @idcat int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	Insert into Empleado(Nombre, Apellido, Legajo, CUIL, Cuenta, ID_Banco, FechaIngreso, ID_Categoria, Borrado) values (@nombre, @apellido, @legajo, @cuil, @cuenta, @idbanco, @ingreso, @idcat, 0)

END   
GO
/****** Object:  StoredProcedure [dbo].[Empleado_Baja]    Script Date: 22/09/2020 1:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Empleado_Baja]
@id int, @fecha date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	

	Insert into EmpleadoDespedido(ID, FechaDespido) values (@id, @fecha)


END
GO
/****** Object:  StoredProcedure [dbo].[Empleado_Modificar]    Script Date: 22/09/2020 1:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[Empleado_Modificar]
	@nombre varchar(50), @apellido varchar(50), @legajo int, @cuil int, @cuenta int, @idbanco int, @id int, @idcat int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	
	Update Empleado
	set Nombre = @nombre, Apellido = @apellido, Legajo = @legajo, CUIL = @cuil, Cuenta = @cuenta, ID_Banco = @idbanco, ID_Categoria = @idcat
	where ID = @id
END   
GO
/****** Object:  StoredProcedure [dbo].[ListarCategorias]    Script Date: 22/09/2020 1:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ListarCategorias]
	@id int
AS
BEGIN
	Select * from Categoria where ID_Division = @id
END
GO
/****** Object:  StoredProcedure [dbo].[ListarDivisiones]    Script Date: 22/09/2020 1:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ListarDivisiones]
	@id int
AS
BEGIN
	Select * from Division where ID_Departamento = @id
END
GO
/****** Object:  StoredProcedure [dbo].[ListarEntidad]    Script Date: 22/09/2020 1:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ListarEntidad]
	 @Tabla nvarchar(100)

As

Declare @sql nvarchar(max);
Declare @parametros varchar(500);


Set @sql = 'SELECT * FROM ' + QUOTENAME(@Tabla);

exec sp_executesql @sql
GO
/****** Object:  StoredProcedure [dbo].[ObtenerEntidadID]    Script Date: 22/09/2020 1:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE Procedure [dbo].[ObtenerEntidadID]
(
 @Tabla nvarchar(100),
 @id nvarchar(10)
)

As

Declare @sql nvarchar(max);
Declare @parametros varchar(500);


Set @sql = 'SELECT * FROM ' + QUOTENAME(@Tabla) + N' WHERE ID ='+ @id;

exec sp_executesql @sql
          
        
GO
/****** Object:  StoredProcedure [dbo].[Recibo_Agregar]    Script Date: 22/09/2020 1:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Recibo_Agregar]
	@idemp int, @fechapago datetime, @periodo varchar(50), @subtExe float, @subConRet float, @subDeduc float, @total float, @tipo varchar
AS
BEGIN

Insert into Recibo(ID_Empleado, Fecha, Periodo, Subtotal_Exentas, Subtotal_ConRet, Subtotal_Deducciones, total, TipoLiquidacion)
values (@idemp, @fechapago, @periodo, @subtExe, @subConRet, @subDeduc, @total, @tipo)
END
GO
/****** Object:  StoredProcedure [dbo].[Recibo_Listar]    Script Date: 22/09/2020 1:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Recibo_Listar] 
	@idemp int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
Select * from Recibo where ID_Empleado = @idemp
END
GO
/****** Object:  StoredProcedure [dbo].[Recibo_ListarRenglones]    Script Date: 22/09/2020 1:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Recibo_ListarRenglones] 
	@idrec int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
Select * from Recibo_Concepto where ID_Recibo = @idrec
END
GO
/****** Object:  StoredProcedure [dbo].[Renglon_Agregar]    Script Date: 22/09/2020 1:16:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Renglon_Agregar]
	-- Add the parameters for the stored procedure here
	@idconc int, @valor float
AS
BEGIN	

	insert into Recibo_Concepto(ID_Concepto, ID_Recibo, Valor)
	values (@idconc,(Select Max(ID) from Recibo), @valor)

END
GO
USE [master]
GO
ALTER DATABASE [ParcialTFI] SET  READ_WRITE 
GO
