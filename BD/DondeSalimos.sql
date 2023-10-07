USE [master]
GO
/****** Object:  Database [DondeSalimos]    Script Date: 6/10/2023 21:39:19 ******/
CREATE DATABASE [DondeSalimos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DondeSalimos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\DondeSalimos.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DondeSalimos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\DondeSalimos_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
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
/****** Object:  Table [dbo].[Cliente]    Script Date: 6/10/2023 21:39:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[ID_Cliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[TipoDocumento] [varchar](50) NOT NULL,
	[NroDocumento] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Telefono] [varchar](15) NOT NULL,
	[ID_Usuario] [int] NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[ID_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comercio]    Script Date: 6/10/2023 21:39:20 ******/
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
	[Email] [varchar](50) NOT NULL,
	[Telefono] [varchar](15) NOT NULL,
	[Direccion] [varchar](50) NOT NULL,
	[ID_Usuario] [int] NOT NULL,
 CONSTRAINT [PK_Comercio] PRIMARY KEY CLUSTERED 
(
	[ID_Comercio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 6/10/2023 21:39:20 ******/
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
/****** Object:  Table [dbo].[Grupo]    Script Date: 6/10/2023 21:39:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grupo](
	[ID_Grupo] [int] IDENTITY(1,1) NOT NULL,
	[NombreGrupo] [varchar](50) NULL,
	[CantIntegrantes] [int] NULL,
	[EnlaceComunicacion] [varchar](250) NOT NULL,
	[Localizacion] [int] NOT NULL,
	[ID_Cliente] [int] NULL,
 CONSTRAINT [PK_Grupo] PRIMARY KEY CLUSTERED 
(
	[ID_Grupo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Novedad]    Script Date: 6/10/2023 21:39:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Novedad](
	[ID_Novedad] [int] IDENTITY(1,1) NOT NULL,
	[ID_Comercio] [int] NOT NULL,
	[Descripcion] [varchar](50) NULL,
	[Visualizaciones] [int] NOT NULL,
 CONSTRAINT [PK_Novedades] PRIMARY KEY CLUSTERED 
(
	[ID_Novedad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pago]    Script Date: 6/10/2023 21:39:20 ******/
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
/****** Object:  Table [dbo].[Presupuesto]    Script Date: 6/10/2023 21:39:20 ******/
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
/****** Object:  Table [dbo].[Publicidad]    Script Date: 6/10/2023 21:39:20 ******/
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
/****** Object:  Table [dbo].[Resenia]    Script Date: 6/10/2023 21:39:20 ******/
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
/****** Object:  Table [dbo].[Reserva]    Script Date: 6/10/2023 21:39:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reserva](
	[ID_Reserva] [int] IDENTITY(1,1) NOT NULL,
	[CantPersonas] [int] NOT NULL,
	[TiempoTolerancia] [time](7) NOT NULL,
	[ID_Comercio] [int] NOT NULL,
	[ID_Cliente] [int] NOT NULL,
 CONSTRAINT [PK_Reserva] PRIMARY KEY CLUSTERED 
(
	[ID_Reserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 6/10/2023 21:39:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[ID_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [varchar](50) NOT NULL,
	[Contrasenia] [varchar](50) NOT NULL,
	[Administrador] [bit] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[ID_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([ID_Cliente], [Nombre], [Apellido], [TipoDocumento], [NroDocumento], [Email], [Telefono], [ID_Usuario]) VALUES (2, N'Nicolas', N'Zalazar', N'DNI', N'37206658', N'nico.zalazar92@gmail.com', N'+54951216512', 3)
INSERT [dbo].[Cliente] ([ID_Cliente], [Nombre], [Apellido], [TipoDocumento], [NroDocumento], [Email], [Telefono], [ID_Usuario]) VALUES (6, N'Federico', N'Botto', N'DNI', N'27205677', N'fefe@gmail.com', N'1165324575', 14)
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[Comercio] ON 

INSERT [dbo].[Comercio] ([ID_Comercio], [GeneroMusical], [Mesas], [Nombre], [TipoDocumento], [NroDocumento], [Email], [Telefono], [Direccion], [ID_Usuario]) VALUES (1, N'Cumbia', 15, N'La Mágica', N'CUIT', N'272056779', N'lamagica22@gmail.com', N'1185324597', N'avenida siempre viva 123, palermo', 7)
INSERT [dbo].[Comercio] ([ID_Comercio], [GeneroMusical], [Mesas], [Nombre], [TipoDocumento], [NroDocumento], [Email], [Telefono], [Direccion], [ID_Usuario]) VALUES (2, N'pop', 12, N'comercio 1', N'CUIT', N'20356947210', N'asdad@gmail.com', N'12313', N'avenida siempre viva 123', 4)
SET IDENTITY_INSERT [dbo].[Comercio] OFF
GO
SET IDENTITY_INSERT [dbo].[Grupo] ON 

INSERT [dbo].[Grupo] ([ID_Grupo], [NombreGrupo], [CantIntegrantes], [EnlaceComunicacion], [Localizacion], [ID_Cliente]) VALUES (5, N'La masturbanda', 15, N'nose que va aca ', 13216545, 6)
INSERT [dbo].[Grupo] ([ID_Grupo], [NombreGrupo], [CantIntegrantes], [EnlaceComunicacion], [Localizacion], [ID_Cliente]) VALUES (6, N'Grupo de prueba', 5, N'nose que iba aca', 2500, 2)
SET IDENTITY_INSERT [dbo].[Grupo] OFF
GO
SET IDENTITY_INSERT [dbo].[Novedad] ON 

INSERT [dbo].[Novedad] ([ID_Novedad], [ID_Comercio], [Descripcion], [Visualizaciones]) VALUES (1, 1, N'12 aniversario', 422)
INSERT [dbo].[Novedad] ([ID_Novedad], [ID_Comercio], [Descripcion], [Visualizaciones]) VALUES (2, 2, N'Nueva prueba', 150)
INSERT [dbo].[Novedad] ([ID_Novedad], [ID_Comercio], [Descripcion], [Visualizaciones]) VALUES (3, 1, N'asdad', 100)
INSERT [dbo].[Novedad] ([ID_Novedad], [ID_Comercio], [Descripcion], [Visualizaciones]) VALUES (4, 1, N'20 aniversario', 999)
SET IDENTITY_INSERT [dbo].[Novedad] OFF
GO
SET IDENTITY_INSERT [dbo].[Publicidad] ON 

INSERT [dbo].[Publicidad] ([ID_Publicidad], [ID_Comercio], [Visualizaciones], [Tiempo], [ImagenVideo]) VALUES (1, 1, 999, CAST(N'01:00:00' AS Time), 0)
INSERT [dbo].[Publicidad] ([ID_Publicidad], [ID_Comercio], [Visualizaciones], [Tiempo], [ImagenVideo]) VALUES (2, 2, 999, CAST(N'01:00:00' AS Time), 0)
SET IDENTITY_INSERT [dbo].[Publicidad] OFF
GO
SET IDENTITY_INSERT [dbo].[Resenia] ON 

INSERT [dbo].[Resenia] ([ID_Resenia], [ID_Cliente], [ID_Comercio], [Reportado], [Mostrar], [Comentario]) VALUES (1, 6, 1, N'Reportadooo F', 1, N'La mejor fiesta wachooo. Oaaaaaa perro')
INSERT [dbo].[Resenia] ([ID_Resenia], [ID_Cliente], [ID_Comercio], [Reportado], [Mostrar], [Comentario]) VALUES (4, 2, 2, N'Jujuuu', 1, N'nasheeeeeeeeeeee')
INSERT [dbo].[Resenia] ([ID_Resenia], [ID_Cliente], [ID_Comercio], [Reportado], [Mostrar], [Comentario]) VALUES (7, 6, 1, N'adad', 0, N'asdad')
SET IDENTITY_INSERT [dbo].[Resenia] OFF
GO
SET IDENTITY_INSERT [dbo].[Reserva] ON 

INSERT [dbo].[Reserva] ([ID_Reserva], [CantPersonas], [TiempoTolerancia], [ID_Comercio], [ID_Cliente]) VALUES (1, 3, CAST(N'01:00:00' AS Time), 1, 6)
INSERT [dbo].[Reserva] ([ID_Reserva], [CantPersonas], [TiempoTolerancia], [ID_Comercio], [ID_Cliente]) VALUES (2, 15, CAST(N'01:30:00' AS Time), 1, 2)
INSERT [dbo].[Reserva] ([ID_Reserva], [CantPersonas], [TiempoTolerancia], [ID_Comercio], [ID_Cliente]) VALUES (5, 7, CAST(N'01:30:00' AS Time), 1, 6)
INSERT [dbo].[Reserva] ([ID_Reserva], [CantPersonas], [TiempoTolerancia], [ID_Comercio], [ID_Cliente]) VALUES (9, 8, CAST(N'01:30:00' AS Time), 1, 2)
INSERT [dbo].[Reserva] ([ID_Reserva], [CantPersonas], [TiempoTolerancia], [ID_Comercio], [ID_Cliente]) VALUES (10, 12, CAST(N'01:30:00' AS Time), 1, 6)
SET IDENTITY_INSERT [dbo].[Reserva] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([ID_Usuario], [NombreUsuario], [Contrasenia], [Administrador]) VALUES (3, N'NekoNFT92', N'123456', 0)
INSERT [dbo].[Usuario] ([ID_Usuario], [NombreUsuario], [Contrasenia], [Administrador]) VALUES (4, N'FefePistola22', N'fefinho', 0)
INSERT [dbo].[Usuario] ([ID_Usuario], [NombreUsuario], [Contrasenia], [Administrador]) VALUES (7, N'LaMagica', N'cumbia420', 0)
INSERT [dbo].[Usuario] ([ID_Usuario], [NombreUsuario], [Contrasenia], [Administrador]) VALUES (14, N'Fefe', N'fefe22', 0)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Usuario] FOREIGN KEY([ID_Usuario])
REFERENCES [dbo].[Usuario] ([ID_Usuario])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Usuario]
GO
ALTER TABLE [dbo].[Comercio]  WITH CHECK ADD  CONSTRAINT [FK_Comercio_Usuario] FOREIGN KEY([ID_Usuario])
REFERENCES [dbo].[Usuario] ([ID_Usuario])
GO
ALTER TABLE [dbo].[Comercio] CHECK CONSTRAINT [FK_Comercio_Usuario]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Comercio] FOREIGN KEY([ID_Comercio])
REFERENCES [dbo].[Comercio] ([ID_Comercio])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Comercio]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Pago] FOREIGN KEY([ID_Pago])
REFERENCES [dbo].[Pago] ([ID_Pago])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Pago]
GO
ALTER TABLE [dbo].[Grupo]  WITH CHECK ADD  CONSTRAINT [FK_Grupo_Cliente] FOREIGN KEY([ID_Cliente])
REFERENCES [dbo].[Cliente] ([ID_Cliente])
GO
ALTER TABLE [dbo].[Grupo] CHECK CONSTRAINT [FK_Grupo_Cliente]
GO
ALTER TABLE [dbo].[Novedad]  WITH CHECK ADD  CONSTRAINT [FK_Novedades_Comercio] FOREIGN KEY([ID_Comercio])
REFERENCES [dbo].[Comercio] ([ID_Comercio])
GO
ALTER TABLE [dbo].[Novedad] CHECK CONSTRAINT [FK_Novedades_Comercio]
GO
ALTER TABLE [dbo].[Pago]  WITH CHECK ADD  CONSTRAINT [FK_Pago_Comercio] FOREIGN KEY([ID_Comercio])
REFERENCES [dbo].[Comercio] ([ID_Comercio])
GO
ALTER TABLE [dbo].[Pago] CHECK CONSTRAINT [FK_Pago_Comercio]
GO
ALTER TABLE [dbo].[Presupuesto]  WITH CHECK ADD  CONSTRAINT [FK_Presupuesto_Factura] FOREIGN KEY([ID_Factura])
REFERENCES [dbo].[Factura] ([ID_Factura])
GO
ALTER TABLE [dbo].[Presupuesto] CHECK CONSTRAINT [FK_Presupuesto_Factura]
GO
ALTER TABLE [dbo].[Publicidad]  WITH CHECK ADD  CONSTRAINT [FK_Publicidad_Comercio] FOREIGN KEY([ID_Comercio])
REFERENCES [dbo].[Comercio] ([ID_Comercio])
GO
ALTER TABLE [dbo].[Publicidad] CHECK CONSTRAINT [FK_Publicidad_Comercio]
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
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Cliente] FOREIGN KEY([ID_Cliente])
REFERENCES [dbo].[Cliente] ([ID_Cliente])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Cliente]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Comercio] FOREIGN KEY([ID_Comercio])
REFERENCES [dbo].[Comercio] ([ID_Comercio])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Comercio]
GO
USE [master]
GO
ALTER DATABASE [DondeSalimos] SET  READ_WRITE 
GO
