USE [master]
GO
/****** Object:  Database [Webwinkel]    Script Date: 5/31/2017 7:45:10 PM ******/
CREATE DATABASE [Webwinkel]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Webwinkel', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Webwinkel.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Webwinkel_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\Webwinkel_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Webwinkel] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Webwinkel].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Webwinkel] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Webwinkel] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Webwinkel] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Webwinkel] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Webwinkel] SET ARITHABORT OFF 
GO
ALTER DATABASE [Webwinkel] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Webwinkel] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Webwinkel] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Webwinkel] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Webwinkel] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Webwinkel] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Webwinkel] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Webwinkel] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Webwinkel] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Webwinkel] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Webwinkel] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Webwinkel] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Webwinkel] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Webwinkel] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Webwinkel] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Webwinkel] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Webwinkel] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Webwinkel] SET RECOVERY FULL 
GO
ALTER DATABASE [Webwinkel] SET  MULTI_USER 
GO
ALTER DATABASE [Webwinkel] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Webwinkel] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Webwinkel] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Webwinkel] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Webwinkel] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Webwinkel] SET QUERY_STORE = OFF
GO
USE [Webwinkel]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Webwinkel]
GO
/****** Object:  UserDefinedTableType [dbo].[ProductRow]    Script Date: 5/31/2017 7:45:10 PM ******/
CREATE TYPE [dbo].[ProductRow] AS TABLE(
	[orderId] [int] NULL,
	[productId] [int] NULL,
	[aantal] [int] NULL
)
GO
/****** Object:  Table [dbo].[Afbeelding]    Script Date: 5/31/2017 7:45:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Afbeelding](
	[id] [int] NOT NULL,
	[image] [image] NULL,
	[naam] [varchar](50) NULL,
 CONSTRAINT [PK_Afbeelding] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gebruiker]    Script Date: 5/31/2017 7:45:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gebruiker](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](50) NULL,
	[wachtwoord] [varchar](50) NULL,
	[voornaam] [varchar](50) NULL,
	[achternaam] [varchar](50) NULL,
	[isAdmin] [int] NULL,
	[straat] [varchar](50) NULL,
	[huisnummer] [varchar](50) NULL,
	[postcode] [varchar](50) NULL,
	[land] [varchar](50) NULL,
	[woonplaats] [varchar](50) NULL,
 CONSTRAINT [PK_Gebruiker] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Korting]    Script Date: 5/31/2017 7:45:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Korting](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[kortingspercentage] [decimal](2, 0) NULL,
	[opmerking] [text] NULL,
	[eindDatum] [date] NULL,
 CONSTRAINT [PK_Korting] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kortingcoupon]    Script Date: 5/31/2017 7:45:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kortingcoupon](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [varchar](50) NULL,
	[kortingspercentage] [int] NULL,
 CONSTRAINT [PK_Kortingcoupon] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Leverancier]    Script Date: 5/31/2017 7:45:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Leverancier](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[naam] [varchar](50) NULL,
	[straat] [varchar](50) NULL,
	[huisnummer] [varchar](50) NULL,
	[postcode] [varchar](50) NULL,
	[land] [varchar](50) NULL,
	[plaats] [varchar](50) NULL,
	[telefoonnummer] [varchar](50) NULL,
	[email] [varchar](50) NULL,
 CONSTRAINT [PK_Leverancier] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 5/31/2017 7:45:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[datum] [date] NULL,
	[gebruikerId] [int] NULL,
	[kortingcouponId] [int] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Product]    Script Date: 5/31/2017 7:45:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Product](
	[orderId] [int] NULL,
	[productId] [int] NULL,
	[aantal] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 5/31/2017 7:45:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[titel] [varchar](255) NOT NULL,
	[omschrijving] [text] NOT NULL,
	[voorraad] [int] NOT NULL,
	[prijs] [decimal](10, 2) NOT NULL,
	[kortingId] [int] NULL,
	[leverancierId] [int] NOT NULL,
	[productcategorieId] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Afbeelding]    Script Date: 5/31/2017 7:45:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Afbeelding](
	[productId] [int] NULL,
	[afbeeldingId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productcategorie]    Script Date: 5/31/2017 7:45:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productcategorie](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[hoofdCategorieID] [int] NULL,
	[naam] [varchar](50) NULL,
	[omschrijving] [varchar](50) NULL,
 CONSTRAINT [PK_Productcategorie] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recensie]    Script Date: 5/31/2017 7:45:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recensie](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[opmerking] [text] NULL,
	[tevreden] [int] NULL,
	[score] [int] NULL,
	[gebruikerId] [int] NULL,
	[productId] [int] NULL,
 CONSTRAINT [PK_Recensie] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Gebruiker] FOREIGN KEY([gebruikerId])
REFERENCES [dbo].[Gebruiker] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Gebruiker]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Kortingcoupon] FOREIGN KEY([kortingcouponId])
REFERENCES [dbo].[Kortingcoupon] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Kortingcoupon]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Productcategorie] FOREIGN KEY([productcategorieId])
REFERENCES [dbo].[Productcategorie] ([id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Productcategorie]
GO
ALTER TABLE [dbo].[Product_Afbeelding]  WITH CHECK ADD  CONSTRAINT [FK_Product_Afbeelding_Afbeelding] FOREIGN KEY([afbeeldingId])
REFERENCES [dbo].[Afbeelding] ([id])
GO
ALTER TABLE [dbo].[Product_Afbeelding] CHECK CONSTRAINT [FK_Product_Afbeelding_Afbeelding]
GO
ALTER TABLE [dbo].[Product_Afbeelding]  WITH CHECK ADD  CONSTRAINT [FK_Product_Afbeelding_Product] FOREIGN KEY([productId])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[Product_Afbeelding] CHECK CONSTRAINT [FK_Product_Afbeelding_Product]
GO
ALTER TABLE [dbo].[Productcategorie]  WITH CHECK ADD  CONSTRAINT [FK_Productcategorie_Productcategorie] FOREIGN KEY([hoofdCategorieID])
REFERENCES [dbo].[Productcategorie] ([id])
GO
ALTER TABLE [dbo].[Productcategorie] CHECK CONSTRAINT [FK_Productcategorie_Productcategorie]
GO
ALTER TABLE [dbo].[Recensie]  WITH CHECK ADD  CONSTRAINT [FK_Recensie_Gebruiker] FOREIGN KEY([gebruikerId])
REFERENCES [dbo].[Gebruiker] ([id])
GO
ALTER TABLE [dbo].[Recensie] CHECK CONSTRAINT [FK_Recensie_Gebruiker]
GO
ALTER TABLE [dbo].[Recensie]  WITH CHECK ADD  CONSTRAINT [FK_Recensie_Product] FOREIGN KEY([productId])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[Recensie] CHECK CONSTRAINT [FK_Recensie_Product]
GO
/****** Object:  StoredProcedure [dbo].[InsertOrder]    Script Date: 5/31/2017 7:45:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[InsertOrder]
(@ProductRows AS dbo.ProductRow READONLY, @Datum as Date, @gebruikerId as Int, @kortingcouponId as Int)
AS
BEGIN
-- Maak het order aan
INSERT INTO dbo.[Order] (datum, gebruikerId, kortingcouponId) VALUES (@Datum, @gebruikerId, @kortingcouponId)
 
--Haal id op van nieuwe order
DECLARE @OrderId int
set @OrderId = SCOPE_IDENTITY()
 
-- Maak de koppeling tussen product en order
INSERT INTO Order_Product (orderId, productId, aantal) select @OrderId, pr.orderId, pr.aantal from @ProductRows pr
END
GO
USE [master]
GO
ALTER DATABASE [Webwinkel] SET  READ_WRITE 
GO
