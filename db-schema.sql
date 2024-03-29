USE [master]
GO
/****** Object:  Database [PhotographyAutomationDB]    Script Date: 9/30/2019 9:28:40 PM ******/
CREATE DATABASE [PhotographyAutomationDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PhotographyAutomationDB', FILENAME = N'C:\SQL-2017\Data\PhotographyAutomationDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB ), 
 FILEGROUP [PhotoArchive_FG1] CONTAINS FILESTREAM  DEFAULT
( NAME = N'PhotoArchive_1', FILENAME = N'c:\PhotographyAutomation_FileStores\PhotoArchive_1' , MAXSIZE = UNLIMITED)
 LOG ON 
( NAME = N'PhotographyAutomationDB_log', FILENAME = N'C:\SQL-2017\Data\PhotographyAutomationDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [PhotographyAutomationDB] ADD FILEGROUP [PhotosFileGroup]
GO
ALTER DATABASE [PhotographyAutomationDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PhotographyAutomationDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PhotographyAutomationDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PhotographyAutomationDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PhotographyAutomationDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PhotographyAutomationDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PhotographyAutomationDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PhotographyAutomationDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PhotographyAutomationDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PhotographyAutomationDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PhotographyAutomationDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PhotographyAutomationDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PhotographyAutomationDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PhotographyAutomationDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PhotographyAutomationDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PhotographyAutomationDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PhotographyAutomationDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PhotographyAutomationDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PhotographyAutomationDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PhotographyAutomationDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PhotographyAutomationDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PhotographyAutomationDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PhotographyAutomationDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PhotographyAutomationDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PhotographyAutomationDB] SET RECOVERY FULL 
GO
ALTER DATABASE [PhotographyAutomationDB] SET  MULTI_USER 
GO
ALTER DATABASE [PhotographyAutomationDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PhotographyAutomationDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PhotographyAutomationDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = FULL, DIRECTORY_NAME = N'PhotographyAutomation_FileStores' ) 
GO
ALTER DATABASE [PhotographyAutomationDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PhotographyAutomationDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PhotographyAutomationDB', N'ON'
GO
USE [PhotographyAutomationDB]
GO
/****** Object:  Table [dbo].[Photos]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ARITHABORT ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Photos] AS FILETABLE ON [PRIMARY] FILESTREAM_ON [PhotoArchive_FG1]
WITH
(
FILETABLE_DIRECTORY = N'Documents', FILETABLE_COLLATE_FILENAME = Persian_100_CI_AI
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblAlbums]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblAlbums](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PrintSizeId] [int] NOT NULL,
	[AlbumName] [nvarchar](50) NOT NULL,
	[TotalPages] [int] NOT NULL,
	[CoverTypeName] [nvarchar](50) NOT NULL,
	[Color] [nvarchar](50) NOT NULL,
	[Price] [int] NOT NULL,
	[Code] [varchar](50) NULL,
	[ManufacturerId] [int] NULL,
 CONSTRAINT [PK_TblAlbums] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblAllOrderStatus]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblAllOrderStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[OrderPrintId] [int] NOT NULL,
	[StatusCode] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[ModifiedDateTime] [datetime] NULL,
 CONSTRAINT [PK_TblAllOrderStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblAtelierType]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblAtelierType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NOT NULL,
	[AtelierName] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_tblAtelierType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblBooking]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblBooking](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[Time] [time](0) NOT NULL,
	[PhotographerGender] [tinyint] NOT NULL,
	[PhotographyTypeId] [int] NOT NULL,
	[AtelierTypeId] [int] NOT NULL,
	[PersonCount] [int] NOT NULL,
	[PrepaymentIsOk] [tinyint] NOT NULL,
	[Submitter] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_tblBooking] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblBookingStatus]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblBookingStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NOT NULL,
	[StatusName] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_tblBookingStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblCustomer]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblCustomer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](200) NULL,
	[LastName] [nvarchar](200) NULL,
	[Gender] [tinyint] NULL,
	[Address] [nvarchar](1000) NULL,
	[Tell] [char](10) NULL,
	[Mobile] [char](10) NULL,
	[Email] [varchar](200) NULL,
	[NationalId] [char](11) NULL,
	[CustomerType] [tinyint] NULL,
	[IsMarried] [tinyint] NULL,
	[BirthDate] [date] NULL,
	[WeddingDate] [date] NULL,
	[IsActive] [tinyint] NULL,
	[IsDeleted] [tinyint] NULL,
	[Submitter] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_tblUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblFilesError]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblFilesError](
	[Id] [int] NOT NULL,
	[FileName] [nvarchar](50) NULL,
	[DateTime] [datetime] NULL,
	[Submitter] [int] NULL,
	[OrderId] [int] NULL,
	[OrderCode] [nvarchar](50) NULL,
	[CustomerId] [int] NULL,
	[BookingId] [int] NULL,
	[ErrorInId] [int] NULL,
	[ErrorMessage] [nvarchar](max) NULL,
 CONSTRAINT [PK_TblFilesError] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblOrder]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblOrder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderCode] [varchar](50) NOT NULL,
	[OrderStatusId] [int] NOT NULL,
	[BookingId] [int] NOT NULL,
	[PhotographyTypeId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[PhotographerId] [int] NULL,
	[PaymentIsOk] [tinyint] NULL,
	[Date] [date] NULL,
	[Time] [time](0) NULL,
	[OrderFolderStreamId] [uniqueidentifier] NULL,
	[OrderFolderPathLocator] [nvarchar](max) NULL,
	[OrderFolderParentPathLocator] [nvarchar](max) NULL,
	[TotalFiles] [int] NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[ModifiedDateTime] [datetime] NULL,
	[Submitter] [int] NULL,
	[UploadDate] [date] NULL,
	[OrderPrintIssued] [bit] NULL,
	[LastOrderPrintCustomerId] [int] NULL,
 CONSTRAINT [PK_TblOrder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblOrderFiles]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblOrderFiles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[StreamId] [uniqueidentifier] NOT NULL,
	[FileName] [nvarchar](255) NOT NULL,
	[PathLocator] [nvarchar](max) NOT NULL,
	[UploadDate] [date] NULL,
 CONSTRAINT [PK_TblOrderStreams] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblOrderPrint]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblOrderPrint](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderPrintCode] [varchar](50) NOT NULL,
	[OrderId] [int] NOT NULL,
	[OrderType] [bit] NULL,
	[OrderPrintStatusId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[RetochDescriptions] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[TotalPhotos] [int] NULL,
	[TotalPriceOriginalPrint] [int] NULL,
	[TotalPriceMultiPhoto] [int] NULL,
	[TotalPriceLitPrint] [int] NULL,
	[TotalPricePrintService] [int] NULL,
	[TotalPriceRePrint] [int] NULL,
	[TotalPriceRePrintMultiPhoto] [int] NULL,
	[TotalPriceRePrintLitPrint] [int] NULL,
	[TotalPrice] [bigint] NULL,
	[Deposit] [bigint] NULL,
	[Payment] [bigint] NULL,
	[Remaining] [bigint] NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[ModifiedDateTime] [datetime] NULL,
 CONSTRAINT [PK_TblOrderPrint] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblOrderPrintChangingElements]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblOrderPrintChangingElements](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderPrintDetailsId] [int] NULL,
	[MainPhotoStreamId] [uniqueidentifier] NULL,
	[StreamId] [uniqueidentifier] NULL,
	[MainPhotoFileName] [nvarchar](255) NULL,
	[FileName] [nvarchar](255) NULL,
	[Description] [nvarchar](1000) NULL,
 CONSTRAINT [PK_TblChangingElements] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblOrderPrintDetails]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblOrderPrintDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderPrintId] [int] NOT NULL,
	[StreamId] [uniqueidentifier] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[FileName] [nvarchar](255) NOT NULL,
	[IsAccepted] [bit] NULL,
	[IsFirstPrint] [bit] NULL,
	[HasPrintService] [bit] NULL,
	[HasMultiPhoto] [bit] NULL,
	[HasLitPrint] [bit] NULL,
	[HasChangingElements] [bit] NULL,
	[PrintSizeId] [int] NULL,
	[PrintSizePriceId] [int] NULL,
	[PrintServiceId] [int] NULL,
	[PrintServicePriceId] [int] NULL,
	[PrintSpecialServiceId] [int] NULL,
	[RePrintSequence] [int] NULL,
	[HasRePrintPrintService] [bit] NULL,
	[HasRePrintMultiPhoto] [bit] NULL,
	[HasRePrintLitPrint] [bit] NULL,
	[HasRePrintChangingElements] [bit] NULL,
	[RePrintPrintSizeId] [int] NULL,
	[RePrintPrintSizePriceId] [int] NULL,
	[RePrintPrintServiceId] [int] NULL,
	[RePrintPrintServicePriceId] [int] NULL,
	[RePrintPrintSpecialServiceId] [int] NULL,
	[RePrintTotalPrints] [int] NULL,
	[RePrintTotalPrintServices] [int] NULL,
	[RetouchDescription] [nvarchar](4000) NULL,
	[TotalPrice] [int] NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[ModifiedDateTime] [datetime] NULL,
 CONSTRAINT [PK_TblOrderPrintDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblOrderPrintFiles]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblOrderPrintFiles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderPrintId] [int] NOT NULL,
	[FileName] [nvarchar](255) NOT NULL,
	[PathLocator] [nvarchar](max) NOT NULL,
	[CollectDate] [date] NULL,
 CONSTRAINT [PK_TblOrderPrintFiles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblOrderPrintLitPrint]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblOrderPrintLitPrint](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderPrintDetailsId] [int] NULL,
	[MainPhotoStreamId] [uniqueidentifier] NULL,
	[StreamId] [uniqueidentifier] NULL,
	[MainPhotoFileName] [nvarchar](255) NULL,
	[FileName] [nvarchar](255) NULL,
	[Description] [nvarchar](1000) NULL,
 CONSTRAINT [PK_TblOrderPrintLitPrint] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblOrderPrintMultiPhotoOrder]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblOrderPrintMultiPhotoOrder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderPrintDetailId] [int] NULL,
	[MainPhotoStreamId] [uniqueidentifier] NULL,
	[StreamId] [uniqueidentifier] NULL,
	[MainPhotoFileName] [nvarchar](255) NULL,
	[FileName] [nvarchar](255) NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_TblMultiPhotoOrder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblOrderPrintStatus]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblOrderPrintStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TblOrderPrintStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblOrderStatus]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblOrderStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TblOrderStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblPhotographyType]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblPhotographyType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NOT NULL,
	[TypeName] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_tblPhotographyType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblPrintCustomerFiles]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblPrintCustomerFiles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PrintSizeId] [int] NOT NULL,
	[Price] [int] NOT NULL,
 CONSTRAINT [PK_TblCustomerFilePrint] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblPrintServicePrices]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblPrintServicePrices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](10) NULL,
	[PrintSizeId] [int] NOT NULL,
	[PrintServiceId] [int] NOT NULL,
	[Price] [int] NOT NULL,
 CONSTRAINT [PK_TblPrintServicePrices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblPrintServices]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblPrintServices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[PrintServiceName] [nvarchar](50) NOT NULL,
	[PrintServiceDescription] [nvarchar](500) NULL,
 CONSTRAINT [PK_TblPrintServices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblPrintSizePrices]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblPrintSizePrices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PrintSizeId] [int] NOT NULL,
	[FirstPrintPrice] [int] NULL,
	[RePrintPrice] [int] NULL,
	[MedicalPrice] [int] NULL,
	[MedicalRePrintPrice] [int] NULL,
	[LitPrintPrice] [int] NULL,
	[LitPrintRePrintPrice] [int] NULL,
	[ScanAndPrintPrice] [int] NULL,
	[ScanAndProcessingPrice] [int] NULL,
	[ItalianAlbumPagePrice] [int] NULL,
	[ItalianAlbumBoundingPrice] [int] NULL,
 CONSTRAINT [PK_TblPrintSizePrices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblPrintSizes]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblPrintSizes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Width] [float] NOT NULL,
	[Height] [float] NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[HasFirstPrint] [bit] NOT NULL,
	[HasRePrint] [bit] NOT NULL,
	[HasMedicalPhoto] [bit] NOT NULL,
	[HasLitPrint] [bit] NOT NULL,
	[HasScanAndProcessing] [bit] NOT NULL,
	[HasAlbum] [bit] NOT NULL,
	[HasItalianAlbum] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[MinimumOrder] [tinyint] NOT NULL,
	[Descriptions] [nvarchar](500) NULL,
 CONSTRAINT [PK_TblPrintSizes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblPrintSpecialServices]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblPrintSpecialServices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Price] [int] NOT NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_TblSpecialServices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[View_GetAllPhotos]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_GetAllPhotos]
AS

SELECT stream_id                AS 'StreamId',
       file_stream              AS 'FileStream',
       [NAME]                   AS 'FileName',
       CAST(path_locator AS VARCHAR(4000)) AS 'PathLocator',
       CAST(parent_path_locator AS VARCHAR(4000)) AS 'ParentPathLocator',
       file_stream.PathName()   AS 'UncPath',
       file_stream.GetFileNamespacePath(0) AS 'RelativePath',
       file_stream.GetFileNamespacePath(1, 2) AS 'FullUncPath',
       path_locator.GetLevel()  AS 'Level',
       file_type                AS 'FileType',
       cached_file_size         AS 'FileSize',
       creation_time            AS 'CreationTime',
       last_write_time          AS 'LastWriteTime',
       last_access_time         AS 'LastAccessTime',
       is_offline               AS 'IsOffline',
       is_hidden                AS 'IsHidden',
       is_readonly              AS 'IsReadonly',
       is_archive               AS 'IsArchive',
       is_system                AS 'IsSystem',
       is_temporary             AS 'IsTemporary'
FROM   PhotographyAutomationDB.dbo.Photos AS p
WHERE  p.is_directory = 0;


GO
/****** Object:  View [dbo].[View_GetAllPrintSizeAndServicesInfo]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_GetAllPrintSizeAndServicesInfo]
AS
SELECT        TOP (100) PERCENT dbo.TblPrintSizes.Id AS PrintSizeId, dbo.TblPrintServices.Id AS PrintServiceId, dbo.TblPrintSizePrices.Id AS PrintSizePriceId, 
                         dbo.TblPrintServicePrices.Id AS PrintServicePriceId, dbo.TblPrintSizes.Name AS PrintSizeName, dbo.TblPrintServices.PrintServiceName, 
                         dbo.TblPrintServicePrices.Price AS PrintServicePrice, dbo.TblPrintSizePrices.FirstPrintPrice, dbo.TblPrintSizePrices.RePrintPrice, 
                         dbo.TblPrintSizes.HasMedicalPhoto, dbo.TblPrintSizePrices.MedicalPrice, dbo.TblPrintSizePrices.MedicalRePrintPrice, dbo.TblPrintSizes.HasLitPrint, 
                         dbo.TblPrintSizePrices.LitPrintPrice, dbo.TblPrintSizePrices.LitPrintRePrintPrice, dbo.TblPrintSizes.HasScanAndProcessing, 
                         dbo.TblPrintSizePrices.ScanAndPrintPrice, dbo.TblPrintSizePrices.ScanAndProcessingPrice, dbo.TblPrintSizes.HasItalianAlbum, 
                         dbo.TblPrintSizePrices.ItalianAlbumPagePrice, dbo.TblPrintSizePrices.ItalianAlbumBoundingPrice, dbo.TblPrintSizes.IsActive, dbo.TblPrintSizes.IsDeleted, 
                         dbo.TblPrintSizes.MinimumOrder, dbo.TblPrintSizes.Width, dbo.TblPrintSizes.Height
FROM            dbo.TblPrintSizePrices RIGHT OUTER JOIN
                         dbo.TblPrintSizes LEFT OUTER JOIN
                         dbo.TblPrintServices INNER JOIN
                         dbo.TblPrintServicePrices ON dbo.TblPrintServices.Id = dbo.TblPrintServicePrices.PrintServiceId ON dbo.TblPrintSizes.Id = dbo.TblPrintServicePrices.PrintSizeId ON 
                         dbo.TblPrintSizePrices.PrintSizeId = dbo.TblPrintSizes.Id

GO
/****** Object:  View [dbo].[View_GetDocumentsFolders]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/************************************************************
 * Code formatted by SoftTree SQL Assistant © v9.1.261
 * Time: 7/21/2019 12:07:57 PM
 ************************************************************/
CREATE VIEW [dbo].[View_GetDocumentsFolders]
AS

SELECT stream_id                AS StreamId,
       file_stream              AS FileStream,
       NAME                     AS FolderName,
       CAST(path_locator AS VARCHAR(4000)) AS PathLocator,
       CAST(parent_path_locator AS VARCHAR(4000)) AS ParentPathLocator,
       file_stream.PathName()   AS UncPath,
       file_stream.GetFileNamespacePath(0) AS RelativePath,
       file_stream.GetFileNamespacePath(1, 2) AS FullUncPath,
       path_locator.GetLevel()  AS [Level],
       file_type                AS FileType,
       cached_file_size         AS FileSize,
       creation_time            AS CreationTime,
       last_write_time          AS LastWriteTime,
       last_access_time         AS LastAccessTime,
       is_offline               AS IsOffline,
       is_hidden                AS IsHidden,
       is_readonly              AS IsReadonly,
       is_archive               AS IsArchive,
       is_system                AS IsSystem,
       is_temporary             AS IsTemporary,
       is_directory             AS IsDirectory
FROM   dbo.Photos               AS p
WHERE  (is_directory = 1)


GO
ALTER TABLE [dbo].[TblPrintSizes] ADD  CONSTRAINT [DF_TblPrintSizes_HasFirstPrint]  DEFAULT ((1)) FOR [HasFirstPrint]
GO
ALTER TABLE [dbo].[TblPrintSizes] ADD  CONSTRAINT [DF_TblPrintSizes_HasRePrint]  DEFAULT ((1)) FOR [HasRePrint]
GO
ALTER TABLE [dbo].[TblPrintSizes] ADD  CONSTRAINT [DF_TblPrintSizes_HasMedicalPhoto]  DEFAULT ((1)) FOR [HasMedicalPhoto]
GO
ALTER TABLE [dbo].[TblPrintSizes] ADD  CONSTRAINT [DF_TblPrintSizes_HasLitPrint]  DEFAULT ((1)) FOR [HasLitPrint]
GO
ALTER TABLE [dbo].[TblPrintSizes] ADD  CONSTRAINT [DF_TblPrintSizes_HasScanAndProcessing]  DEFAULT ((1)) FOR [HasScanAndProcessing]
GO
ALTER TABLE [dbo].[TblPrintSizes] ADD  CONSTRAINT [DF_TblPrintSizes_HasAlbum]  DEFAULT ((1)) FOR [HasAlbum]
GO
ALTER TABLE [dbo].[TblPrintSizes] ADD  CONSTRAINT [DF_TblPrintSizes_HasItalianAlbum]  DEFAULT ((1)) FOR [HasItalianAlbum]
GO
ALTER TABLE [dbo].[TblPrintSizes] ADD  CONSTRAINT [DF_TblPrintSizes_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[TblPrintSizes] ADD  CONSTRAINT [DF_TblPrintSizes_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[TblPrintSizes] ADD  CONSTRAINT [DF_TblPrintSizes_MinimumOrder]  DEFAULT ((1)) FOR [MinimumOrder]
GO
ALTER TABLE [dbo].[TblAlbums]  WITH CHECK ADD  CONSTRAINT [FK_TblAlbums_TblPrintSizes] FOREIGN KEY([PrintSizeId])
REFERENCES [dbo].[TblPrintSizes] ([Id])
GO
ALTER TABLE [dbo].[TblAlbums] CHECK CONSTRAINT [FK_TblAlbums_TblPrintSizes]
GO
ALTER TABLE [dbo].[TblAllOrderStatus]  WITH CHECK ADD  CONSTRAINT [FK_TblAllOrderStatus_TblOrder] FOREIGN KEY([OrderId])
REFERENCES [dbo].[TblOrder] ([Id])
GO
ALTER TABLE [dbo].[TblAllOrderStatus] CHECK CONSTRAINT [FK_TblAllOrderStatus_TblOrder]
GO
ALTER TABLE [dbo].[TblAllOrderStatus]  WITH CHECK ADD  CONSTRAINT [FK_TblAllOrderStatus_TblOrderPrint] FOREIGN KEY([OrderPrintId])
REFERENCES [dbo].[TblOrderPrint] ([Id])
GO
ALTER TABLE [dbo].[TblAllOrderStatus] CHECK CONSTRAINT [FK_TblAllOrderStatus_TblOrderPrint]
GO
ALTER TABLE [dbo].[TblBooking]  WITH CHECK ADD  CONSTRAINT [FK_TblBooking_TblAtelierType] FOREIGN KEY([AtelierTypeId])
REFERENCES [dbo].[TblAtelierType] ([Id])
GO
ALTER TABLE [dbo].[TblBooking] CHECK CONSTRAINT [FK_TblBooking_TblAtelierType]
GO
ALTER TABLE [dbo].[TblBooking]  WITH CHECK ADD  CONSTRAINT [FK_TblBooking_TblBookingStatus] FOREIGN KEY([StatusId])
REFERENCES [dbo].[TblBookingStatus] ([Id])
GO
ALTER TABLE [dbo].[TblBooking] CHECK CONSTRAINT [FK_TblBooking_TblBookingStatus]
GO
ALTER TABLE [dbo].[TblBooking]  WITH CHECK ADD  CONSTRAINT [FK_TblBooking_TblPhotographyType] FOREIGN KEY([PhotographyTypeId])
REFERENCES [dbo].[TblPhotographyType] ([Id])
GO
ALTER TABLE [dbo].[TblBooking] CHECK CONSTRAINT [FK_TblBooking_TblPhotographyType]
GO
ALTER TABLE [dbo].[TblBooking]  WITH CHECK ADD  CONSTRAINT [FK_TblBooking_TblUser] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[TblCustomer] ([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[TblBooking] CHECK CONSTRAINT [FK_TblBooking_TblUser]
GO
ALTER TABLE [dbo].[TblFilesError]  WITH CHECK ADD  CONSTRAINT [FK_TblFilesError_TblBooking] FOREIGN KEY([Id])
REFERENCES [dbo].[TblBooking] ([Id])
GO
ALTER TABLE [dbo].[TblFilesError] CHECK CONSTRAINT [FK_TblFilesError_TblBooking]
GO
ALTER TABLE [dbo].[TblFilesError]  WITH CHECK ADD  CONSTRAINT [FK_TblFilesError_TblCustomer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[TblCustomer] ([Id])
GO
ALTER TABLE [dbo].[TblFilesError] CHECK CONSTRAINT [FK_TblFilesError_TblCustomer]
GO
ALTER TABLE [dbo].[TblFilesError]  WITH CHECK ADD  CONSTRAINT [FK_TblFilesError_TblOrder] FOREIGN KEY([OrderId])
REFERENCES [dbo].[TblOrder] ([Id])
GO
ALTER TABLE [dbo].[TblFilesError] CHECK CONSTRAINT [FK_TblFilesError_TblOrder]
GO
ALTER TABLE [dbo].[TblOrder]  WITH CHECK ADD  CONSTRAINT [FK_TblOrder_TblBooking] FOREIGN KEY([BookingId])
REFERENCES [dbo].[TblBooking] ([Id])
GO
ALTER TABLE [dbo].[TblOrder] CHECK CONSTRAINT [FK_TblOrder_TblBooking]
GO
ALTER TABLE [dbo].[TblOrder]  WITH CHECK ADD  CONSTRAINT [FK_TblOrder_TblCustomer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[TblCustomer] ([Id])
GO
ALTER TABLE [dbo].[TblOrder] CHECK CONSTRAINT [FK_TblOrder_TblCustomer]
GO
ALTER TABLE [dbo].[TblOrder]  WITH CHECK ADD  CONSTRAINT [FK_TblOrder_TblCustomer1] FOREIGN KEY([LastOrderPrintCustomerId])
REFERENCES [dbo].[TblCustomer] ([Id])
GO
ALTER TABLE [dbo].[TblOrder] CHECK CONSTRAINT [FK_TblOrder_TblCustomer1]
GO
ALTER TABLE [dbo].[TblOrder]  WITH CHECK ADD  CONSTRAINT [FK_TblOrder_TblOrderStatus] FOREIGN KEY([OrderStatusId])
REFERENCES [dbo].[TblOrderStatus] ([Id])
GO
ALTER TABLE [dbo].[TblOrder] CHECK CONSTRAINT [FK_TblOrder_TblOrderStatus]
GO
ALTER TABLE [dbo].[TblOrder]  WITH CHECK ADD  CONSTRAINT [FK_TblOrder_TblPhotographyType] FOREIGN KEY([PhotographyTypeId])
REFERENCES [dbo].[TblPhotographyType] ([Id])
GO
ALTER TABLE [dbo].[TblOrder] CHECK CONSTRAINT [FK_TblOrder_TblPhotographyType]
GO
ALTER TABLE [dbo].[TblOrderFiles]  WITH CHECK ADD  CONSTRAINT [FK_TblOrderStreams_TblOrder] FOREIGN KEY([OrderId])
REFERENCES [dbo].[TblOrder] ([Id])
GO
ALTER TABLE [dbo].[TblOrderFiles] CHECK CONSTRAINT [FK_TblOrderStreams_TblOrder]
GO
ALTER TABLE [dbo].[TblOrderPrint]  WITH CHECK ADD  CONSTRAINT [FK_TblOrder_TblOrderPrint] FOREIGN KEY([OrderId])
REFERENCES [dbo].[TblOrder] ([Id])
GO
ALTER TABLE [dbo].[TblOrderPrint] CHECK CONSTRAINT [FK_TblOrder_TblOrderPrint]
GO
ALTER TABLE [dbo].[TblOrderPrint]  WITH CHECK ADD  CONSTRAINT [FK_TblOrderPrint_TblCustomer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[TblCustomer] ([Id])
GO
ALTER TABLE [dbo].[TblOrderPrint] CHECK CONSTRAINT [FK_TblOrderPrint_TblCustomer]
GO
ALTER TABLE [dbo].[TblOrderPrint]  WITH CHECK ADD  CONSTRAINT [FK_TblOrderPrint_TblOrderPrintStatus] FOREIGN KEY([OrderPrintStatusId])
REFERENCES [dbo].[TblOrderPrintStatus] ([Id])
GO
ALTER TABLE [dbo].[TblOrderPrint] CHECK CONSTRAINT [FK_TblOrderPrint_TblOrderPrintStatus]
GO
ALTER TABLE [dbo].[TblOrderPrintChangingElements]  WITH CHECK ADD  CONSTRAINT [FK_TblOrderPrintChangingElements_TblOrderPrintDetails] FOREIGN KEY([OrderPrintDetailsId])
REFERENCES [dbo].[TblOrderPrintDetails] ([Id])
GO
ALTER TABLE [dbo].[TblOrderPrintChangingElements] CHECK CONSTRAINT [FK_TblOrderPrintChangingElements_TblOrderPrintDetails]
GO
ALTER TABLE [dbo].[TblOrderPrintDetails]  WITH CHECK ADD  CONSTRAINT [FK_TblOrderPrintDetails_TblCustomer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[TblCustomer] ([Id])
GO
ALTER TABLE [dbo].[TblOrderPrintDetails] CHECK CONSTRAINT [FK_TblOrderPrintDetails_TblCustomer]
GO
ALTER TABLE [dbo].[TblOrderPrintDetails]  WITH CHECK ADD  CONSTRAINT [FK_TblOrderPrintDetails_TblOrderPrint] FOREIGN KEY([OrderPrintId])
REFERENCES [dbo].[TblOrderPrint] ([Id])
GO
ALTER TABLE [dbo].[TblOrderPrintDetails] CHECK CONSTRAINT [FK_TblOrderPrintDetails_TblOrderPrint]
GO
ALTER TABLE [dbo].[TblOrderPrintDetails]  WITH CHECK ADD  CONSTRAINT [FK_TblOrderPrintDetails_TblPrintServicePrices] FOREIGN KEY([PrintServicePriceId])
REFERENCES [dbo].[TblPrintServicePrices] ([Id])
GO
ALTER TABLE [dbo].[TblOrderPrintDetails] CHECK CONSTRAINT [FK_TblOrderPrintDetails_TblPrintServicePrices]
GO
ALTER TABLE [dbo].[TblOrderPrintDetails]  WITH CHECK ADD  CONSTRAINT [FK_TblOrderPrintDetails_TblPrintServicePrices_RePrint] FOREIGN KEY([RePrintPrintServicePriceId])
REFERENCES [dbo].[TblPrintServicePrices] ([Id])
GO
ALTER TABLE [dbo].[TblOrderPrintDetails] CHECK CONSTRAINT [FK_TblOrderPrintDetails_TblPrintServicePrices_RePrint]
GO
ALTER TABLE [dbo].[TblOrderPrintDetails]  WITH CHECK ADD  CONSTRAINT [FK_TblOrderPrintDetails_TblPrintServices] FOREIGN KEY([PrintServiceId])
REFERENCES [dbo].[TblPrintServices] ([Id])
GO
ALTER TABLE [dbo].[TblOrderPrintDetails] CHECK CONSTRAINT [FK_TblOrderPrintDetails_TblPrintServices]
GO
ALTER TABLE [dbo].[TblOrderPrintDetails]  WITH CHECK ADD  CONSTRAINT [FK_TblOrderPrintDetails_TblPrintServices_RePrint] FOREIGN KEY([RePrintPrintServiceId])
REFERENCES [dbo].[TblPrintServices] ([Id])
GO
ALTER TABLE [dbo].[TblOrderPrintDetails] CHECK CONSTRAINT [FK_TblOrderPrintDetails_TblPrintServices_RePrint]
GO
ALTER TABLE [dbo].[TblOrderPrintDetails]  WITH CHECK ADD  CONSTRAINT [FK_TblOrderPrintDetails_TblPrintSizePrices] FOREIGN KEY([PrintSizePriceId])
REFERENCES [dbo].[TblPrintSizePrices] ([Id])
GO
ALTER TABLE [dbo].[TblOrderPrintDetails] CHECK CONSTRAINT [FK_TblOrderPrintDetails_TblPrintSizePrices]
GO
ALTER TABLE [dbo].[TblOrderPrintDetails]  WITH CHECK ADD  CONSTRAINT [FK_TblOrderPrintDetails_TblPrintSizePrices_RePrint] FOREIGN KEY([RePrintPrintSizePriceId])
REFERENCES [dbo].[TblPrintSizePrices] ([Id])
GO
ALTER TABLE [dbo].[TblOrderPrintDetails] CHECK CONSTRAINT [FK_TblOrderPrintDetails_TblPrintSizePrices_RePrint]
GO
ALTER TABLE [dbo].[TblOrderPrintDetails]  WITH CHECK ADD  CONSTRAINT [FK_TblOrderPrintDetails_TblPrintSizes] FOREIGN KEY([PrintSizeId])
REFERENCES [dbo].[TblPrintSizes] ([Id])
GO
ALTER TABLE [dbo].[TblOrderPrintDetails] CHECK CONSTRAINT [FK_TblOrderPrintDetails_TblPrintSizes]
GO
ALTER TABLE [dbo].[TblOrderPrintDetails]  WITH CHECK ADD  CONSTRAINT [FK_TblOrderPrintDetails_TblPrintSizes_RePrint] FOREIGN KEY([RePrintPrintSizeId])
REFERENCES [dbo].[TblPrintSizes] ([Id])
GO
ALTER TABLE [dbo].[TblOrderPrintDetails] CHECK CONSTRAINT [FK_TblOrderPrintDetails_TblPrintSizes_RePrint]
GO
ALTER TABLE [dbo].[TblOrderPrintDetails]  WITH CHECK ADD  CONSTRAINT [FK_TblOrderPrintDetails_TblPrintSpecialServices] FOREIGN KEY([PrintSpecialServiceId])
REFERENCES [dbo].[TblPrintSpecialServices] ([Id])
GO
ALTER TABLE [dbo].[TblOrderPrintDetails] CHECK CONSTRAINT [FK_TblOrderPrintDetails_TblPrintSpecialServices]
GO
ALTER TABLE [dbo].[TblOrderPrintDetails]  WITH CHECK ADD  CONSTRAINT [FK_TblOrderPrintDetails_TblPrintSpecialServices_RePrint] FOREIGN KEY([RePrintPrintSpecialServiceId])
REFERENCES [dbo].[TblPrintSpecialServices] ([Id])
GO
ALTER TABLE [dbo].[TblOrderPrintDetails] CHECK CONSTRAINT [FK_TblOrderPrintDetails_TblPrintSpecialServices_RePrint]
GO
ALTER TABLE [dbo].[TblOrderPrintFiles]  WITH CHECK ADD  CONSTRAINT [FK_TblOrderPrintFiles_TblOrderPrint] FOREIGN KEY([OrderPrintId])
REFERENCES [dbo].[TblOrderPrint] ([Id])
GO
ALTER TABLE [dbo].[TblOrderPrintFiles] CHECK CONSTRAINT [FK_TblOrderPrintFiles_TblOrderPrint]
GO
ALTER TABLE [dbo].[TblOrderPrintLitPrint]  WITH CHECK ADD  CONSTRAINT [FK_TblOrderPrintLitPrint_TblOrderPrintDetails] FOREIGN KEY([OrderPrintDetailsId])
REFERENCES [dbo].[TblOrderPrintDetails] ([Id])
GO
ALTER TABLE [dbo].[TblOrderPrintLitPrint] CHECK CONSTRAINT [FK_TblOrderPrintLitPrint_TblOrderPrintDetails]
GO
ALTER TABLE [dbo].[TblOrderPrintMultiPhotoOrder]  WITH CHECK ADD  CONSTRAINT [FK_TblOrderPrintMultiPhotoOrder_TblOrderPrintDetails] FOREIGN KEY([OrderPrintDetailId])
REFERENCES [dbo].[TblOrderPrintDetails] ([Id])
GO
ALTER TABLE [dbo].[TblOrderPrintMultiPhotoOrder] CHECK CONSTRAINT [FK_TblOrderPrintMultiPhotoOrder_TblOrderPrintDetails]
GO
ALTER TABLE [dbo].[TblPrintCustomerFiles]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerFilePrint_TblPrintSizes] FOREIGN KEY([PrintSizeId])
REFERENCES [dbo].[TblPrintSizes] ([Id])
GO
ALTER TABLE [dbo].[TblPrintCustomerFiles] CHECK CONSTRAINT [FK_TblCustomerFilePrint_TblPrintSizes]
GO
ALTER TABLE [dbo].[TblPrintServicePrices]  WITH CHECK ADD  CONSTRAINT [FK_TblPrintServicePrices_TblPrintServices] FOREIGN KEY([PrintServiceId])
REFERENCES [dbo].[TblPrintServices] ([Id])
GO
ALTER TABLE [dbo].[TblPrintServicePrices] CHECK CONSTRAINT [FK_TblPrintServicePrices_TblPrintServices]
GO
ALTER TABLE [dbo].[TblPrintServicePrices]  WITH CHECK ADD  CONSTRAINT [FK_TblPrintServicePrices_TblPrintSizes] FOREIGN KEY([PrintSizeId])
REFERENCES [dbo].[TblPrintSizes] ([Id])
GO
ALTER TABLE [dbo].[TblPrintServicePrices] CHECK CONSTRAINT [FK_TblPrintServicePrices_TblPrintSizes]
GO
ALTER TABLE [dbo].[TblPrintSizePrices]  WITH CHECK ADD  CONSTRAINT [FK_TblSizePrice_TblPrintSizes1] FOREIGN KEY([PrintSizeId])
REFERENCES [dbo].[TblPrintSizes] ([Id])
GO
ALTER TABLE [dbo].[TblPrintSizePrices] CHECK CONSTRAINT [FK_TblSizePrice_TblPrintSizes1]
GO
/****** Object:  StoredProcedure [dbo].[usp_CreateCustomerFinancialDirectory]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_CreateCustomerFinancialDirectory] @customerFinancialNumber NVARCHAR(255), 
                                                        @monthNumber             NVARCHAR(255), 
                                                        @parent_level            TINYINT, 
                                                        @returnValue             NVARCHAR(MAX) OUT
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @parent_path_locator HIERARCHYID;
	DECLARE @temp_id BINARY(16);
	DECLARE @Exist INT;
	DECLARE @existPath NVARCHAR(MAX);
	SELECT @parent_path_locator = path_locator
	FROM   Photos AS p
	WHERE  p.name = @monthNumber
	       AND p.path_locator.GetLevel() = @parent_level
	       AND p.is_directory = 1;
	IF (@parent_path_locator IS NOT NULL)
	BEGIN
	    SET @existPath = (
	            SELECT file_stream.GetFileNamespacePath(1, 2)
	            FROM   photos
	            WHERE  NAME = @monthNumber
	        );
	    IF @existPath <> NULL
	    BEGIN
	        SET @Exist = 1;
	    END;
	ELSE
	BEGIN
	    SET @Exist = 0;
	    SET @temp_id = CONVERT(BINARY(16), NEWID());
	    DECLARE @path_locator VARCHAR(675);
	    SET @path_locator = @parent_path_locator.ToString() + CONVERT(VARCHAR(20), CONVERT(BIGINT, SUBSTRING(@temp_id, 1, 6))) 
	        + '.' + CONVERT(VARCHAR(20), CONVERT(BIGINT, SUBSTRING(@temp_id, 7, 6))) + '.' + CONVERT(VARCHAR(20), CONVERT(BIGINT, SUBSTRING(@temp_id, 13, 4))) 
	        + '/';
	    INSERT INTO Photos
	      (
	        NAME,
	        path_locator,
	        is_directory
	      )
	    VALUES
	      (
	        @customerFinancialNumber,
	        @path_locator,
	        1
	      );
	    SET @returnValue = (
	            SELECT file_stream.GetFileNamespacePath(1, 2)
	            FROM   photos
	            WHERE  NAME = @customerFinancialNumber
	        );
	END;
END;
            ELSE
BEGIN
	RAISERROR('The parent name does not exists', 16, 1);
	SET @returnValue = NULL;
END;
SELECT @returnValue AS 'StreamPath';
    END;

        --DECLARE @rValue NVARCHAR(max)
        --    SET @rValue = exec  usp_CreateCustomerFinancialDirectory '1402',            'Root',             1,'';
        --    SELECT @rValue;
        --    UPDATE Photos
        --    SET
        --        name = '2425'
        --    WHERE NAME='New folder'


GO
/****** Object:  StoredProcedure [dbo].[usp_CreateFileTableFile]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_CreateFileTableFile]
	@name NVARCHAR(255),
	@parent_name NVARCHAR(255),
	@parent_level TINYINT
AS
BEGIN
	SET XACT_ABORT ON
	SET NOCOUNT ON
	--When SET XACT_ABORT is ON, if a Transact-SQL statement raises a run-time error,
	--the entire transaction is terminated and rolled back.
	--https://docs.microsoft.com/en-us/sql/t-sql/statements/set-xact-abort-transact-sql?view=sql-server-2017
	DECLARE @parent_path_locator HIERARCHYID;
	DECLARE @temp_id BINARY(16);
	DECLARE @insertedTable TABLE
	        (
	            [streamId] VARCHAR(4000),
	            [name] NVARCHAR(255),
	            [parent_locator] VARCHAR(4000),
	            path_name NVARCHAR(MAX),
	            filestreamTxn VARBINARY(MAX),
	            path_locator_str NVARCHAR(4000)
	        );
	
	-- Find the path_locator of the parent of the new file
	SELECT @parent_path_locator = path_locator
	FROM   Photos AS p
	WHERE  p.name = @parent_name
	       AND path_locator.GetLevel() = @parent_level
	       AND is_directory = 1;
	-- If the parent's path_locator was found
	IF (@parent_path_locator IS NOT NULL)
	BEGIN
	    SET @temp_id = CONVERT(BINARY(16), NEWID())
	    -- Create a new path_locator value that places the new file
	    -- as a child of the parent directory
	    DECLARE @path_locator VARCHAR(675)
	    SET @path_locator = @parent_path_locator.ToString() +
	        CONVERT(VARCHAR(20), CONVERT(BIGINT, SUBSTRING(@temp_id, 1, 6))) + '.' +
	        CONVERT(VARCHAR(20), CONVERT(BIGINT, SUBSTRING(@temp_id, 7, 6))) + '.' +
	        CONVERT(VARCHAR(20), CONVERT(BIGINT, SUBSTRING(@temp_id, 13, 4))) + '/'	
	    
	    BEGIN TRY
	    	BEGIN TRANSACTION
	    	INSERT INTO Photos
	    	  (
	    	    NAME,
	    	    file_stream,
	    	    path_locator
	    	  )OUTPUT CAST(INSERTED.[stream_id] AS VARCHAR(4000)), 
	    	   CAST(INSERTED.[name] AS NVARCHAR(255)), 
	    	   CAST(INSERTED.[path_locator] AS VARCHAR(4000)), 
	    	   CAST(INSERTED.file_stream.PathName() AS VARCHAR(4000)) AS filePath, 
	    	   GET_FILESTREAM_TRANSACTION_CONTEXT(), 
	    	   CAST(INSERTED.path_locator AS NVARCHAR(4000))
	    	   INTO @insertedTable
	    	VALUES
	    	  (
	    	    @name,
	    	    0x,
	    	    @path_locator
	    	  );
	    	COMMIT
	    	
	    	SELECT it.streamId,
	    	       it.name,
	    	       it.parent_locator,
	    	       it.path_name,
	    	       it.filestreamTxn,
	    	       it.path_locator_str
	    	FROM   @insertedTable it
	    END TRY
	    BEGIN CATCH
	    	RAISERROR('Failed to Insert Data', 16, 1)
	    	ROLLBACK
	    END CATCH;
	END;
	ELSE
	BEGIN
		-- Raise error because the specified parent folder does not exist
		RAISERROR(
		    'The parent name does not exist in the FileTable at the specified level.',
		    16,
		    1
		)
	END;
END;

GO
/****** Object:  StoredProcedure [dbo].[usp_CreateMonthFolder]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_CreateMonthFolder] @monthName    NVARCHAR(255), 
                                         @year         NVARCHAR(255), 
                                         @parent_level TINYINT, 
                                         @returnValue  NVARCHAR(MAX) OUT
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @parent_path_locator HIERARCHYID;
	DECLARE @temp_id BINARY(16);
	DECLARE @Exist INT;
	DECLARE @existPath NVARCHAR(MAX);
	SELECT @parent_path_locator = path_locator
	FROM   Photos AS p
	WHERE  p.name = @year
	       AND p.path_locator.GetLevel() = @parent_level
	       AND p.is_directory = 1;
	IF (@parent_path_locator IS NOT NULL)
	BEGIN
	    SET @existPath = (
	            SELECT file_stream.GetFileNamespacePath(1, 2)
	            FROM   photos
	            WHERE  NAME = @monthName
	        );
	    IF @existPath <> NULL
	    BEGIN
	        SET @Exist = 1;
	    END;
	ELSE
	BEGIN
	    SET @Exist = 0;
	    SET @temp_id = CONVERT(BINARY(16), NEWID());
	    DECLARE @path_locator VARCHAR(675);
	    SET @path_locator = @parent_path_locator.ToString() + CONVERT(VARCHAR(20), CONVERT(BIGINT, SUBSTRING(@temp_id, 1, 6))) 
	        + '.' + CONVERT(VARCHAR(20), CONVERT(BIGINT, SUBSTRING(@temp_id, 7, 6))) + '.' + CONVERT(VARCHAR(20), CONVERT(BIGINT, SUBSTRING(@temp_id, 13, 4))) 
	        + '/';
	    INSERT INTO Photos
	      (
	        NAME,
	        path_locator,
	        is_directory
	      )
	    VALUES
	      (
	        @monthName,
	        @path_locator,
	        1
	      );
	    SET @returnValue = (
	            SELECT file_stream.GetFileNamespacePath(1, 2)
	            FROM   photos
	            WHERE  NAME = @monthName
	        );
	END;
END;
            ELSE
BEGIN
	RAISERROR('The parent name does not exists', 16, 1);
	SET @returnValue = NULL;
END;
SELECT @returnValue AS 'StreamPath';
    END;
        --DECLARE @rValue NVARCHAR(max)
        --    SET @rValue = exec  usp_CreateMonthFolder '1402',            'Root',             1,'';
        --    SELECT @rValue;
        --    UPDATE Photos
        --    SET
        --        name = '2425'
        --    WHERE NAME='New folder'


GO
/****** Object:  StoredProcedure [dbo].[usp_CreateYearFolder]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_CreateYearFolder] @name         NVARCHAR(255), 
                                        @parent_name  NVARCHAR(255), 
                                        @parent_level TINYINT, 
                                        @returnValue  NVARCHAR(MAX) OUT
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @parent_path_locator HIERARCHYID;
	DECLARE @temp_id BINARY(16);
	DECLARE @Exist INT;
	DECLARE @existPath NVARCHAR(MAX);
	
	/********************************************/
	SELECT @parent_path_locator = path_locator
	FROM   Photos AS p
	WHERE  p.name = @parent_name
	       AND p.path_locator.GetLevel() = @parent_level
	       AND p.is_directory = 1;
	
	/********************************************/
	
	IF (@parent_path_locator IS NOT NULL)
	BEGIN
	    SET @existPath = (
	            SELECT file_stream.GetFileNamespacePath(1, 2)
	            FROM   photos
	            WHERE  NAME = @name
	        );
	    IF @existPath <> NULL
	    BEGIN
	        SET @Exist = 1;
	    END;
	ELSE
	BEGIN
	    SET @Exist = 0;
	    SET @temp_id = CONVERT(BINARY(16), NEWID());
	    DECLARE @path_locator VARCHAR(675);
	    
	    SET @path_locator = @parent_path_locator.ToString() +
	        CONVERT(VARCHAR(20), CONVERT(BIGINT, SUBSTRING(@temp_id, 1, 6))) +
	        '.' +
	        CONVERT(VARCHAR(20), CONVERT(BIGINT, SUBSTRING(@temp_id, 7, 6))) +
	        '.' +
	        CONVERT(VARCHAR(20), CONVERT(BIGINT, SUBSTRING(@temp_id, 13, 4))) +
	        '/';
	    
	    INSERT INTO Photos
	      (
	        NAME,
	        path_locator,
	        is_directory
	      )
	    VALUES
	      (
	        @name,
	        @path_locator,
	        1
	      );
	    
	    SET @returnValue = (
	            SELECT file_stream.GetFileNamespacePath(1, 2)
	            FROM   photos
	            WHERE  NAME = @name
	        );
	END;
END;
            ELSE
BEGIN
	RAISERROR('The parent name does not exists', 16, 1);
	SET @returnValue = NULL
END;
SELECT @returnValue AS 'StreamPath'
    END;


GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteOrderFolderFiles]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DeleteOrderFolderFiles]
	@pathLocator NVARCHAR(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	-- Insert statements for procedure here
	DELETE 
	FROM   dbo.Photos
	WHERE  parent_path_locator = @pathLocator
END

GO
/****** Object:  StoredProcedure [dbo].[usp_GetImageInfo]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_GetImageInfo]
	@photoStreamId UNIQUEIDENTIFIER
AS
BEGIN
	DECLARE @PathLocator VARCHAR(4000),
	        @TransactionContext VARBINARY(MAX),
	        @fileSize BIGINT,
	        @fileName NVARCHAR(255)
	
	
	BEGIN TRANSACTION
	
	SELECT @PathLocator = p.file_stream.PathName(),
	       @TransactionContext     = GET_FILESTREAM_TRANSACTION_CONTEXT(),
	       @fileSize               = p.cached_file_size,
	       @fileName               = p.name
	FROM   Photos AS p
	WHERE  p.stream_id = @photoStreamId
	
	SELECT @PathLocator         AS PathLocator,
	       @TransactionContext     TransactionContext,
	       @fileSize            AS FileSize,
	       @fileName            AS StreamFileName
	
	COMMIT TRANSACTION
END

GO
/****** Object:  StoredProcedure [dbo].[usp_GetListOfFilesInFolder]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_GetListOfFilesInFolder]
	@path_locator VARCHAR(4000)
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRANSACTION
	SELECT p.stream_id,
	       p.file_stream,
	       file_stream.GetFileNamespacePath(1, 2) AS FullUncPath,
	       p.name,
	       CAST(p.path_locator AS VARCHAR(4000)) AS PathLocator,
	       CAST(p.parent_path_locator AS VARCHAR(4000)) AS ParentPathLocator,
	       GET_FILESTREAM_TRANSACTION_CONTEXT() AS TransactionContext,
	       p.file_type,
	       p.cached_file_size,
	       p.creation_time,
	       p.last_write_time,
	       p.last_access_time,
	       p.is_directory,
	       p.is_offline,
	       p.is_hidden,
	       p.is_readonly,
	       p.is_archive,
	       p.is_system,
	       p.is_temporary
	FROM   dbo.Photos AS p
	WHERE  is_directory = 0
	       AND p.parent_path_locator = @path_locator
	
	COMMIT TRANSACTION
END

GO
/****** Object:  StoredProcedure [dbo].[usp_GetListOfFilesOfOrder]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_GetListOfFilesOfOrder]
	@path_locator VARCHAR(4000)
AS
BEGIN
	SET NOCOUNT ON;
	BEGIN TRANSACTION
	SELECT p.stream_id
	FROM   dbo.Photos AS p
	WHERE  is_directory = 0
	       AND p.parent_path_locator = @path_locator
	
	COMMIT TRANSACTION
END

GO
/****** Object:  StoredProcedure [dbo].[usp_GetOrderFolderStreamId]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetOrderFolderStreamId]
	@customerFinancialNumber NVARCHAR(255),
	@returnValue NVARCHAR(MAX) OUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	-- Insert statements for procedure here
	SET @returnValue = (
	        SELECT stream_id
	        FROM   Photos AS p
	        WHERE  NAME = @customerFinancialNumber
	    );
	SELECT @returnValue AS 'FolderStreamId';
END

GO
/****** Object:  StoredProcedure [dbo].[usp_GetPrintSizePriceServices]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_GetPrintSizePriceServices]
AS
BEGIN
	SELECT dbo.TblPrintSizePrices.SizeName,
	       dbo.TblPrintSizePrices.OriginalPrintPrice,
	       dbo.TblPrintSizePrices.SecondPrintPrice,
	       dbo.TblPrintServices.PrintServiceName,
	       dbo.TblPrintServices_TblPrintSizePrice.Price
	FROM   dbo.TblPrintServices
	       INNER JOIN dbo.TblPrintServices_TblPrintSizePrice
	            ON  dbo.TblPrintServices.Id = dbo.TblPrintServices_TblPrintSizePrice.PrintServiceId
	       INNER JOIN dbo.TblPrintSizePrices
	            ON  dbo.TblPrintServices_TblPrintSizePrice.PrintSizePriceId = dbo.TblPrintSizePrices.Id
END

GO
/****** Object:  StoredProcedure [dbo].[usp_GetTotalFilesOfFolder]    Script Date: 9/30/2019 9:28:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_GetTotalFilesOfFolder]
	@parent_path_locator NVARCHAR(MAX),
	@returnValue INT OUT
AS
BEGIN
	SET NOCOUNT ON;
	
	
	SET @returnValue = (
	        SELECT COUNT(*)
	        FROM   dbo.photos
	        WHERE  parent_path_locator = @parent_path_locator
	    )
END

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'stream_id مربوط به فولدر ذخیره می شود' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TblOrder', @level2type=N'COLUMN',@level2name=N'OrderFolderStreamId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'اطلاعات مربوط به فولدر ذخیره می شود.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TblOrder', @level2type=N'COLUMN',@level2name=N'OrderFolderPathLocator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'اطلاعات مربوط به فولدر ذخیره می شود.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TblOrder', @level2type=N'COLUMN',@level2name=N'OrderFolderParentPathLocator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'اضافه چاپ یا اصل چاپ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TblOrderPrint', @level2type=N'COLUMN',@level2name=N'OrderType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[22] 4[29] 2[22] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TblPrintSizePrices"
            Begin Extent = 
               Top = 1
               Left = 22
               Bottom = 178
               Right = 257
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TblPrintSizes"
            Begin Extent = 
               Top = 27
               Left = 382
               Bottom = 176
               Right = 595
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TblPrintServices"
            Begin Extent = 
               Top = 20
               Left = 1090
               Bottom = 162
               Right = 1301
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TblPrintServicePrices"
            Begin Extent = 
               Top = 28
               Left = 752
               Bottom = 178
               Right = 960
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 26
         Width = 284
         Width = 1020
         Width = 1275
         Width = 1410
         Width = 1665
         Width = 1350
         Width = 1605
         Width = 1515
         Width = 1290
         Width = 1155
         Width = 1605
         Width = 1215
         Width = 1785
         Width = 1065
         Width = 1155
         Width = 1725
         Width = 2055
         Width = 1665
         Width = 2145
         Width = 1515
         Width = 1995
         Width = 2385
         Width = 810
         Width = 915
       ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_GetAllPrintSizeAndServicesInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'  Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1635
         Alias = 1695
         Table = 1875
         Output = 765
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_GetAllPrintSizeAndServicesInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_GetAllPrintSizeAndServicesInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "p"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 232
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 10
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_GetDocumentsFolders'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_GetDocumentsFolders'
GO
USE [master]
GO
ALTER DATABASE [PhotographyAutomationDB] SET  READ_WRITE 
GO
