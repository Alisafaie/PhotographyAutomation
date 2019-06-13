USE [master]
GO
/****** Object:  Database [PhotographyAutomationDB]    Script Date: 6/13/2019 1:57:25 PM ******/
CREATE DATABASE [PhotographyAutomationDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PhotographyAutomationDB', FILENAME = N'C:\SQL-2014\Data_Log\PhotographyAutomationDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB ), 
 FILEGROUP [PhotoArchive_FG1] CONTAINS FILESTREAM  DEFAULT
( NAME = N'PhotoArchive_1', FILENAME = N'c:\PhotographyAutomation_FileStores\PhotoArchive_1' , MAXSIZE = UNLIMITED), 
 FILEGROUP [RetouchedPhotos_FG1] CONTAINS FILESTREAM 
( NAME = N'RetouchedPhotoArchive_1', FILENAME = N'C:\PhotographyAutomation_FileStores\RetouchedPhotoArchive_1' , MAXSIZE = UNLIMITED)
 LOG ON 
( NAME = N'PhotographyAutomationDB_log', FILENAME = N'C:\SQL-2014\Data_Log\PhotographyAutomationDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [PhotographyAutomationDB] ADD FILEGROUP [PhotosFileGroup]
GO
ALTER DATABASE [PhotographyAutomationDB] ADD FILEGROUP [RetouchedPhotosFileGroup]
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
ALTER DATABASE [PhotographyAutomationDB] SET RECOVERY SIMPLE 
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
/****** Object:  Table [dbo].[Photos]    Script Date: 6/13/2019 1:57:25 PM ******/
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
/****** Object:  Table [dbo].[PhotosRetouched]    Script Date: 6/13/2019 1:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ARITHABORT ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhotosRetouched] AS FILETABLE ON [RetouchedPhotosFileGroup] FILESTREAM_ON [RetouchedPhotos_FG1]
WITH
(
FILETABLE_DIRECTORY = N'RetouchedPhotos', FILETABLE_COLLATE_FILENAME = Persian_100_CI_AI
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblAllOrderStatus]    Script Date: 6/13/2019 1:57:25 PM ******/
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
/****** Object:  Table [dbo].[TblAtelierType]    Script Date: 6/13/2019 1:57:25 PM ******/
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
/****** Object:  Table [dbo].[TblBooking]    Script Date: 6/13/2019 1:57:25 PM ******/
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
/****** Object:  Table [dbo].[TblBookingStatus]    Script Date: 6/13/2019 1:57:25 PM ******/
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
/****** Object:  Table [dbo].[TblCustomer]    Script Date: 6/13/2019 1:57:25 PM ******/
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
/****** Object:  Table [dbo].[TblCustomerDocuments]    Script Date: 6/13/2019 1:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblCustomerDocuments](
	[CustomerId] [int] NOT NULL,
	[DocumentId] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblDocumentPhotos]    Script Date: 6/13/2019 1:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblDocumentPhotos](
	[Id] [int] NOT NULL,
	[DocumentId] [int] NOT NULL,
	[StreamId] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[CustomerId] [int] NOT NULL,
	[IsSelected] [bit] NOT NULL,
	[path_locator] [nvarchar](max) NULL,
	[parent_path_locator] [nvarchar](max) NULL,
 CONSTRAINT [PK_DocumentPhotos_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblDocuments]    Script Date: 6/13/2019 1:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblDocuments](
	[Id] [int] NOT NULL,
	[DocumentNumber] [int] NULL,
	[FinacialDescription] [nvarchar](500) NULL,
 CONSTRAINT [PK_Documents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblEmployeeType]    Script Date: 6/13/2019 1:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblEmployeeType](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Code] [int] NOT NULL,
	[PositionName] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_tblEmployeeTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblEmpRole]    Script Date: 6/13/2019 1:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblEmpRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmpTypeId] [tinyint] NULL,
	[RoleTypeId] [int] NULL,
 CONSTRAINT [PK_tblEmp_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblFilesError]    Script Date: 6/13/2019 1:57:25 PM ******/
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
/****** Object:  Table [dbo].[TblOrder]    Script Date: 6/13/2019 1:57:25 PM ******/
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
 CONSTRAINT [PK_TblOrder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TblOrderFiles]    Script Date: 6/13/2019 1:57:25 PM ******/
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
/****** Object:  Table [dbo].[TblOrderPrint]    Script Date: 6/13/2019 1:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblOrderPrint](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[OrderType] [bit] NOT NULL,
	[OrderStatusId] [int] NOT NULL,
	[FinancialCustomerId] [int] NOT NULL,
	[RetochDescriptions] [nvarchar](max) NULL,
	[TotalPhotos] [int] NULL,
	[TotalPrice] [bigint] NULL,
	[Payment] [bigint] NULL,
	[Deposit] [bigint] NULL,
	[Remaining] [bigint] NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[ModifiedDateTime] [datetime] NULL,
 CONSTRAINT [PK_TblOrderPrint] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblOrderPrintDetails]    Script Date: 6/13/2019 1:57:25 PM ******/
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
	[RetochDescription] [nvarchar](4000) NULL,
	[HasShasi] [bit] NULL,
	[HasFrame] [bit] NULL,
	[HasGhabShasi] [bit] NULL,
	[HasGhabShishe] [bit] NULL,
	[CreatedDateTime] [nchar](10) NOT NULL,
	[ModifiedDateTime] [nchar](10) NULL,
 CONSTRAINT [PK_TblOrderPrintDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblOrderStatus]    Script Date: 6/13/2019 1:57:25 PM ******/
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
/****** Object:  Table [dbo].[TblPhotographyType]    Script Date: 6/13/2019 1:57:25 PM ******/
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
/****** Object:  Table [dbo].[TblPrintServices]    Script Date: 6/13/2019 1:57:25 PM ******/
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
/****** Object:  Table [dbo].[TblPrintServices_TblPrintSizePrice]    Script Date: 6/13/2019 1:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblPrintServices_TblPrintSizePrice](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PrintServiceId] [int] NOT NULL,
	[PrintSizePriceId] [int] NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Price] [int] NOT NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_TblPrintServicePrice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblPrintSizePrices]    Script Date: 6/13/2019 1:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblPrintSizePrices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SizeName] [nvarchar](50) NOT NULL,
	[SizeWidth] [smallmoney] NOT NULL,
	[SizeHeight] [smallmoney] NOT NULL,
	[OriginalPrintPrice] [int] NOT NULL,
	[SecondPrintPrice] [int] NOT NULL,
	[SizeDescription] [nvarchar](500) NULL,
 CONSTRAINT [PK_TblSizes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblRoleType]    Script Date: 6/13/2019 1:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblRoleType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NOT NULL,
	[RoleName] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_tblRoleType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[View_GetAllPhotos]    Script Date: 6/13/2019 1:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_GetAllPhotos]
AS
     SELECT stream_id AS 'StreamId', 
            file_stream AS 'FileStream', 
            [NAME] AS 'FileName', 
            CAST(path_locator AS VARCHAR(4000)) AS 'PathLocator', 
            CAST(parent_path_locator AS VARCHAR(4000)) AS 'ParentPathLocator', 
            file_stream.PathName() AS 'UncPath', 
            file_stream.GetFileNamespacePath(0) AS 'RelativePath', 
            file_stream.GetFileNamespacePath(1, 2) AS 'FullUncPath', 
            path_locator.GetLevel() AS 'Level', 
            file_type AS 'FileType', 
            cached_file_size AS 'FileSize', 
            creation_time AS 'CreationTime', 
            last_write_time AS 'LastWriteTime', 
            last_access_time AS 'LastAccessTime', 
            is_offline AS 'IsOffline', 
            is_hidden AS 'IsHidden', 
            is_readonly AS 'IsReadonly', 
            is_archive AS 'IsArchive', 
            is_system AS 'IsSystem', 
            is_temporary AS 'IsTemporary'
     FROM PhotographyAutomationDB.dbo.Photos AS p
     WHERE p.is_directory = 0;

GO
/****** Object:  View [dbo].[View_GetDocumentsFolders]    Script Date: 6/13/2019 1:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_GetDocumentsFolders]
AS
     SELECT stream_id AS 'StreamId', 
            file_stream AS 'FileStream', 
            [NAME] AS 'FolderName', 
            CAST(path_locator AS VARCHAR(4000)) AS 'PathLocator', 
            CAST(parent_path_locator AS VARCHAR(4000)) AS 'ParentPathLocator', 
            file_stream.PathName() AS 'UncPath', 
            file_stream.GetFileNamespacePath(0) AS 'RelativePath', 
            file_stream.GetFileNamespacePath(1, 2) AS 'FullUncPath', 
            path_locator.GetLevel() AS 'Level', 
            file_type AS 'FileType', 
            cached_file_size AS 'FileSize', 
            creation_time AS 'CreationTime', 
            last_write_time AS 'LastWriteTime', 
            last_access_time AS 'LastAccessTime', 
            is_offline AS 'IsOffline', 
            is_hidden AS 'IsHidden', 
            is_readonly AS 'IsReadonly', 
            is_archive AS 'IsArchive', 
            is_system AS 'IsSystem', 
            is_temporary AS 'IsTemporary',
            p.is_directory AS 'IsDirectory'
     FROM PhotographyAutomationDB.dbo.Photos AS p
     WHERE p.is_directory = 1;

GO
/****** Object:  View [dbo].[View_PrintSizesPrices]    Script Date: 6/13/2019 1:57:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_PrintSizesPrices]
AS
SELECT        dbo.TblPrintSizePrices.SizeName, dbo.TblPrintSizePrices.OriginalPrintPrice, dbo.TblPrintSizePrices.SecondPrintPrice, dbo.TblPrintServices.PrintServiceName, 
                         dbo.TblPrintServices_TblPrintSizePrice.Price
FROM            dbo.TblPrintServices INNER JOIN
                         dbo.TblPrintServices_TblPrintSizePrice ON dbo.TblPrintServices.Id = dbo.TblPrintServices_TblPrintSizePrice.PrintServiceId INNER JOIN
                         dbo.TblPrintSizePrices ON dbo.TblPrintServices_TblPrintSizePrice.PrintSizePriceId = dbo.TblPrintSizePrices.Id

GO
SET ANSI_PADDING ON
INSERT [dbo].[Photos] ([stream_id], [file_stream], [name], [path_locator], [creation_time], [last_write_time], [last_access_time], [is_directory], [is_offline], [is_hidden], [is_readonly], [is_archive], [is_system], [is_temporary]) VALUES (N'f3a342eb-e332-e911-aad7-742f68c6e6e6', NULL, N'Root', N'/173203677750903.275198238888107.1929032355/', CAST(N'2019-02-17T22:13:30.7488883+03:30' AS DateTimeOffset), CAST(N'2019-02-17T22:13:30.7488883+03:30' AS DateTimeOffset), CAST(N'2019-02-17T22:13:30.7488883+03:30' AS DateTimeOffset), 1, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Photos] ([stream_id], [file_stream], [name], [path_locator], [creation_time], [last_write_time], [last_access_time], [is_directory], [is_offline], [is_hidden], [is_readonly], [is_archive], [is_system], [is_temporary]) VALUES (N'92e49896-d63d-e911-aae0-742f68c6e6e6', NULL, N'1397', N'/173203677750903.275198238888107.1929032355/104605482832585.172909875804275.3671597573/', CAST(N'2019-03-03T20:35:48.0408850+03:30' AS DateTimeOffset), CAST(N'2019-03-03T20:35:48.0408850+03:30' AS DateTimeOffset), CAST(N'2019-03-03T20:35:48.0408850+03:30' AS DateTimeOffset), 1, 0, 0, 0, 1, 0, 0)
INSERT [dbo].[Photos] ([stream_id], [file_stream], [name], [path_locator], [creation_time], [last_write_time], [last_access_time], [is_directory], [is_offline], [is_hidden], [is_readonly], [is_archive], [is_system], [is_temporary]) VALUES (N'93e49896-d63d-e911-aae0-742f68c6e6e6', NULL, N'12', N'/173203677750903.275198238888107.1929032355/104605482832585.172909875804275.3671597573/87998538837917.234499316018755.4097516364/', CAST(N'2019-03-03T20:35:51.4452581+03:30' AS DateTimeOffset), CAST(N'2019-03-03T20:35:51.4452581+03:30' AS DateTimeOffset), CAST(N'2019-03-03T20:35:51.4452581+03:30' AS DateTimeOffset), 1, 0, 0, 0, 1, 0, 0)
INSERT [dbo].[Photos] ([stream_id], [file_stream], [name], [path_locator], [creation_time], [last_write_time], [last_access_time], [is_directory], [is_offline], [is_hidden], [is_readonly], [is_archive], [is_system], [is_temporary]) VALUES (N'1e558136-806e-e911-82b2-00271005f7f4', NULL, N'1398', N'/173203677750903.275198238888107.1929032355/163602302140948.157546683170465.4247371151/', CAST(N'2019-05-04T19:50:57.0825630+04:30' AS DateTimeOffset), CAST(N'2019-05-04T19:50:57.0825630+04:30' AS DateTimeOffset), CAST(N'2019-05-04T19:50:57.0825630+04:30' AS DateTimeOffset), 1, 0, 0, 0, 1, 0, 0)
INSERT [dbo].[Photos] ([stream_id], [file_stream], [name], [path_locator], [creation_time], [last_write_time], [last_access_time], [is_directory], [is_offline], [is_hidden], [is_readonly], [is_archive], [is_system], [is_temporary]) VALUES (N'1f558136-806e-e911-82b2-00271005f7f4', NULL, N'2', N'/173203677750903.275198238888107.1929032355/163602302140948.157546683170465.4247371151/39951644129968.213621565963338.2077679045/', CAST(N'2019-05-04T19:50:59.0946781+04:30' AS DateTimeOffset), CAST(N'2019-05-04T19:50:59.0946781+04:30' AS DateTimeOffset), CAST(N'2019-05-04T19:50:59.0946781+04:30' AS DateTimeOffset), 1, 0, 0, 0, 1, 0, 0)
INSERT [dbo].[Photos] ([stream_id], [file_stream], [name], [path_locator], [creation_time], [last_write_time], [last_access_time], [is_directory], [is_offline], [is_hidden], [is_readonly], [is_archive], [is_system], [is_temporary]) VALUES (N'7c87c33b-967c-e911-a2f8-00271005f7f4', NULL, N'3', N'/173203677750903.275198238888107.1929032355/163602302140948.157546683170465.4247371151/218873327760226.58602950833896.132922427/', CAST(N'2019-05-22T18:03:51.1109355+04:30' AS DateTimeOffset), CAST(N'2019-05-22T18:03:51.1109355+04:30' AS DateTimeOffset), CAST(N'2019-05-22T18:03:51.1109355+04:30' AS DateTimeOffset), 1, 0, 0, 0, 1, 0, 0)
SET ANSI_PADDING OFF
SET IDENTITY_INSERT [dbo].[TblAtelierType] ON 

INSERT [dbo].[TblAtelierType] ([Id], [Code], [AtelierName]) VALUES (1, 10, N'آتلیه پرسنلی')
INSERT [dbo].[TblAtelierType] ([Id], [Code], [AtelierName]) VALUES (2, 20, N'آتلیه هنری')
INSERT [dbo].[TblAtelierType] ([Id], [Code], [AtelierName]) VALUES (3, 30, N'آتلیه کودک')
INSERT [dbo].[TblAtelierType] ([Id], [Code], [AtelierName]) VALUES (4, 40, N'فضای باز سرو')
SET IDENTITY_INSERT [dbo].[TblAtelierType] OFF
SET IDENTITY_INSERT [dbo].[TblBooking] ON 

INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (1, 15, CAST(N'2019-02-28' AS Date), CAST(N'09:48:24' AS Time), 0, 4, 2, 2, 0, 0, 6, CAST(N'2019-01-17 09:48:41.960' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (2, 18, CAST(N'2019-02-28' AS Date), CAST(N'10:00:00' AS Time), 2, 1, 1, 1, 0, 0, 6, CAST(N'2019-01-17 17:57:50.387' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (3, 18, CAST(N'2019-02-28' AS Date), CAST(N'20:25:00' AS Time), 2, 1, 1, 1, 0, 0, 6, CAST(N'2019-01-17 17:59:07.350' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (4, 18, CAST(N'2019-02-27' AS Date), CAST(N'18:41:00' AS Time), 2, 4, 2, 4, 0, 0, 6, CAST(N'2019-01-17 18:41:55.020' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (5, 18, CAST(N'2019-02-28' AS Date), CAST(N'18:30:00' AS Time), 2, 3, 2, 1, 0, 0, 6, CAST(N'2019-01-17 18:49:23.000' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (14, 14, CAST(N'2019-03-05' AS Date), CAST(N'18:00:00' AS Time), 0, 3, 2, 3, 0, 0, 6, CAST(N'2019-03-02 11:19:37.810' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (15, 19, CAST(N'2019-02-27' AS Date), CAST(N'19:00:00' AS Time), 0, 3, 2, 3, 0, 0, 6, CAST(N'2019-02-26 18:00:38.933' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (16, 21, CAST(N'2019-03-19' AS Date), CAST(N'11:00:00' AS Time), 2, 2, 3, 3, 0, 0, 6, CAST(N'2019-03-16 18:33:36.130' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (17, 22, CAST(N'2019-03-14' AS Date), CAST(N'10:00:00' AS Time), 2, 3, 2, 3, 0, 0, 6, CAST(N'2019-03-07 21:36:55.843' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (18, 24, CAST(N'2019-03-12' AS Date), CAST(N'17:00:00' AS Time), 2, 1, 1, 3, 0, 0, 6, CAST(N'2019-03-09 12:41:53.727' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (20, 14, CAST(N'2019-05-08' AS Date), CAST(N'09:30:00' AS Time), 0, 2, 3, 1, 0, 0, 6, CAST(N'2019-05-04 21:22:47.960' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (21, 14, CAST(N'2019-03-29' AS Date), CAST(N'11:30:00' AS Time), 0, 3, 2, 3, 0, 0, 6, CAST(N'2019-03-29 13:43:16.013' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (1021, 14, CAST(N'2019-03-30' AS Date), CAST(N'10:30:00' AS Time), 2, 3, 2, 3, 0, 0, 6, CAST(N'2019-03-29 14:57:25.080' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (1022, 14, CAST(N'2019-03-30' AS Date), CAST(N'17:00:00' AS Time), 0, 3, 2, 3, 0, 0, 6, CAST(N'2019-03-30 11:02:02.403' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (1023, 14, CAST(N'2019-05-05' AS Date), CAST(N'16:30:00' AS Time), 1, 1, 1, 4, 0, 0, 6, CAST(N'2019-05-02 19:26:47.830' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (1024, 14, CAST(N'2019-05-04' AS Date), CAST(N'13:00:00' AS Time), 2, 1, 1, 1, 0, 0, 6, CAST(N'2019-05-04 12:52:08.260' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (1025, 14, CAST(N'2019-05-06' AS Date), CAST(N'12:45:00' AS Time), 2, 2, 3, 4, 0, 0, 6, CAST(N'2019-05-04 21:24:05.157' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (1026, 27, CAST(N'2019-05-08' AS Date), CAST(N'17:30:00' AS Time), 0, 3, 3, 5, 0, 0, 6, CAST(N'2019-05-05 18:10:47.447' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (1027, 24, CAST(N'2019-05-09' AS Date), CAST(N'19:00:00' AS Time), 0, 3, 2, 1, 0, 0, 5, CAST(N'2019-05-09 15:02:01.200' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (1028, 14, CAST(N'2019-05-13' AS Date), CAST(N'17:00:00' AS Time), 0, 2, 3, 3, 0, 0, 6, CAST(N'2019-05-13 12:18:48.090' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (1029, 14, CAST(N'2019-05-18' AS Date), CAST(N'17:00:00' AS Time), 0, 2, 3, 5, 0, 0, 5, CAST(N'2019-05-18 15:48:30.367' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (1030, 29, CAST(N'2019-06-11' AS Date), CAST(N'20:00:00' AS Time), 0, 2, 3, 3, 0, 0, 5, CAST(N'2019-06-10 09:52:45.057' AS DateTime), NULL)
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (1031, 22, CAST(N'2019-06-13' AS Date), CAST(N'17:30:00' AS Time), 2, 3, 2, 3, 0, 0, 5, CAST(N'2019-06-10 12:10:42.533' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[TblBooking] OFF
SET IDENTITY_INSERT [dbo].[TblBookingStatus] ON 

INSERT [dbo].[TblBookingStatus] ([Id], [Code], [StatusName]) VALUES (2, 10, N'فعال')
INSERT [dbo].[TblBookingStatus] ([Id], [Code], [StatusName]) VALUES (3, 20, N'غیر فعال')
INSERT [dbo].[TblBookingStatus] ([Id], [Code], [StatusName]) VALUES (4, 30, N'حذف')
INSERT [dbo].[TblBookingStatus] ([Id], [Code], [StatusName]) VALUES (5, 40, N'ورود به آتلیه')
INSERT [dbo].[TblBookingStatus] ([Id], [Code], [StatusName]) VALUES (6, 50, N'در انتظار بیعانه')
INSERT [dbo].[TblBookingStatus] ([Id], [Code], [StatusName]) VALUES (7, 60, N'لغو مشتری')
SET IDENTITY_INSERT [dbo].[TblBookingStatus] OFF
SET IDENTITY_INSERT [dbo].[TblCustomer] ON 

INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (13, N'علی', N'موذن صفایی', 1, N'اصفهان', N'3136676755', N'9332350909', N'alisafaie@gmail.com', N'1290795274 ', 0, 1, CAST(N'1983-09-03' AS Date), CAST(N'2014-02-18' AS Date), 1, 0, NULL, CAST(N'2019-01-13 20:37:11.500' AS DateTime), NULL)
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (14, N'علی', N'مؤذن صفایی', 1, N'اصفهان، خ هفت دست شرقی', N'3136676755', N'9133138675', N'', N'1290795274 ', NULL, 0, CAST(N'1983-09-03' AS Date), NULL, NULL, 0, NULL, NULL, CAST(N'2019-05-18 15:48:04.413' AS DateTime))
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (15, N'کوشا', N'کیانی فلاورجانی', 0, N'', N'3132337738', N'9999999999', N'', N'           ', NULL, 0, CAST(N'1987-06-01' AS Date), NULL, NULL, 0, NULL, CAST(N'2019-02-28 11:32:38.573' AS DateTime), NULL)
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (16, N'علی', N'احمدی', 1, N'', N'3136676755', N'9888888888', N'', N'           ', NULL, 0, CAST(N'1974-09-03' AS Date), NULL, NULL, 0, NULL, NULL, CAST(N'2019-03-02 13:21:21.633' AS DateTime))
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (17, N'علی', N'احمدیان', 0, N'', N'3136676755', N'9777777777', N'', N'           ', 0, 0, NULL, NULL, 1, 0, NULL, CAST(N'2019-01-17 17:37:42.633' AS DateTime), NULL)
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (18, N'عزیز', N'عزیزیان', 1, N'', N'3136676855', N'9666666665', N'aziz@azizian.com', N'           ', NULL, 0, CAST(N'1983-09-03' AS Date), NULL, NULL, 0, NULL, NULL, CAST(N'2019-03-16 18:35:16.920' AS DateTime))
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (19, N'کوشا', N'کیانی', 0, N'', N'3136676755', N'9131666288', N'kooshakiani@yahoo.com', N'           ', NULL, 0, CAST(N'1987-06-01' AS Date), NULL, NULL, 0, NULL, NULL, CAST(N'2019-03-16 18:35:05.157' AS DateTime))
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (20, N'علی', N'کیانی', 0, N'', N'3136249500', N'9131152123', N'', N'           ', 0, 0, CAST(N'1958-05-03' AS Date), NULL, 1, 0, NULL, CAST(N'2019-02-27 19:30:46.880' AS DateTime), NULL)
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (21, N'احسان', N'بابائیان', 1, N'', N'3132352553', N'9131684870', N'', N'           ', NULL, 1, CAST(N'1981-07-27' AS Date), NULL, NULL, 0, NULL, NULL, CAST(N'2019-03-16 18:33:16.347' AS DateTime))
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (22, N'حسین', N'موذن صفایی', 1, N'', N'3132337738', N'9131188156', N'', N'           ', NULL, 1, CAST(N'1948-12-23' AS Date), NULL, NULL, 0, NULL, NULL, CAST(N'2019-06-10 12:09:49.270' AS DateTime))
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (23, N'زهرا', N'فلفلیان', 0, N'', N'3132337738', N'9133081799', N'', N'           ', NULL, 1, NULL, NULL, NULL, 0, NULL, CAST(N'2019-03-07 21:54:34.607' AS DateTime), NULL)
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (24, N'حمیدرضا', N'خباز زاده', 1, N'', N'3134510265', N'9123365946', N'', N'           ', NULL, 0, NULL, NULL, NULL, 0, NULL, NULL, CAST(N'2019-06-02 13:04:41.817' AS DateTime))
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (27, N'شمیم', N'آل یاسین', 1, N'', N'3136676755', N'9303345002', N'', N'           ', NULL, 0, NULL, NULL, NULL, 0, NULL, NULL, CAST(N'2019-05-05 18:28:36.663' AS DateTime))
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (28, N'احمد', N'کیانی', 1, N'', N'3136565677', N'9123334444', N'', N'           ', NULL, 0, NULL, NULL, NULL, 0, NULL, CAST(N'2019-06-09 19:26:22.133' AS DateTime), NULL)
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (29, N'فاطمه', N'رهنما', 0, N'', N'3136676677', N'9132151076', N'', N'           ', NULL, 0, NULL, NULL, NULL, 0, NULL, CAST(N'2019-06-10 09:52:00.327' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[TblCustomer] OFF
SET IDENTITY_INSERT [dbo].[TblOrderStatus] ON 

INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (3, 10, N'ورود به آتلیه')
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (4, 20, N'بارگزاری عکس')
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (5, 30, N'انتخاب عکس و سایز')
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (6, 40, N'انتخاب آلبوم و خدمات ')
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (8, 50, N'تعیین اولویت')
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (9, 60, N'در حال پردازش')
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (10, 70, N'بازبینی عکس')
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (11, 80, N'در حال چاپ')
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (12, 90, N'خدمات اضافه')
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (13, 100, N'ساخت آلبوم')
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (14, 110, N'تائید مالی')
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (15, 120, N'تحویل به مشتری')
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (16, 130, N'راکد')
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (17, 140, N'ارسال ناقص فایل ها')
SET IDENTITY_INSERT [dbo].[TblOrderStatus] OFF
SET IDENTITY_INSERT [dbo].[TblPhotographyType] ON 

INSERT [dbo].[TblPhotographyType] ([Id], [Code], [TypeName]) VALUES (1, 10, N'پرسنلی')
INSERT [dbo].[TblPhotographyType] ([Id], [Code], [TypeName]) VALUES (2, 20, N'کودک')
INSERT [dbo].[TblPhotographyType] ([Id], [Code], [TypeName]) VALUES (3, 30, N'خانوادگی')
INSERT [dbo].[TblPhotographyType] ([Id], [Code], [TypeName]) VALUES (4, 40, N'نامزدی')
INSERT [dbo].[TblPhotographyType] ([Id], [Code], [TypeName]) VALUES (5, 50, N'جشن')
SET IDENTITY_INSERT [dbo].[TblPhotographyType] OFF
SET IDENTITY_INSERT [dbo].[TblPrintServices] ON 

INSERT [dbo].[TblPrintServices] ([Id], [Code], [PrintServiceName], [PrintServiceDescription]) VALUES (1, N'10', N'شاسی 8 میل', NULL)
INSERT [dbo].[TblPrintServices] ([Id], [Code], [PrintServiceName], [PrintServiceDescription]) VALUES (2, N'11', N'شاسی 16 میل', NULL)
INSERT [dbo].[TblPrintServices] ([Id], [Code], [PrintServiceName], [PrintServiceDescription]) VALUES (3, N'12', N'قاب و شیشه سفید', NULL)
INSERT [dbo].[TblPrintServices] ([Id], [Code], [PrintServiceName], [PrintServiceDescription]) VALUES (4, N'13', N'قاب و شیشه قهوه ای', NULL)
INSERT [dbo].[TblPrintServices] ([Id], [Code], [PrintServiceName], [PrintServiceDescription]) VALUES (5, N'14', N'قاب شاسی سفید', NULL)
INSERT [dbo].[TblPrintServices] ([Id], [Code], [PrintServiceName], [PrintServiceDescription]) VALUES (6, N'15', N'قاب شاسی قهوه ای', NULL)
INSERT [dbo].[TblPrintServices] ([Id], [Code], [PrintServiceName], [PrintServiceDescription]) VALUES (7, N'16', N'فریم 2 سانتی سفید', NULL)
INSERT [dbo].[TblPrintServices] ([Id], [Code], [PrintServiceName], [PrintServiceDescription]) VALUES (9, N'17', N'فریم 2 سانتی قهوه ای', NULL)
INSERT [dbo].[TblPrintServices] ([Id], [Code], [PrintServiceName], [PrintServiceDescription]) VALUES (10, N'18', N'فریم 4 سانتی سفید', NULL)
INSERT [dbo].[TblPrintServices] ([Id], [Code], [PrintServiceName], [PrintServiceDescription]) VALUES (12, N'19', N'فریم 4 سانتی قهوه ای', NULL)
SET IDENTITY_INSERT [dbo].[TblPrintServices] OFF
SET IDENTITY_INSERT [dbo].[TblPrintServices_TblPrintSizePrice] ON 

INSERT [dbo].[TblPrintServices_TblPrintSizePrice] ([Id], [PrintServiceId], [PrintSizePriceId], [Code], [Price], [Description]) VALUES (1, 1, 7, N'10', 80000, NULL)
INSERT [dbo].[TblPrintServices_TblPrintSizePrice] ([Id], [PrintServiceId], [PrintSizePriceId], [Code], [Price], [Description]) VALUES (2, 1, 8, N'11', 30000, NULL)
INSERT [dbo].[TblPrintServices_TblPrintSizePrice] ([Id], [PrintServiceId], [PrintSizePriceId], [Code], [Price], [Description]) VALUES (3, 1, 9, N'12', 8000, NULL)
INSERT [dbo].[TblPrintServices_TblPrintSizePrice] ([Id], [PrintServiceId], [PrintSizePriceId], [Code], [Price], [Description]) VALUES (4, 1, 10, N'13', 100000, NULL)
INSERT [dbo].[TblPrintServices_TblPrintSizePrice] ([Id], [PrintServiceId], [PrintSizePriceId], [Code], [Price], [Description]) VALUES (5, 3, 8, N'14', 120000, NULL)
INSERT [dbo].[TblPrintServices_TblPrintSizePrice] ([Id], [PrintServiceId], [PrintSizePriceId], [Code], [Price], [Description]) VALUES (6, 3, 9, N'15', 150000, NULL)
SET IDENTITY_INSERT [dbo].[TblPrintServices_TblPrintSizePrice] OFF
SET IDENTITY_INSERT [dbo].[TblPrintSizePrices] ON 

INSERT [dbo].[TblPrintSizePrices] ([Id], [SizeName], [SizeWidth], [SizeHeight], [OriginalPrintPrice], [SecondPrintPrice], [SizeDescription]) VALUES (1, N'2 x 3', 2.0000, 3.0000, 150000, 120000, NULL)
INSERT [dbo].[TblPrintSizePrices] ([Id], [SizeName], [SizeWidth], [SizeHeight], [OriginalPrintPrice], [SecondPrintPrice], [SizeDescription]) VALUES (2, N'3 x 4', 3.0000, 4.0000, 150000, 120000, NULL)
INSERT [dbo].[TblPrintSizePrices] ([Id], [SizeName], [SizeWidth], [SizeHeight], [OriginalPrintPrice], [SecondPrintPrice], [SizeDescription]) VALUES (3, N'3.5 x 4.5', 3.5000, 3.5000, 180000, 150000, NULL)
INSERT [dbo].[TblPrintSizePrices] ([Id], [SizeName], [SizeWidth], [SizeHeight], [OriginalPrintPrice], [SecondPrintPrice], [SizeDescription]) VALUES (4, N'5 x 5', 5.0000, 5.0000, 180000, 150000, NULL)
INSERT [dbo].[TblPrintSizePrices] ([Id], [SizeName], [SizeWidth], [SizeHeight], [OriginalPrintPrice], [SecondPrintPrice], [SizeDescription]) VALUES (5, N'6 x 4', 6.0000, 4.0000, 180000, 150000, NULL)
INSERT [dbo].[TblPrintSizePrices] ([Id], [SizeName], [SizeWidth], [SizeHeight], [OriginalPrintPrice], [SecondPrintPrice], [SizeDescription]) VALUES (6, N'6 x 9', 6.0000, 9.0000, 250000, 150000, NULL)
INSERT [dbo].[TblPrintSizePrices] ([Id], [SizeName], [SizeWidth], [SizeHeight], [OriginalPrintPrice], [SecondPrintPrice], [SizeDescription]) VALUES (7, N'10 x 15', 10.0000, 15.0000, 150000, 120000, NULL)
INSERT [dbo].[TblPrintSizePrices] ([Id], [SizeName], [SizeWidth], [SizeHeight], [OriginalPrintPrice], [SecondPrintPrice], [SizeDescription]) VALUES (8, N'13 x 18', 13.0000, 18.0000, 250000, 200000, NULL)
INSERT [dbo].[TblPrintSizePrices] ([Id], [SizeName], [SizeWidth], [SizeHeight], [OriginalPrintPrice], [SecondPrintPrice], [SizeDescription]) VALUES (9, N'16 x 21', 16.0000, 21.0000, 400000, 350000, NULL)
INSERT [dbo].[TblPrintSizePrices] ([Id], [SizeName], [SizeWidth], [SizeHeight], [OriginalPrintPrice], [SecondPrintPrice], [SizeDescription]) VALUES (10, N'20 x 25', 20.0000, 25.0000, 450000, 400000, NULL)
INSERT [dbo].[TblPrintSizePrices] ([Id], [SizeName], [SizeWidth], [SizeHeight], [OriginalPrintPrice], [SecondPrintPrice], [SizeDescription]) VALUES (11, N'20 x 30', 20.0000, 30.0000, 350000, 300000, N'چاپ روی کاغذ Coated')
INSERT [dbo].[TblPrintSizePrices] ([Id], [SizeName], [SizeWidth], [SizeHeight], [OriginalPrintPrice], [SecondPrintPrice], [SizeDescription]) VALUES (12, N'30 x 40', 30.0000, 40.0000, 500000, 450000, NULL)
SET IDENTITY_INSERT [dbo].[TblPrintSizePrices] OFF
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
ALTER TABLE [dbo].[TblCustomerDocuments]  WITH CHECK ADD  CONSTRAINT [FK_CustomerDocuments_Documents] FOREIGN KEY([DocumentId])
REFERENCES [dbo].[TblDocuments] ([Id])
GO
ALTER TABLE [dbo].[TblCustomerDocuments] CHECK CONSTRAINT [FK_CustomerDocuments_Documents]
GO
ALTER TABLE [dbo].[TblCustomerDocuments]  WITH CHECK ADD  CONSTRAINT [FK_CustomerDocuments_TblCustomer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[TblCustomer] ([Id])
GO
ALTER TABLE [dbo].[TblCustomerDocuments] CHECK CONSTRAINT [FK_CustomerDocuments_TblCustomer]
GO
ALTER TABLE [dbo].[TblDocumentPhotos]  WITH CHECK ADD  CONSTRAINT [FK_DocumentPhotos_Photos] FOREIGN KEY([StreamId])
REFERENCES [dbo].[Photos] ([stream_id])
GO
ALTER TABLE [dbo].[TblDocumentPhotos] CHECK CONSTRAINT [FK_DocumentPhotos_Photos]
GO
ALTER TABLE [dbo].[TblDocumentPhotos]  WITH CHECK ADD  CONSTRAINT [FK_TblDocumentPhotos_TblDocuments] FOREIGN KEY([DocumentId])
REFERENCES [dbo].[TblDocuments] ([Id])
GO
ALTER TABLE [dbo].[TblDocumentPhotos] CHECK CONSTRAINT [FK_TblDocumentPhotos_TblDocuments]
GO
ALTER TABLE [dbo].[TblEmpRole]  WITH CHECK ADD  CONSTRAINT [FK_tblEmp_Role_tblEmployeeType] FOREIGN KEY([EmpTypeId])
REFERENCES [dbo].[TblEmployeeType] ([Id])
GO
ALTER TABLE [dbo].[TblEmpRole] CHECK CONSTRAINT [FK_tblEmp_Role_tblEmployeeType]
GO
ALTER TABLE [dbo].[TblEmpRole]  WITH CHECK ADD  CONSTRAINT [FK_tblEmp_Role_tblRoleType] FOREIGN KEY([RoleTypeId])
REFERENCES [dbo].[TblRoleType] ([Id])
GO
ALTER TABLE [dbo].[TblEmpRole] CHECK CONSTRAINT [FK_tblEmp_Role_tblRoleType]
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
ALTER TABLE [dbo].[TblOrderPrint]  WITH CHECK ADD  CONSTRAINT [FK_TblOrderPrint_TblCustomer] FOREIGN KEY([FinancialCustomerId])
REFERENCES [dbo].[TblCustomer] ([Id])
GO
ALTER TABLE [dbo].[TblOrderPrint] CHECK CONSTRAINT [FK_TblOrderPrint_TblCustomer]
GO
ALTER TABLE [dbo].[TblOrderPrint]  WITH CHECK ADD  CONSTRAINT [FK_TblOrderPrint_TblOrderStatus] FOREIGN KEY([OrderStatusId])
REFERENCES [dbo].[TblOrderStatus] ([Id])
GO
ALTER TABLE [dbo].[TblOrderPrint] CHECK CONSTRAINT [FK_TblOrderPrint_TblOrderStatus]
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
ALTER TABLE [dbo].[TblPrintServices_TblPrintSizePrice]  WITH CHECK ADD  CONSTRAINT [FK_TblPrintServicePrice_TblPrintServices] FOREIGN KEY([PrintServiceId])
REFERENCES [dbo].[TblPrintServices] ([Id])
GO
ALTER TABLE [dbo].[TblPrintServices_TblPrintSizePrice] CHECK CONSTRAINT [FK_TblPrintServicePrice_TblPrintServices]
GO
ALTER TABLE [dbo].[TblPrintServices_TblPrintSizePrice]  WITH CHECK ADD  CONSTRAINT [FK_TblPrintServicePrice_TblPrintSizePrices] FOREIGN KEY([PrintSizePriceId])
REFERENCES [dbo].[TblPrintSizePrices] ([Id])
GO
ALTER TABLE [dbo].[TblPrintServices_TblPrintSizePrice] CHECK CONSTRAINT [FK_TblPrintServicePrice_TblPrintSizePrices]
GO
/****** Object:  StoredProcedure [dbo].[usp_CreateCustomerFinancialDirectory]    Script Date: 6/13/2019 1:57:26 PM ******/
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
        FROM Photos AS p
        WHERE p.name = @monthNumber
              AND p.path_locator.GetLevel() = @parent_level
              AND p.is_directory = 1;
        IF(@parent_path_locator IS NOT NULL)
            BEGIN
                SET @existPath =
                (
                    SELECT file_stream.GetFileNamespacePath(1, 2)
                    FROM photos
                    WHERE NAME = @monthNumber
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
                        SET @path_locator = @parent_path_locator.ToString() + CONVERT(VARCHAR(20), CONVERT(BIGINT, SUBSTRING(@temp_id, 1, 6))) + '.' + CONVERT(VARCHAR(20), CONVERT(BIGINT, SUBSTRING(@temp_id, 7, 6))) + '.' + CONVERT(VARCHAR(20), CONVERT(BIGINT, SUBSTRING(@temp_id, 13, 4))) + '/';
                        INSERT INTO Photos
                        (NAME, 
                         path_locator, 
                         is_directory
                        )
                        VALUES
                        (@customerFinancialNumber, 
                         @path_locator, 
                         1
                        );
                        SET @returnValue =
                        (
                            SELECT file_stream.GetFileNamespacePath(1, 2)
                            FROM photos
                            WHERE NAME = @customerFinancialNumber
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
/****** Object:  StoredProcedure [dbo].[usp_CreateFileTableFile]    Script Date: 6/13/2019 1:57:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_CreateFileTableFile] @name         NVARCHAR(255), 
                                                @parent_name  NVARCHAR(255), 
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
        ([streamId]       VARCHAR(4000), 
         [name]           NVARCHAR(255), 
         [parent_locator] VARCHAR(4000), 
         path_name        NVARCHAR(MAX), 
         filestreamTxn    VARBINARY(MAX), 
         path_locator_str NVARCHAR(4000)
        );

        -- Find the path_locator of the parent of the new file
        SELECT @parent_path_locator = path_locator
        FROM Photos AS p
        WHERE p.name = @parent_name
              AND path_locator.GetLevel() = @parent_level
              AND is_directory = 1;
        -- If the parent's path_locator was found
        IF(@parent_path_locator IS NOT NULL)
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
                (NAME, 
                 file_stream, 
                 path_locator
                )
                OUTPUT CAST(INSERTED.[stream_id] AS VARCHAR(4000)), 
                       CAST(INSERTED.[name] AS NVARCHAR(255)), 
                       CAST(INSERTED.[path_locator] AS VARCHAR(4000)), 
                       CAST(INSERTED.file_stream.PathName() AS VARCHAR(4000)) AS filePath, 
                       GET_FILESTREAM_TRANSACTION_CONTEXT(), 
                       CAST(INSERTED.path_locator AS NVARCHAR(4000))
                       INTO @insertedTable
                VALUES
                (@name, 
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
                FROM @insertedTable it

                	
                	
                END TRY
                BEGIN CATCH
                	RAISERROR( 'Failed to Insert Data',16,1)
                	ROLLBACK
                END CATCH;
        END;
            ELSE
            BEGIN
                -- Raise error because the specified parent folder does not exist
                RAISERROR('The parent name does not exist in the FileTable at the specified level.', 16, 1)
        END;
    END;

GO
/****** Object:  StoredProcedure [dbo].[usp_CreateMonthFolder]    Script Date: 6/13/2019 1:57:26 PM ******/
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
        FROM Photos AS p
        WHERE p.name = @year
              AND p.path_locator.GetLevel() = @parent_level
              AND p.is_directory = 1;
        IF(@parent_path_locator IS NOT NULL)
            BEGIN
                SET @existPath =
                (
                    SELECT file_stream.GetFileNamespacePath(1, 2)
                    FROM photos
                    WHERE NAME = @monthName
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
                        SET @path_locator = @parent_path_locator.ToString() + CONVERT(VARCHAR(20), CONVERT(BIGINT, SUBSTRING(@temp_id, 1, 6))) + '.' + CONVERT(VARCHAR(20), CONVERT(BIGINT, SUBSTRING(@temp_id, 7, 6))) + '.' + CONVERT(VARCHAR(20), CONVERT(BIGINT, SUBSTRING(@temp_id, 13, 4))) + '/';
                        INSERT INTO Photos
                        (NAME, 
                         path_locator, 
                         is_directory
                        )
                        VALUES
                        (@monthName, 
                         @path_locator, 
                         1
                        );
                        SET @returnValue =
                        (
                            SELECT file_stream.GetFileNamespacePath(1, 2)
                            FROM photos
                            WHERE NAME = @monthName
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
/****** Object:  StoredProcedure [dbo].[usp_CreateYearFolder]    Script Date: 6/13/2019 1:57:26 PM ******/
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
	    
	    SET @path_locator = 
							@parent_path_locator.ToString() + 
							CONVERT(VARCHAR(20), CONVERT(BIGINT, SUBSTRING(@temp_id, 1, 6)))+ 
							'.' + 
							CONVERT(VARCHAR(20), CONVERT(BIGINT, SUBSTRING(@temp_id, 7, 6))) + 
							'.' + 
							CONVERT(VARCHAR(20), CONVERT(BIGINT, SUBSTRING(@temp_id, 13, 4)))+ 
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
/****** Object:  StoredProcedure [dbo].[usp_DeleteOrderFolderFiles]    Script Date: 6/13/2019 1:57:26 PM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_GetImageInfo]    Script Date: 6/13/2019 1:57:26 PM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_GetListOfFilesInFolder]    Script Date: 6/13/2019 1:57:26 PM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_GetListOfFilesOfOrder]    Script Date: 6/13/2019 1:57:26 PM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_GetOrderFolderStreamId]    Script Date: 6/13/2019 1:57:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetOrderFolderStreamId] @customerFinancialNumber NVARCHAR(255),
											@returnValue             NVARCHAR(MAX) OUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SET @returnValue =
                        (
                            SELECT stream_id FROM 
                            Photos AS p
                            WHERE NAME = @customerFinancialNumber
                        );
                        SELECT @returnValue AS 'FolderStreamId';
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetPrintSizePriceServices]    Script Date: 6/13/2019 1:57:26 PM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_GetTotalFilesOfFolder]    Script Date: 6/13/2019 1:57:26 PM ******/
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
         Configuration = "(H (1[33] 4[28] 2[11] 3) )"
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
         Begin Table = "TblPrintServices"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 150
               Right = 249
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TblPrintSizePrices"
            Begin Extent = 
               Top = 6
               Left = 495
               Bottom = 160
               Right = 677
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TblPrintServices_TblPrintSizePrice"
            Begin Extent = 
               Top = 6
               Left = 287
               Bottom = 174
               Right = 457
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
      Begin ColumnWidths = 9
         Width = 284
         Width = 1755
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
         Alias = 1590
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_PrintSizesPrices'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_PrintSizesPrices'
GO
USE [master]
GO
ALTER DATABASE [PhotographyAutomationDB] SET  READ_WRITE 
GO
