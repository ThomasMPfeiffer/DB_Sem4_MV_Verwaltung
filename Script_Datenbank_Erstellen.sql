USE [master]
GO
/****** Object:  Database [MV_Mitgliederverwaltung]    Script Date: 23.05.2021 13:06:23 ******/
CREATE DATABASE [MV_Mitgliederverwaltung]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MV_Mitgliederverwaltung', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MV_VERWALTUNG\MSSQL\DATA\MV_Mitgliederverwaltung.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MV_Mitgliederverwaltung_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MV_VERWALTUNG\MSSQL\DATA\MV_Mitgliederverwaltung_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MV_Mitgliederverwaltung] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MV_Mitgliederverwaltung].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MV_Mitgliederverwaltung] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MV_Mitgliederverwaltung] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MV_Mitgliederverwaltung] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MV_Mitgliederverwaltung] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MV_Mitgliederverwaltung] SET ARITHABORT OFF 
GO
ALTER DATABASE [MV_Mitgliederverwaltung] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MV_Mitgliederverwaltung] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MV_Mitgliederverwaltung] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MV_Mitgliederverwaltung] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MV_Mitgliederverwaltung] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MV_Mitgliederverwaltung] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MV_Mitgliederverwaltung] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MV_Mitgliederverwaltung] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MV_Mitgliederverwaltung] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MV_Mitgliederverwaltung] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MV_Mitgliederverwaltung] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MV_Mitgliederverwaltung] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MV_Mitgliederverwaltung] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MV_Mitgliederverwaltung] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MV_Mitgliederverwaltung] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MV_Mitgliederverwaltung] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MV_Mitgliederverwaltung] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MV_Mitgliederverwaltung] SET RECOVERY FULL 
GO
ALTER DATABASE [MV_Mitgliederverwaltung] SET  MULTI_USER 
GO
ALTER DATABASE [MV_Mitgliederverwaltung] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MV_Mitgliederverwaltung] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MV_Mitgliederverwaltung] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MV_Mitgliederverwaltung] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MV_Mitgliederverwaltung] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MV_Mitgliederverwaltung] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MV_Mitgliederverwaltung', N'ON'
GO
ALTER DATABASE [MV_Mitgliederverwaltung] SET QUERY_STORE = OFF
GO
USE [MV_Mitgliederverwaltung]
GO
/****** Object:  Table [dbo].[Admin__Connector_Sparte_PW]    Script Date: 23.05.2021 13:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin__Connector_Sparte_PW](
	[Connector_Sparte_Verein_ID] [int] NOT NULL,
	[Admin] [bit] NOT NULL,
	[PasswordID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Connector_Instr_Mitgl_Connector_Stimme]    Script Date: 23.05.2021 13:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Connector_Instr_Mitgl_Connector_Stimme](
	[StimmeID] [int] NULL,
	[IDInstr_Mitgl_Connector] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Connector_Mitglied_Instr_Stimme]    Script Date: 23.05.2021 13:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Connector_Mitglied_Instr_Stimme](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IntsrumentID] [int] NOT NULL,
	[MitgliedID] [int] NOT NULL,
	[Satzführer] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL,
 CONSTRAINT [PK_Connector_Mitglied->Instr&Stimme] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Connector_Mitglied_Sparte]    Script Date: 23.05.2021 13:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Connector_Mitglied_Sparte](
	[MitgliedID] [int] NOT NULL,
	[Connector_Sparte_Verein_ID] [int] NOT NULL,
	[Aktiv] [bit] NOT NULL,
	[Deleted] [bit] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Connector_Sparte_Verein]    Script Date: 23.05.2021 13:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Connector_Sparte_Verein](
	[VereinID] [int] NOT NULL,
	[SparteID] [int] NOT NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Connector_Sparte_Verein] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Instrument]    Script Date: 23.05.2021 13:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Instrument](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Instrument] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Instrument] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mitglied]    Script Date: 23.05.2021 13:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mitglied](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nachname] [nvarchar](50) NOT NULL,
	[Vorname] [nvarchar](50) NOT NULL,
	[Straße] [nvarchar](50) NULL,
	[Hausnummer] [smallint] NULL,
	[WohnortID] [int] NULL,
	[PWID] [int] NULL,
	[Mitglied_seit] [date] NULL,
	[Geb_Datum] [date] NULL,
	[Telefon] [nvarchar](50) NULL,
	[Mobil] [nvarchar](50) NULL,
	[E_Mail] [nvarchar](50) NULL,
	[Mail_Eltern] [nvarchar](50) NULL,
	[Mobil_Eltern] [nvarchar](50) NULL,
 CONSTRAINT [PK_Mitglied1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Password]    Script Date: 23.05.2021 13:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Password](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Password] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_Password] UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sparte]    Script Date: 23.05.2021 13:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sparte](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Sparte] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Sparte] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_Sparte] UNIQUE NONCLUSTERED 
(
	[Sparte] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stimme]    Script Date: 23.05.2021 13:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stimme](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Stimme] [int] NOT NULL,
 CONSTRAINT [PK_Stimme] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Verein]    Script Date: 23.05.2021 13:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Verein](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Verein] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Verein] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_Verein] UNIQUE NONCLUSTERED 
(
	[Verein] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wohnort]    Script Date: 23.05.2021 13:06:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wohnort](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Wohnort] [nvarchar](50) NOT NULL,
	[PLZ] [int] NOT NULL,
 CONSTRAINT [PK_Wohnort] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [IX_Wohnort] UNIQUE NONCLUSTERED 
(
	[Wohnort] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Admin__Connector_Sparte_PW]  WITH CHECK ADD  CONSTRAINT [FK_Admin__Connector_Sparte_PW_Connector_Sparte_Verein] FOREIGN KEY([Connector_Sparte_Verein_ID])
REFERENCES [dbo].[Connector_Sparte_Verein] ([ID])
GO
ALTER TABLE [dbo].[Admin__Connector_Sparte_PW] CHECK CONSTRAINT [FK_Admin__Connector_Sparte_PW_Connector_Sparte_Verein]
GO
ALTER TABLE [dbo].[Admin__Connector_Sparte_PW]  WITH CHECK ADD  CONSTRAINT [FK_Admin__Connector_Sparte_PW_Password] FOREIGN KEY([PasswordID])
REFERENCES [dbo].[Password] ([ID])
GO
ALTER TABLE [dbo].[Admin__Connector_Sparte_PW] CHECK CONSTRAINT [FK_Admin__Connector_Sparte_PW_Password]
GO
ALTER TABLE [dbo].[Connector_Instr_Mitgl_Connector_Stimme]  WITH CHECK ADD  CONSTRAINT [FK_Connector_Instr_Mitgl_Connector_Stimme_Connector_Mitglied_Instr_Stimme] FOREIGN KEY([IDInstr_Mitgl_Connector])
REFERENCES [dbo].[Connector_Mitglied_Instr_Stimme] ([ID])
GO
ALTER TABLE [dbo].[Connector_Instr_Mitgl_Connector_Stimme] CHECK CONSTRAINT [FK_Connector_Instr_Mitgl_Connector_Stimme_Connector_Mitglied_Instr_Stimme]
GO
ALTER TABLE [dbo].[Connector_Instr_Mitgl_Connector_Stimme]  WITH CHECK ADD  CONSTRAINT [FK_Connector_Instr_Mitgl_Connector_Stimme_Stimme] FOREIGN KEY([StimmeID])
REFERENCES [dbo].[Stimme] ([ID])
GO
ALTER TABLE [dbo].[Connector_Instr_Mitgl_Connector_Stimme] CHECK CONSTRAINT [FK_Connector_Instr_Mitgl_Connector_Stimme_Stimme]
GO
ALTER TABLE [dbo].[Connector_Mitglied_Instr_Stimme]  WITH CHECK ADD  CONSTRAINT [FK_Connector_Mitglied_Instr_Stimme_Instrument] FOREIGN KEY([IntsrumentID])
REFERENCES [dbo].[Instrument] ([ID])
GO
ALTER TABLE [dbo].[Connector_Mitglied_Instr_Stimme] CHECK CONSTRAINT [FK_Connector_Mitglied_Instr_Stimme_Instrument]
GO
ALTER TABLE [dbo].[Connector_Mitglied_Instr_Stimme]  WITH CHECK ADD  CONSTRAINT [FK_Connector_Mitglied_Instr_Stimme_Mitglied] FOREIGN KEY([MitgliedID])
REFERENCES [dbo].[Mitglied] ([ID])
GO
ALTER TABLE [dbo].[Connector_Mitglied_Instr_Stimme] CHECK CONSTRAINT [FK_Connector_Mitglied_Instr_Stimme_Mitglied]
GO
ALTER TABLE [dbo].[Connector_Mitglied_Sparte]  WITH CHECK ADD  CONSTRAINT [FK_Connector_Mitglied_Sparte_Mitglied] FOREIGN KEY([MitgliedID])
REFERENCES [dbo].[Mitglied] ([ID])
GO
ALTER TABLE [dbo].[Connector_Mitglied_Sparte] CHECK CONSTRAINT [FK_Connector_Mitglied_Sparte_Mitglied]
GO
ALTER TABLE [dbo].[Connector_Mitglied_Sparte]  WITH CHECK ADD  CONSTRAINT [FK_Connector_Mitglied_Sparte_Sparte] FOREIGN KEY([Connector_Sparte_Verein_ID])
REFERENCES [dbo].[Connector_Sparte_Verein] ([ID])
GO
ALTER TABLE [dbo].[Connector_Mitglied_Sparte] CHECK CONSTRAINT [FK_Connector_Mitglied_Sparte_Sparte]
GO
ALTER TABLE [dbo].[Connector_Sparte_Verein]  WITH CHECK ADD  CONSTRAINT [FK_Connector_Sparte_Verein_Sparte] FOREIGN KEY([SparteID])
REFERENCES [dbo].[Sparte] ([ID])
GO
ALTER TABLE [dbo].[Connector_Sparte_Verein] CHECK CONSTRAINT [FK_Connector_Sparte_Verein_Sparte]
GO
ALTER TABLE [dbo].[Connector_Sparte_Verein]  WITH CHECK ADD  CONSTRAINT [FK_Connector_Sparte_Verein_Verein] FOREIGN KEY([VereinID])
REFERENCES [dbo].[Verein] ([ID])
GO
ALTER TABLE [dbo].[Connector_Sparte_Verein] CHECK CONSTRAINT [FK_Connector_Sparte_Verein_Verein]
GO
ALTER TABLE [dbo].[Mitglied]  WITH CHECK ADD  CONSTRAINT [FK_Mitglied_Password] FOREIGN KEY([PWID])
REFERENCES [dbo].[Password] ([ID])
GO
ALTER TABLE [dbo].[Mitglied] CHECK CONSTRAINT [FK_Mitglied_Password]
GO
ALTER TABLE [dbo].[Mitglied]  WITH CHECK ADD  CONSTRAINT [FK_Mitglied_Wohnort] FOREIGN KEY([WohnortID])
REFERENCES [dbo].[Wohnort] ([ID])
GO
ALTER TABLE [dbo].[Mitglied] CHECK CONSTRAINT [FK_Mitglied_Wohnort]
GO
USE [master]
GO
ALTER DATABASE [MV_Mitgliederverwaltung] SET  READ_WRITE 
GO
