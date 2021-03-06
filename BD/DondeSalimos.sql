USE [master]
GO
/****** Object:  Database [DondeSalimos]    Script Date: 1/5/2022 01:02:00 ******/
CREATE DATABASE [DondeSalimos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DondeSalimos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NZALAZAR\MSSQL\DATA\DondeSalimos.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DondeSalimos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.NZALAZAR\MSSQL\DATA\DondeSalimos_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DondeSalimos] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DondeSalimos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DondeSalimos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DondeSalimos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DondeSalimos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DondeSalimos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DondeSalimos] SET ARITHABORT OFF 
GO
ALTER DATABASE [DondeSalimos] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DondeSalimos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DondeSalimos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DondeSalimos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DondeSalimos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DondeSalimos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DondeSalimos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DondeSalimos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DondeSalimos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DondeSalimos] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DondeSalimos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DondeSalimos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DondeSalimos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DondeSalimos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DondeSalimos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DondeSalimos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DondeSalimos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DondeSalimos] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DondeSalimos] SET  MULTI_USER 
GO
ALTER DATABASE [DondeSalimos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DondeSalimos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DondeSalimos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DondeSalimos] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DondeSalimos] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DondeSalimos] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DondeSalimos] SET QUERY_STORE = OFF
GO
USE [DondeSalimos]
GO
/****** Object:  Table [dbo].[Administrador]    Script Date: 1/5/2022 01:02:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrador](
	[ID_Administrador] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[Contrasenia] [varchar](50) NOT NULL,
	[Permisos] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Administrador] PRIMARY KEY CLUSTERED 
(
	[ID_Administrador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 1/5/2022 01:02:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[ID_Cliente] [int] IDENTITY(1,1) NOT NULL,
	[Apodo] [varchar](50) NULL,
	[Nombre] [varchar](50) NOT NULL,
	[TipoDocumento] [varchar](50) NOT NULL,
	[NroDocumento] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Telefono] [int] NULL,
	[Usuario] [varchar](50) NOT NULL,
	[Contrasenia] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[ID_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comercio]    Script Date: 1/5/2022 01:02:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comercio](
	[ID_Comercio] [int] IDENTITY(1,1) NOT NULL,
	[GeneroMusical] [varchar](50) NULL,
	[Mesas] [int] NULL,
	[Nombre] [varchar](50) NOT NULL,
	[TipoDocumento] [varchar](50) NOT NULL,
	[NroDocumento] [varchar](50) NOT NULL,
	[Email] [varchar](50) NULL,
	[Telefono] [int] NULL,
	[Direccion] [varchar](50) NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[Contrasenia] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Comercio] PRIMARY KEY CLUSTERED 
(
	[ID_Comercio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 1/5/2022 01:02:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[ID_Factura] [int] IDENTITY(1,1) NOT NULL,
	[ID_Comercio] [int] NOT NULL,
	[ID_Pago] [int] NOT NULL,
	[TipoFactura] [varchar](50) NOT NULL,
	[Importe] [real] NOT NULL,
	[FechaFactura] [date] NOT NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[ID_Factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grupo]    Script Date: 1/5/2022 01:02:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grupo](
	[ID_Grupo] [int] IDENTITY(1,1) NOT NULL,
	[NombreGrupo] [varchar](50) NOT NULL,
	[CantIntegrantes] [int] NOT NULL,
	[EnlaceComunicacion] [varchar](250) NOT NULL,
	[Localizacion] [int] NOT NULL,
	[ID_Cliente] [int] NULL,
	[ID_Administrador] [int] NULL,
 CONSTRAINT [PK_Grupo] PRIMARY KEY CLUSTERED 
(
	[ID_Grupo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Novedades]    Script Date: 1/5/2022 01:02:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Novedades](
	[ID_Novedades] [int] IDENTITY(1,1) NOT NULL,
	[ID_Comercio] [int] NOT NULL,
	[Descripcion] [varchar](50) NULL,
	[Visualizaciones] [int] NOT NULL,
 CONSTRAINT [PK_Novedades] PRIMARY KEY CLUSTERED 
(
	[ID_Novedades] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pago]    Script Date: 1/5/2022 01:02:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pago](
	[ID_Pago] [int] IDENTITY(1,1) NOT NULL,
	[ID_Comercio] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Pago] PRIMARY KEY CLUSTERED 
(
	[ID_Pago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Presupuesto]    Script Date: 1/5/2022 01:02:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Presupuesto](
	[ID_Presupuesto] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](50) NOT NULL,
	[Vigencia] [time](7) NULL,
	[Descripcion] [varchar](200) NULL,
	[Estado] [bit] NOT NULL,
	[ID_Factura] [int] NULL,
 CONSTRAINT [PK_Presupuesto] PRIMARY KEY CLUSTERED 
(
	[ID_Presupuesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Publicidad]    Script Date: 1/5/2022 01:02:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publicidad](
	[ID_Publicidad] [int] IDENTITY(1,1) NOT NULL,
	[ID_Comercio] [int] NOT NULL,
	[Visualizaciones] [int] NOT NULL,
	[Tiempo] [time](7) NULL,
	[ImagenVideo] [bit] NULL,
 CONSTRAINT [PK_Publicidad] PRIMARY KEY CLUSTERED 
(
	[ID_Publicidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Resenia]    Script Date: 1/5/2022 01:02:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resenia](
	[ID_Resenia] [int] IDENTITY(1,1) NOT NULL,
	[ID_Cliente] [int] NOT NULL,
	[ID_Comercio] [int] NOT NULL,
	[Reportado] [varchar](50) NULL,
	[Mostrar] [bit] NULL,
	[Comentario] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Resenia] PRIMARY KEY CLUSTERED 
(
	[ID_Resenia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reserva]    Script Date: 1/5/2022 01:02:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reserva](
	[ID_Reserva] [int] IDENTITY(1,1) NOT NULL,
	[CantPersonas] [int] NOT NULL,
	[TiempoTolerancia] [time](7) NOT NULL,
	[ID_comercio] [int] NOT NULL,
	[ID_cliente] [int] NOT NULL,
 CONSTRAINT [PK_Reserva] PRIMARY KEY CLUSTERED 
(
	[ID_Reserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Comercio1] FOREIGN KEY([ID_Comercio])
REFERENCES [dbo].[Comercio] ([ID_Comercio])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Comercio1]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Pago] FOREIGN KEY([ID_Pago])
REFERENCES [dbo].[Pago] ([ID_Pago])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Pago]
GO
ALTER TABLE [dbo].[Grupo]  WITH CHECK ADD  CONSTRAINT [FK_Grupo_Administrador] FOREIGN KEY([ID_Administrador])
REFERENCES [dbo].[Administrador] ([ID_Administrador])
GO
ALTER TABLE [dbo].[Grupo] CHECK CONSTRAINT [FK_Grupo_Administrador]
GO
ALTER TABLE [dbo].[Grupo]  WITH CHECK ADD  CONSTRAINT [FK_Grupo_Cliente] FOREIGN KEY([ID_Cliente])
REFERENCES [dbo].[Cliente] ([ID_Cliente])
GO
ALTER TABLE [dbo].[Grupo] CHECK CONSTRAINT [FK_Grupo_Cliente]
GO
ALTER TABLE [dbo].[Novedades]  WITH CHECK ADD  CONSTRAINT [FK_Novedades_Comercio] FOREIGN KEY([ID_Comercio])
REFERENCES [dbo].[Comercio] ([ID_Comercio])
GO
ALTER TABLE [dbo].[Novedades] CHECK CONSTRAINT [FK_Novedades_Comercio]
GO
ALTER TABLE [dbo].[Presupuesto]  WITH CHECK ADD  CONSTRAINT [FK_Presupuesto_Factura] FOREIGN KEY([ID_Factura])
REFERENCES [dbo].[Factura] ([ID_Factura])
GO
ALTER TABLE [dbo].[Presupuesto] CHECK CONSTRAINT [FK_Presupuesto_Factura]
GO
ALTER TABLE [dbo].[Publicidad]  WITH CHECK ADD  CONSTRAINT [FK_Publicidad_Comercio1] FOREIGN KEY([ID_Comercio])
REFERENCES [dbo].[Comercio] ([ID_Comercio])
GO
ALTER TABLE [dbo].[Publicidad] CHECK CONSTRAINT [FK_Publicidad_Comercio1]
GO
ALTER TABLE [dbo].[Resenia]  WITH CHECK ADD  CONSTRAINT [FK_Resenia_Cliente] FOREIGN KEY([ID_Cliente])
REFERENCES [dbo].[Cliente] ([ID_Cliente])
GO
ALTER TABLE [dbo].[Resenia] CHECK CONSTRAINT [FK_Resenia_Cliente]
GO
ALTER TABLE [dbo].[Resenia]  WITH CHECK ADD  CONSTRAINT [FK_Resenia_Comercio] FOREIGN KEY([ID_Comercio])
REFERENCES [dbo].[Comercio] ([ID_Comercio])
GO
ALTER TABLE [dbo].[Resenia] CHECK CONSTRAINT [FK_Resenia_Comercio]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Cliente] FOREIGN KEY([ID_cliente])
REFERENCES [dbo].[Cliente] ([ID_Cliente])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Cliente]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Comercio] FOREIGN KEY([ID_comercio])
REFERENCES [dbo].[Comercio] ([ID_Comercio])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Comercio]
GO
USE [master]
GO
ALTER DATABASE [DondeSalimos] SET  READ_WRITE 
GO
