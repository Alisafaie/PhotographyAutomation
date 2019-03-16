USE [master]
GO
/****** Object:  Database [PhotographyAutomationDB]    Script Date: 3/12/2019 7:05:57 PM ******/
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
ALTER DATABASE [PhotographyAutomationDB] SET COMPATIBILITY_LEVEL = 130
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
ALTER DATABASE [PhotographyAutomationDB] SET QUERY_STORE = OFF
GO
USE [PhotographyAutomationDB]
GO
/****** Object:  Table [dbo].[Photos]    Script Date: 3/12/2019 7:05:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ARITHABORT ON
GO
CREATE TABLE [dbo].[Photos] AS FILETABLE ON [PRIMARY] FILESTREAM_ON [PhotoArchive_FG1]
WITH
(
FILETABLE_DIRECTORY = N'Documents', FILETABLE_COLLATE_FILENAME = Persian_100_CI_AI
)
GO
/****** Object:  View [dbo].[View_GetAllPhotos]    Script Date: 3/12/2019 7:05:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/************************************************************
 * Code formatted by SoftTree SQL Assistant © v9.5.444
 * Time: 1397/11/25 12:33:04
 ************************************************************/

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
/****** Object:  View [dbo].[View_GetDocumentsFolders]    Script Date: 3/12/2019 7:05:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/************************************************************
 * Code formatted by SoftTree SQL Assistant © v9.5.444
 * Time: 1397/11/25 12:33:04
 ************************************************************/

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
/****** Object:  Table [dbo].[PhotosRetouched]    Script Date: 3/12/2019 7:05:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ARITHABORT ON
GO
CREATE TABLE [dbo].[PhotosRetouched] AS FILETABLE ON [RetouchedPhotosFileGroup] FILESTREAM_ON [RetouchedPhotos_FG1]
WITH
(
FILETABLE_DIRECTORY = N'RetouchedPhotos', FILETABLE_COLLATE_FILENAME = Persian_100_CI_AI
)
GO
/****** Object:  Table [dbo].[TblAllOrderStatus]    Script Date: 3/12/2019 7:05:58 PM ******/
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
/****** Object:  Table [dbo].[TblAtelierType]    Script Date: 3/12/2019 7:05:58 PM ******/
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
/****** Object:  Table [dbo].[TblBooking]    Script Date: 3/12/2019 7:05:58 PM ******/
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
/****** Object:  Table [dbo].[TblBookingStatus]    Script Date: 3/12/2019 7:05:58 PM ******/
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
/****** Object:  Table [dbo].[TblCustomer]    Script Date: 3/12/2019 7:05:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[TblCustomerDocuments]    Script Date: 3/12/2019 7:05:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblCustomerDocuments](
	[CustomerId] [int] NOT NULL,
	[DocumentId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblDocumentPhotos]    Script Date: 3/12/2019 7:05:58 PM ******/
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
/****** Object:  Table [dbo].[TblDocuments]    Script Date: 3/12/2019 7:05:58 PM ******/
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
/****** Object:  Table [dbo].[TblEmployeeType]    Script Date: 3/12/2019 7:05:58 PM ******/
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
/****** Object:  Table [dbo].[TblEmpRole]    Script Date: 3/12/2019 7:05:58 PM ******/
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
/****** Object:  Table [dbo].[TblOrder]    Script Date: 3/12/2019 7:05:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblOrder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderCode] [int] NOT NULL,
	[OrderStatusId] [int] NOT NULL,
	[BookingId] [int] NOT NULL,
	[PhotographyTypeId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[PhotographerId] [int] NULL,
	[PaymentIsOk] [tinyint] NULL,
	[OrdefFolderStreamId] [uniqueidentifier] NULL,
	[OrdefFolderPathLocator] [nvarchar](max) NULL,
	[OrdefFolderParentPathLocator] [nvarchar](max) NULL,
	[TotalFiles] [int] NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[ModifiedDateTime] [datetime] NULL,
 CONSTRAINT [PK_TblOrder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblOrderFiles]    Script Date: 3/12/2019 7:05:58 PM ******/
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
 CONSTRAINT [PK_TblOrderStreams] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TblOrderPrint]    Script Date: 3/12/2019 7:05:58 PM ******/
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
/****** Object:  Table [dbo].[TblOrderPrintDetails]    Script Date: 3/12/2019 7:05:58 PM ******/
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
/****** Object:  Table [dbo].[TblOrderStatus]    Script Date: 3/12/2019 7:05:58 PM ******/
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
/****** Object:  Table [dbo].[TblPhotographyType]    Script Date: 3/12/2019 7:05:58 PM ******/
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
/****** Object:  Table [dbo].[TblRoleType]    Script Date: 3/12/2019 7:05:58 PM ******/
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
INSERT [dbo].[Photos] ([stream_id], [file_stream], [name], [path_locator], [creation_time], [last_write_time], [last_access_time], [is_directory], [is_offline], [is_hidden], [is_readonly], [is_archive], [is_system], [is_temporary]) VALUES (N'f3a342eb-e332-e911-aad7-742f68c6e6e6', NULL, N'Root', N'/173203677750903.275198238888107.1929032355/', CAST(N'2019-02-17T22:13:30.7488883+03:30' AS DateTimeOffset), CAST(N'2019-02-17T22:13:30.7488883+03:30' AS DateTimeOffset), CAST(N'2019-02-17T22:13:30.7488883+03:30' AS DateTimeOffset), 1, 0, 0, 0, 0, 0, 0)
GO
INSERT [dbo].[Photos] ([stream_id], [file_stream], [name], [path_locator], [creation_time], [last_write_time], [last_access_time], [is_directory], [is_offline], [is_hidden], [is_readonly], [is_archive], [is_system], [is_temporary]) VALUES (N'92e49896-d63d-e911-aae0-742f68c6e6e6', NULL, N'1397', N'/173203677750903.275198238888107.1929032355/104605482832585.172909875804275.3671597573/', CAST(N'2019-03-03T20:35:48.0408850+03:30' AS DateTimeOffset), CAST(N'2019-03-03T20:35:48.0408850+03:30' AS DateTimeOffset), CAST(N'2019-03-03T20:35:48.0408850+03:30' AS DateTimeOffset), 1, 0, 0, 0, 1, 0, 0)
GO
INSERT [dbo].[Photos] ([stream_id], [file_stream], [name], [path_locator], [creation_time], [last_write_time], [last_access_time], [is_directory], [is_offline], [is_hidden], [is_readonly], [is_archive], [is_system], [is_temporary]) VALUES (N'93e49896-d63d-e911-aae0-742f68c6e6e6', NULL, N'12', N'/173203677750903.275198238888107.1929032355/104605482832585.172909875804275.3671597573/87998538837917.234499316018755.4097516364/', CAST(N'2019-03-03T20:35:51.4452581+03:30' AS DateTimeOffset), CAST(N'2019-03-03T20:35:51.4452581+03:30' AS DateTimeOffset), CAST(N'2019-03-03T20:35:51.4452581+03:30' AS DateTimeOffset), 1, 0, 0, 0, 1, 0, 0)
GO
SET IDENTITY_INSERT [dbo].[TblAtelierType] ON 
GO
INSERT [dbo].[TblAtelierType] ([Id], [Code], [AtelierName]) VALUES (1, 10, N'آتلیه پرسنلی')
GO
INSERT [dbo].[TblAtelierType] ([Id], [Code], [AtelierName]) VALUES (2, 20, N'آتلیه هنری')
GO
INSERT [dbo].[TblAtelierType] ([Id], [Code], [AtelierName]) VALUES (3, 30, N'آتلیه کودک')
GO
INSERT [dbo].[TblAtelierType] ([Id], [Code], [AtelierName]) VALUES (4, 40, N'فضای باز سرو')
GO
SET IDENTITY_INSERT [dbo].[TblAtelierType] OFF
GO
SET IDENTITY_INSERT [dbo].[TblBooking] ON 
GO
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (1, 15, CAST(N'2019-02-28' AS Date), CAST(N'09:48:24' AS Time), 0, 4, 2, 2, 0, 0, 6, CAST(N'2019-01-17T09:48:41.960' AS DateTime), NULL)
GO
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (2, 18, CAST(N'2019-02-28' AS Date), CAST(N'10:00:00' AS Time), 2, 1, 1, 1, 0, 0, 6, CAST(N'2019-01-17T17:57:50.387' AS DateTime), NULL)
GO
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (3, 18, CAST(N'2019-02-28' AS Date), CAST(N'20:25:00' AS Time), 2, 1, 1, 1, 0, 0, 6, CAST(N'2019-01-17T17:59:07.350' AS DateTime), NULL)
GO
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (4, 18, CAST(N'2019-02-27' AS Date), CAST(N'18:41:00' AS Time), 2, 4, 2, 4, 0, 0, 7, CAST(N'2019-01-17T18:41:55.020' AS DateTime), NULL)
GO
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (5, 18, CAST(N'2019-02-28' AS Date), CAST(N'18:30:00' AS Time), 2, 3, 2, 1, 0, 0, 6, CAST(N'2019-01-17T18:49:23.000' AS DateTime), NULL)
GO
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (14, 14, CAST(N'2019-03-05' AS Date), CAST(N'18:00:00' AS Time), 0, 3, 2, 3, 0, 0, 6, CAST(N'2019-03-02T11:19:37.810' AS DateTime), NULL)
GO
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (15, 19, CAST(N'2019-02-27' AS Date), CAST(N'19:00:00' AS Time), 0, 3, 2, 3, 0, 0, 6, CAST(N'2019-02-26T18:00:38.933' AS DateTime), NULL)
GO
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (16, 21, CAST(N'2019-03-13' AS Date), CAST(N'11:00:00' AS Time), 2, 2, 3, 3, 0, 0, 5, CAST(N'2019-03-12T10:07:43.367' AS DateTime), NULL)
GO
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (17, 22, CAST(N'2019-03-14' AS Date), CAST(N'10:00:00' AS Time), 2, 3, 2, 3, 0, 0, 5, CAST(N'2019-03-07T21:36:55.843' AS DateTime), NULL)
GO
INSERT [dbo].[TblBooking] ([Id], [CustomerId], [Date], [Time], [PhotographerGender], [PhotographyTypeId], [AtelierTypeId], [PersonCount], [PrepaymentIsOk], [Submitter], [StatusId], [CreatedDate], [ModifiedDate]) VALUES (18, 24, CAST(N'2019-03-12' AS Date), CAST(N'17:00:00' AS Time), 2, 1, 1, 3, 0, 0, 5, CAST(N'2019-03-09T12:41:53.727' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[TblBooking] OFF
GO
SET IDENTITY_INSERT [dbo].[TblBookingStatus] ON 
GO
INSERT [dbo].[TblBookingStatus] ([Id], [Code], [StatusName]) VALUES (2, 10, N'فعال')
GO
INSERT [dbo].[TblBookingStatus] ([Id], [Code], [StatusName]) VALUES (3, 20, N'غیر فعال')
GO
INSERT [dbo].[TblBookingStatus] ([Id], [Code], [StatusName]) VALUES (4, 30, N'حذف')
GO
INSERT [dbo].[TblBookingStatus] ([Id], [Code], [StatusName]) VALUES (5, 40, N'ورود به آتلیه')
GO
INSERT [dbo].[TblBookingStatus] ([Id], [Code], [StatusName]) VALUES (6, 50, N'در انتظار بیعانه')
GO
INSERT [dbo].[TblBookingStatus] ([Id], [Code], [StatusName]) VALUES (7, 60, N'لغو مشتری')
GO
SET IDENTITY_INSERT [dbo].[TblBookingStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[TblCustomer] ON 
GO
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (13, N'علی', N'موذن صفایی', 1, N'اصفهان', N'3136676755', N'9332350909', N'alisafaie@gmail.com', N'1290795274 ', 0, 1, CAST(N'1983-09-03' AS Date), CAST(N'2014-02-18' AS Date), 1, 0, NULL, CAST(N'2019-01-13T20:37:11.500' AS DateTime), NULL)
GO
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (14, N'علی', N'مؤذن صفایی', 1, N'اصفهان، خ هفت دست شرقی', N'3136676755', N'9133138675', N'', N'1290795274 ', 0, 0, CAST(N'1983-09-03' AS Date), NULL, 1, 0, NULL, CAST(N'2019-02-26T17:53:39.973' AS DateTime), NULL)
GO
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (15, N'کوشا', N'کیانی فلاورجانی', 0, N'', N'3132337738', N'9999999999', N'', N'           ', NULL, 0, CAST(N'1987-06-01' AS Date), NULL, NULL, 0, NULL, CAST(N'2019-02-28T11:32:38.573' AS DateTime), NULL)
GO
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (16, N'علی', N'احمدی', 1, N'', N'3136676755', N'9888888888', N'', N'           ', NULL, 0, CAST(N'1974-09-03' AS Date), NULL, NULL, 0, NULL, NULL, CAST(N'2019-03-02T13:21:21.633' AS DateTime))
GO
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (17, N'علی', N'احمدیان', 0, N'', N'3136676755', N'9777777777', N'', N'           ', 0, 0, NULL, NULL, 1, 0, NULL, CAST(N'2019-01-17T17:37:42.633' AS DateTime), NULL)
GO
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (18, N'عزیز', N'عزیزی', 1, N'', N'3136676855', N'9666666665', N'aziz@azizian.com', N'           ', NULL, 0, CAST(N'1983-09-03' AS Date), NULL, NULL, 0, NULL, NULL, CAST(N'2019-03-02T12:49:43.003' AS DateTime))
GO
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (19, N'کوشا', N'کیانی اصفهانی', 0, N'', N'3136676755', N'9131666288', N'kooshakiani@yahoo.com', N'           ', NULL, 0, CAST(N'1987-06-01' AS Date), NULL, NULL, 0, NULL, NULL, CAST(N'2019-03-02T18:52:18.700' AS DateTime))
GO
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (20, N'علی', N'کیانی', 0, N'', N'3136249500', N'9131152123', N'', N'           ', 0, 0, CAST(N'1958-05-03' AS Date), NULL, 1, 0, NULL, CAST(N'2019-02-27T19:30:46.880' AS DateTime), NULL)
GO
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (21, N'احسان', N'بابائی', 1, N'', N'3132352553', N'9131684870', N'', N'           ', NULL, 0, CAST(N'1981-07-27' AS Date), NULL, NULL, 0, NULL, NULL, CAST(N'2019-03-12T10:06:32.730' AS DateTime))
GO
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (22, N'حسین', N'موذن صفایی', 1, N'', N'3132337738', N'9131188156', N'', N'           ', NULL, 0, CAST(N'1948-12-23' AS Date), NULL, NULL, 0, NULL, CAST(N'2019-03-07T21:36:19.823' AS DateTime), NULL)
GO
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (23, N'زهرا', N'فلفلیان', 0, N'', N'3132337738', N'9133081799', N'', N'           ', NULL, 1, NULL, NULL, NULL, 0, NULL, CAST(N'2019-03-07T21:54:34.607' AS DateTime), NULL)
GO
INSERT [dbo].[TblCustomer] ([Id], [FirstName], [LastName], [Gender], [Address], [Tell], [Mobile], [Email], [NationalId], [CustomerType], [IsMarried], [BirthDate], [WeddingDate], [IsActive], [IsDeleted], [Submitter], [CreatedDate], [ModifiedDate]) VALUES (24, N'حمیدرضا', N'خباز', 1, N'', N'3134510265', N'9123365946', N'', N'           ', NULL, 0, NULL, NULL, NULL, 0, NULL, CAST(N'2019-03-09T12:41:29.890' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[TblCustomer] OFF
GO
SET IDENTITY_INSERT [dbo].[TblOrderStatus] ON 
GO
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (3, 10, N'ورود به آتلیه')
GO
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (4, 20, N'بارگزاری عکس')
GO
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (5, 30, N'انتخاب عکس و سایز')
GO
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (6, 40, N'انتخاب آلبوم و خدمات ')
GO
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (8, 50, N'تعیین اولویت')
GO
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (9, 60, N'در حال پردازش')
GO
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (10, 70, N'بازبینی عکس')
GO
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (11, 80, N'در حال چاپ')
GO
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (12, 90, N'خدمات اضافه')
GO
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (13, 100, N'ساخت آلبوم')
GO
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (14, 110, N'تائید مالی')
GO
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (15, 120, N'تحویل به مشتری')
GO
INSERT [dbo].[TblOrderStatus] ([Id], [Code], [Name]) VALUES (16, 130, N'راکد')
GO
SET IDENTITY_INSERT [dbo].[TblOrderStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[TblPhotographyType] ON 
GO
INSERT [dbo].[TblPhotographyType] ([Id], [Code], [TypeName]) VALUES (1, 10, N'پرسنلی')
GO
INSERT [dbo].[TblPhotographyType] ([Id], [Code], [TypeName]) VALUES (2, 20, N'کودک')
GO
INSERT [dbo].[TblPhotographyType] ([Id], [Code], [TypeName]) VALUES (3, 30, N'خانوادگی')
GO
INSERT [dbo].[TblPhotographyType] ([Id], [Code], [TypeName]) VALUES (4, 40, N'نامزدی')
GO
INSERT [dbo].[TblPhotographyType] ([Id], [Code], [TypeName]) VALUES (5, 50, N'جشن')
GO
SET IDENTITY_INSERT [dbo].[TblPhotographyType] OFF
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
/****** Object:  StoredProcedure [dbo].[usp_CreateCustomerFinancialDirectory]    Script Date: 3/12/2019 7:05:59 PM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_CreateFileTableFile]    Script Date: 3/12/2019 7:05:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/************************************************************
 * Code formatted by SoftTree SQL Assistant © v9.5.444
 * Time: 1397/12/01 20:42:47
 ************************************************************/

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
/****** Object:  StoredProcedure [dbo].[usp_CreateMonthFolder]    Script Date: 3/12/2019 7:05:59 PM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_CreateYearFolder]    Script Date: 3/12/2019 7:05:59 PM ******/
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
        FROM Photos AS p
        WHERE p.name = @parent_name AND p.path_locator.GetLevel() = @parent_level AND p.is_directory = 1;
        
        /********************************************/
        
        IF(@parent_path_locator IS NOT NULL)
            BEGIN
                SET @existPath =(SELECT file_stream.GetFileNamespacePath(1, 2) FROM photos WHERE NAME = @name);
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
                        
                        INSERT INTO Photos (NAME, path_locator, is_directory) VALUES (@name, @path_locator, 1);
                        
                        SET @returnValue =(SELECT file_stream.GetFileNamespacePath(1, 2) FROM photos WHERE NAME = @name);
					END;
			END;
            ELSE
            BEGIN
                RAISERROR('The parent name does not exists', 16, 1);
                SET @returnValue=NULL                
            END;
            SELECT @returnValue AS 'StreamPath'
    END;
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'stream_id مربوط به فولدر ذخیره می شود' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TblOrder', @level2type=N'COLUMN',@level2name=N'OrdefFolderStreamId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'اطلاعات مربوط به فولدر ذخیره می شود.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TblOrder', @level2type=N'COLUMN',@level2name=N'OrdefFolderPathLocator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'اطلاعات مربوط به فولدر ذخیره می شود.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TblOrder', @level2type=N'COLUMN',@level2name=N'OrdefFolderParentPathLocator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'اضافه چاپ یا اصل چاپ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TblOrderPrint', @level2type=N'COLUMN',@level2name=N'OrderType'
GO
USE [master]
GO
ALTER DATABASE [PhotographyAutomationDB] SET  READ_WRITE 
GO
