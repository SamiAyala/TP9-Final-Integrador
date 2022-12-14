USE [master]
GO
/****** Object:  Database [BD]    Script Date: 1/12/2022 10:53:09 ******/
CREATE DATABASE [BD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BD', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\BD.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BD_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\BD_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BD] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BD] SET ARITHABORT OFF 
GO
ALTER DATABASE [BD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BD] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BD] SET RECOVERY FULL 
GO
ALTER DATABASE [BD] SET  MULTI_USER 
GO
ALTER DATABASE [BD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BD] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BD] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BD', N'ON'
GO
ALTER DATABASE [BD] SET QUERY_STORE = OFF
GO
USE [BD]
GO
/****** Object:  User [alumno]    Script Date: 1/12/2022 10:53:09 ******/
CREATE USER [alumno] FOR LOGIN [alumno] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Archivo]    Script Date: 1/12/2022 10:53:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Archivo](
	[IdArchivo] [int] IDENTITY(1,1) NOT NULL,
	[IdPost] [int] NOT NULL,
	[Path] [varchar](50) NOT NULL,
	[Tipo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Archivo] PRIMARY KEY CLUSTERED 
(
	[IdArchivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Board]    Script Date: 1/12/2022 10:53:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Board](
	[IdBoard] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[cantMaximaPosts] [int] NOT NULL,
 CONSTRAINT [PK_Board] PRIMARY KEY CLUSTERED 
(
	[IdBoard] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 1/12/2022 10:53:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[IdPost] [int] IDENTITY(1,1) NOT NULL,
	[IdBoard] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Imagen] [varchar](500) NULL,
	[Descripcion] [text] NULL,
	[FechaCreacion] [date] NOT NULL,
	[Titulo] [varchar](50) NULL,
	[fkPost] [int] NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[IdPost] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 1/12/2022 10:53:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[contraseña] [varchar](64) NOT NULL,
	[Moderador] [bit] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Board] ON 

INSERT [dbo].[Board] ([IdBoard], [Nombre], [cantMaximaPosts]) VALUES (1, N'Videojuegos', 15)
INSERT [dbo].[Board] ([IdBoard], [Nombre], [cantMaximaPosts]) VALUES (2, N'Autos', 15)
INSERT [dbo].[Board] ([IdBoard], [Nombre], [cantMaximaPosts]) VALUES (3, N'Anime', 30)
INSERT [dbo].[Board] ([IdBoard], [Nombre], [cantMaximaPosts]) VALUES (4, N'Tecnologia', 25)
INSERT [dbo].[Board] ([IdBoard], [Nombre], [cantMaximaPosts]) VALUES (5, N'TVyCine', 15)
SET IDENTITY_INSERT [dbo].[Board] OFF
GO
SET IDENTITY_INSERT [dbo].[Post] ON 

INSERT [dbo].[Post] ([IdPost], [IdBoard], [IdUsuario], [Imagen], [Descripcion], [FechaCreacion], [Titulo], [fkPost]) VALUES (2, 1, 1, N'https://static.wikia.nocookie.net/leagueoflegendsoficial/images/8/8c/LOL_Logo.png/revision/latest?cb=20180119195439&path-prefix=es', N'cambios en los objetos', CAST(N'2022-10-06' AS Date), N'LoL', NULL)
INSERT [dbo].[Post] ([IdPost], [IdBoard], [IdUsuario], [Imagen], [Descripcion], [FechaCreacion], [Titulo], [fkPost]) VALUES (3, 1, 1, NULL, N'hola!!', CAST(N'2022-11-07' AS Date), N'HODA', 2)
INSERT [dbo].[Post] ([IdPost], [IdBoard], [IdUsuario], [Imagen], [Descripcion], [FechaCreacion], [Titulo], [fkPost]) VALUES (4, 1, 5, NULL, N'sisi', CAST(N'2022-11-10' AS Date), N'Me gusta el minecraft', NULL)
INSERT [dbo].[Post] ([IdPost], [IdBoard], [IdUsuario], [Imagen], [Descripcion], [FechaCreacion], [Titulo], [fkPost]) VALUES (5, 1, 5, NULL, N'>:(', CAST(N'2022-11-10' AS Date), N'ODIO EL MINECRAFT', 4)
INSERT [dbo].[Post] ([IdPost], [IdBoard], [IdUsuario], [Imagen], [Descripcion], [FechaCreacion], [Titulo], [fkPost]) VALUES (7, 1, 1, NULL, N'fwefwefwef', CAST(N'2022-11-27' AS Date), N'cefwefwef', NULL)
INSERT [dbo].[Post] ([IdPost], [IdBoard], [IdUsuario], [Imagen], [Descripcion], [FechaCreacion], [Titulo], [fkPost]) VALUES (8, 1, 1, NULL, N'qwdqwdqwdqwdqw', CAST(N'2022-11-27' AS Date), N'dqwdqwd', NULL)
SET IDENTITY_INSERT [dbo].[Post] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([IdUsuario], [Nombre], [contraseña], [Moderador]) VALUES (1, N'Anonymous', N'123', 0)
INSERT [dbo].[Usuario] ([IdUsuario], [Nombre], [contraseña], [Moderador]) VALUES (5, N'santiPoff', N'796e43a5a8cdb73b92b5f59eb50610cea3efa8ce229cd7f0557983091b2b4552', 0)
INSERT [dbo].[Usuario] ([IdUsuario], [Nombre], [contraseña], [Moderador]) VALUES (16, N'321', N'd4735e3a265e16eee03f59718b9b5d03019c07d8b6c51f90da3a666eec13ab35', 0)
INSERT [dbo].[Usuario] ([IdUsuario], [Nombre], [contraseña], [Moderador]) VALUES (17, N'Samir Ayala', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1)
INSERT [dbo].[Usuario] ([IdUsuario], [Nombre], [contraseña], [Moderador]) VALUES (18, N'Nacho Lopez', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 1)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[Archivo]  WITH CHECK ADD  CONSTRAINT [FK_Archivo_Post] FOREIGN KEY([IdPost])
REFERENCES [dbo].[Post] ([IdPost])
GO
ALTER TABLE [dbo].[Archivo] CHECK CONSTRAINT [FK_Archivo_Post]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_Board] FOREIGN KEY([IdBoard])
REFERENCES [dbo].[Board] ([IdBoard])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post_Board]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_Post] FOREIGN KEY([fkPost])
REFERENCES [dbo].[Post] ([IdPost])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post_Post]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post_Usuario]
GO
USE [master]
GO
ALTER DATABASE [BD] SET  READ_WRITE 
GO
