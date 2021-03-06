USE [master]
GO
/****** Object:  Database [Seguros]    Script Date: 29/05/2022 10:59:38 ******/
CREATE DATABASE [Seguros]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Seguros', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Seguros.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Seguros_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Seguros_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Seguros] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Seguros].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Seguros] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Seguros] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Seguros] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Seguros] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Seguros] SET ARITHABORT OFF 
GO
ALTER DATABASE [Seguros] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Seguros] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Seguros] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Seguros] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Seguros] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Seguros] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Seguros] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Seguros] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Seguros] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Seguros] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Seguros] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Seguros] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Seguros] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Seguros] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Seguros] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Seguros] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Seguros] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Seguros] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Seguros] SET  MULTI_USER 
GO
ALTER DATABASE [Seguros] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Seguros] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Seguros] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Seguros] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Seguros] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Seguros] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Seguros] SET QUERY_STORE = OFF
GO
USE [Seguros]
GO
/****** Object:  Table [dbo].[Asegurados]    Script Date: 29/05/2022 10:59:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asegurados](
	[IdPersona] [int] IDENTITY(1,1) NOT NULL,
	[Cedula] [varchar](10) NOT NULL,
	[NombrePersona] [varchar](100) NOT NULL,
	[Telefono] [varchar](10) NOT NULL,
	[Edad] [int] NOT NULL,
 CONSTRAINT [PK_Asegurados] PRIMARY KEY CLUSTERED 
(
	[IdPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seguro]    Script Date: 29/05/2022 10:59:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seguro](
	[CodigoSeguro] [int] IDENTITY(1,1) NOT NULL,
	[NombreSeguro] [varchar](100) NOT NULL,
	[Prima] [varchar](100) NOT NULL,
	[SumaAseguradora] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Seguro] PRIMARY KEY CLUSTERED 
(
	[CodigoSeguro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seguro_Persona]    Script Date: 29/05/2022 10:59:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seguro_Persona](
	[IdSeguroPersona] [int] IDENTITY(1,1) NOT NULL,
	[CodigoSeguro] [int] NOT NULL,
	[IdPersona] [int] NOT NULL,
 CONSTRAINT [PK_Seguro_Persona] PRIMARY KEY CLUSTERED 
(
	[IdSeguroPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Asegurados] ON 

INSERT [dbo].[Asegurados] ([IdPersona], [Cedula], [NombrePersona], [Telefono], [Edad]) VALUES (1, N'0940426984', N'AnthonyAlvarez', N'0979922402', 24)
INSERT [dbo].[Asegurados] ([IdPersona], [Cedula], [NombrePersona], [Telefono], [Edad]) VALUES (2, N'0940426984', N'AnthonyAlvarez', N'0979922402', 24)
INSERT [dbo].[Asegurados] ([IdPersona], [Cedula], [NombrePersona], [Telefono], [Edad]) VALUES (3, N'0921458963', N'AnthonyBenites', N'0979922402', 30)
INSERT [dbo].[Asegurados] ([IdPersona], [Cedula], [NombrePersona], [Telefono], [Edad]) VALUES (4, N'0940426984', N'AnthonyAlvarez', N'0979922402', 24)
INSERT [dbo].[Asegurados] ([IdPersona], [Cedula], [NombrePersona], [Telefono], [Edad]) VALUES (5, N'0921458963', N'AnthonyBenites', N'0979922402', 30)
INSERT [dbo].[Asegurados] ([IdPersona], [Cedula], [NombrePersona], [Telefono], [Edad]) VALUES (6, N'0940426984', N'AnthonyAlvarez', N'0979922402', 24)
INSERT [dbo].[Asegurados] ([IdPersona], [Cedula], [NombrePersona], [Telefono], [Edad]) VALUES (7, N'0921458963', N'AnthonyBenites', N'0979922402', 30)
INSERT [dbo].[Asegurados] ([IdPersona], [Cedula], [NombrePersona], [Telefono], [Edad]) VALUES (8, N'0940426984', N'JoseAlvarez', N'0979922402', 50)
INSERT [dbo].[Asegurados] ([IdPersona], [Cedula], [NombrePersona], [Telefono], [Edad]) VALUES (9, N'0940426984', N'JoseAlvarez', N'0979922402', 50)
INSERT [dbo].[Asegurados] ([IdPersona], [Cedula], [NombrePersona], [Telefono], [Edad]) VALUES (10, N'0940426984', N'EstherBenites', N'0979922402', 50)
INSERT [dbo].[Asegurados] ([IdPersona], [Cedula], [NombrePersona], [Telefono], [Edad]) VALUES (11, N'0940426984', N'EstherBenites', N'0979922402', 50)
INSERT [dbo].[Asegurados] ([IdPersona], [Cedula], [NombrePersona], [Telefono], [Edad]) VALUES (12, N'0940426984', N'EstherBenites', N'0979922402', 50)
SET IDENTITY_INSERT [dbo].[Asegurados] OFF
GO
SET IDENTITY_INSERT [dbo].[Seguro] ON 

INSERT [dbo].[Seguro] ([CodigoSeguro], [NombreSeguro], [Prima], [SumaAseguradora]) VALUES (2, N'Condor', N'60', N'50')
INSERT [dbo].[Seguro] ([CodigoSeguro], [NombreSeguro], [Prima], [SumaAseguradora]) VALUES (3, N'Seguros S', N'50', N'50')
SET IDENTITY_INSERT [dbo].[Seguro] OFF
GO
SET IDENTITY_INSERT [dbo].[Seguro_Persona] ON 

INSERT [dbo].[Seguro_Persona] ([IdSeguroPersona], [CodigoSeguro], [IdPersona]) VALUES (1, 2, 1)
INSERT [dbo].[Seguro_Persona] ([IdSeguroPersona], [CodigoSeguro], [IdPersona]) VALUES (2, 2, 3)
INSERT [dbo].[Seguro_Persona] ([IdSeguroPersona], [CodigoSeguro], [IdPersona]) VALUES (3, 3, 3)
INSERT [dbo].[Seguro_Persona] ([IdSeguroPersona], [CodigoSeguro], [IdPersona]) VALUES (6, 2, 10)
INSERT [dbo].[Seguro_Persona] ([IdSeguroPersona], [CodigoSeguro], [IdPersona]) VALUES (7, 3, 10)
INSERT [dbo].[Seguro_Persona] ([IdSeguroPersona], [CodigoSeguro], [IdPersona]) VALUES (9, 2, 12)
INSERT [dbo].[Seguro_Persona] ([IdSeguroPersona], [CodigoSeguro], [IdPersona]) VALUES (10, 3, 12)
INSERT [dbo].[Seguro_Persona] ([IdSeguroPersona], [CodigoSeguro], [IdPersona]) VALUES (12, 2, 4)
SET IDENTITY_INSERT [dbo].[Seguro_Persona] OFF
GO
ALTER TABLE [dbo].[Seguro_Persona]  WITH CHECK ADD FOREIGN KEY([CodigoSeguro])
REFERENCES [dbo].[Seguro] ([CodigoSeguro])
GO
ALTER TABLE [dbo].[Seguro_Persona]  WITH CHECK ADD FOREIGN KEY([IdPersona])
REFERENCES [dbo].[Asegurados] ([IdPersona])
GO
USE [master]
GO
ALTER DATABASE [Seguros] SET  READ_WRITE 
GO
