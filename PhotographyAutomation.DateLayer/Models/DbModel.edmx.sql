
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/27/2019 00:16:26
-- Generated from EDMX file: C:\Users\Dell\Documents\GitHub\PhotographyAutomation\PhotographyAutomation.DateLayer\Models\DbModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PhotographyAutomationDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_TblAlbums_TblPrintSizes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblAlbums] DROP CONSTRAINT [FK_TblAlbums_TblPrintSizes];
GO
IF OBJECT_ID(N'[dbo].[FK_TblAllOrderStatus_TblOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblAllOrderStatus] DROP CONSTRAINT [FK_TblAllOrderStatus_TblOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_TblAllOrderStatus_TblOrderPrint]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblAllOrderStatus] DROP CONSTRAINT [FK_TblAllOrderStatus_TblOrderPrint];
GO
IF OBJECT_ID(N'[dbo].[FK_TblBooking_TblAtelierType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblBooking] DROP CONSTRAINT [FK_TblBooking_TblAtelierType];
GO
IF OBJECT_ID(N'[dbo].[FK_TblBooking_TblBookingStatus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblBooking] DROP CONSTRAINT [FK_TblBooking_TblBookingStatus];
GO
IF OBJECT_ID(N'[dbo].[FK_TblBooking_TblPhotographyType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblBooking] DROP CONSTRAINT [FK_TblBooking_TblPhotographyType];
GO
IF OBJECT_ID(N'[dbo].[FK_TblBooking_TblUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblBooking] DROP CONSTRAINT [FK_TblBooking_TblUser];
GO
IF OBJECT_ID(N'[dbo].[FK_TblCustomerFilePrint_TblPrintSizes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblPrintCustomerFiles] DROP CONSTRAINT [FK_TblCustomerFilePrint_TblPrintSizes];
GO
IF OBJECT_ID(N'[dbo].[FK_TblFilesError_TblBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblFilesError] DROP CONSTRAINT [FK_TblFilesError_TblBooking];
GO
IF OBJECT_ID(N'[dbo].[FK_TblFilesError_TblCustomer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblFilesError] DROP CONSTRAINT [FK_TblFilesError_TblCustomer];
GO
IF OBJECT_ID(N'[dbo].[FK_TblFilesError_TblOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblFilesError] DROP CONSTRAINT [FK_TblFilesError_TblOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_TblOrder_TblBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblOrder] DROP CONSTRAINT [FK_TblOrder_TblBooking];
GO
IF OBJECT_ID(N'[dbo].[FK_TblOrder_TblCustomer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblOrder] DROP CONSTRAINT [FK_TblOrder_TblCustomer];
GO
IF OBJECT_ID(N'[dbo].[FK_TblOrder_TblCustomer1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblOrder] DROP CONSTRAINT [FK_TblOrder_TblCustomer1];
GO
IF OBJECT_ID(N'[dbo].[FK_TblOrder_TblOrderPrint]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblOrderPrint] DROP CONSTRAINT [FK_TblOrder_TblOrderPrint];
GO
IF OBJECT_ID(N'[dbo].[FK_TblOrder_TblOrderStatus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblOrder] DROP CONSTRAINT [FK_TblOrder_TblOrderStatus];
GO
IF OBJECT_ID(N'[dbo].[FK_TblOrder_TblPhotographyType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblOrder] DROP CONSTRAINT [FK_TblOrder_TblPhotographyType];
GO
IF OBJECT_ID(N'[dbo].[FK_TblOrderPrint_TblCustomer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblOrderPrint] DROP CONSTRAINT [FK_TblOrderPrint_TblCustomer];
GO
IF OBJECT_ID(N'[dbo].[FK_TblOrderPrint_TblOrderPrintStatus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblOrderPrint] DROP CONSTRAINT [FK_TblOrderPrint_TblOrderPrintStatus];
GO
IF OBJECT_ID(N'[dbo].[FK_TblOrderPrintChangingElements_TblOrderPrintDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblOrderPrintChangingElements] DROP CONSTRAINT [FK_TblOrderPrintChangingElements_TblOrderPrintDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_TblOrderPrintDetails_TblCustomer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblOrderPrintDetails] DROP CONSTRAINT [FK_TblOrderPrintDetails_TblCustomer];
GO
IF OBJECT_ID(N'[dbo].[FK_TblOrderPrintDetails_TblOrderPrint]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblOrderPrintDetails] DROP CONSTRAINT [FK_TblOrderPrintDetails_TblOrderPrint];
GO
IF OBJECT_ID(N'[dbo].[FK_TblOrderPrintDetails_TblPrintServicePrices]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblOrderPrintDetails] DROP CONSTRAINT [FK_TblOrderPrintDetails_TblPrintServicePrices];
GO
IF OBJECT_ID(N'[dbo].[FK_TblOrderPrintDetails_TblPrintServicePrices_RePrint]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblOrderPrintDetails] DROP CONSTRAINT [FK_TblOrderPrintDetails_TblPrintServicePrices_RePrint];
GO
IF OBJECT_ID(N'[dbo].[FK_TblOrderPrintDetails_TblPrintServices]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblOrderPrintDetails] DROP CONSTRAINT [FK_TblOrderPrintDetails_TblPrintServices];
GO
IF OBJECT_ID(N'[dbo].[FK_TblOrderPrintDetails_TblPrintServices_RePrint]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblOrderPrintDetails] DROP CONSTRAINT [FK_TblOrderPrintDetails_TblPrintServices_RePrint];
GO
IF OBJECT_ID(N'[dbo].[FK_TblOrderPrintDetails_TblPrintSizePrices]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblOrderPrintDetails] DROP CONSTRAINT [FK_TblOrderPrintDetails_TblPrintSizePrices];
GO
IF OBJECT_ID(N'[dbo].[FK_TblOrderPrintDetails_TblPrintSizePrices_RePrint]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblOrderPrintDetails] DROP CONSTRAINT [FK_TblOrderPrintDetails_TblPrintSizePrices_RePrint];
GO
IF OBJECT_ID(N'[dbo].[FK_TblOrderPrintDetails_TblPrintSizes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblOrderPrintDetails] DROP CONSTRAINT [FK_TblOrderPrintDetails_TblPrintSizes];
GO
IF OBJECT_ID(N'[dbo].[FK_TblOrderPrintDetails_TblPrintSizes_RePrint]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblOrderPrintDetails] DROP CONSTRAINT [FK_TblOrderPrintDetails_TblPrintSizes_RePrint];
GO
IF OBJECT_ID(N'[dbo].[FK_TblOrderPrintDetails_TblPrintSpecialServices]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblOrderPrintDetails] DROP CONSTRAINT [FK_TblOrderPrintDetails_TblPrintSpecialServices];
GO
IF OBJECT_ID(N'[dbo].[FK_TblOrderPrintDetails_TblPrintSpecialServices_RePrint]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblOrderPrintDetails] DROP CONSTRAINT [FK_TblOrderPrintDetails_TblPrintSpecialServices_RePrint];
GO
IF OBJECT_ID(N'[dbo].[FK_TblOrderPrintFiles_TblOrderPrint]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblOrderPrintFiles] DROP CONSTRAINT [FK_TblOrderPrintFiles_TblOrderPrint];
GO
IF OBJECT_ID(N'[dbo].[FK_TblOrderPrintLitPrint_TblOrderPrintDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblOrderPrintLitPrint] DROP CONSTRAINT [FK_TblOrderPrintLitPrint_TblOrderPrintDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_TblOrderPrintMultiPhotoOrder_TblOrderPrintDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblOrderPrintMultiPhotoOrder] DROP CONSTRAINT [FK_TblOrderPrintMultiPhotoOrder_TblOrderPrintDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_TblOrderStreams_TblOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblOrderFiles] DROP CONSTRAINT [FK_TblOrderStreams_TblOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_TblPrintServicePrices_TblPrintServices]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblPrintServicePrices] DROP CONSTRAINT [FK_TblPrintServicePrices_TblPrintServices];
GO
IF OBJECT_ID(N'[dbo].[FK_TblPrintServicePrices_TblPrintSizes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblPrintServicePrices] DROP CONSTRAINT [FK_TblPrintServicePrices_TblPrintSizes];
GO
IF OBJECT_ID(N'[dbo].[FK_TblSizePrice_TblPrintSizes1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TblPrintSizePrices] DROP CONSTRAINT [FK_TblSizePrice_TblPrintSizes1];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[TblAlbums]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TblAlbums];
GO
IF OBJECT_ID(N'[dbo].[TblAllOrderStatus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TblAllOrderStatus];
GO
IF OBJECT_ID(N'[dbo].[TblAtelierType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TblAtelierType];
GO
IF OBJECT_ID(N'[dbo].[TblBooking]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TblBooking];
GO
IF OBJECT_ID(N'[dbo].[TblBookingStatus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TblBookingStatus];
GO
IF OBJECT_ID(N'[dbo].[TblCustomer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TblCustomer];
GO
IF OBJECT_ID(N'[dbo].[TblFilesError]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TblFilesError];
GO
IF OBJECT_ID(N'[dbo].[TblOrder]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TblOrder];
GO
IF OBJECT_ID(N'[dbo].[TblOrderFiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TblOrderFiles];
GO
IF OBJECT_ID(N'[dbo].[TblOrderPrint]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TblOrderPrint];
GO
IF OBJECT_ID(N'[dbo].[TblOrderPrintChangingElements]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TblOrderPrintChangingElements];
GO
IF OBJECT_ID(N'[dbo].[TblOrderPrintDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TblOrderPrintDetails];
GO
IF OBJECT_ID(N'[dbo].[TblOrderPrintFiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TblOrderPrintFiles];
GO
IF OBJECT_ID(N'[dbo].[TblOrderPrintLitPrint]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TblOrderPrintLitPrint];
GO
IF OBJECT_ID(N'[dbo].[TblOrderPrintMultiPhotoOrder]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TblOrderPrintMultiPhotoOrder];
GO
IF OBJECT_ID(N'[dbo].[TblOrderPrintStatus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TblOrderPrintStatus];
GO
IF OBJECT_ID(N'[dbo].[TblOrderStatus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TblOrderStatus];
GO
IF OBJECT_ID(N'[dbo].[TblPhotographyType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TblPhotographyType];
GO
IF OBJECT_ID(N'[dbo].[TblPrintCustomerFiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TblPrintCustomerFiles];
GO
IF OBJECT_ID(N'[dbo].[TblPrintServicePrices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TblPrintServicePrices];
GO
IF OBJECT_ID(N'[dbo].[TblPrintServices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TblPrintServices];
GO
IF OBJECT_ID(N'[dbo].[TblPrintSizePrices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TblPrintSizePrices];
GO
IF OBJECT_ID(N'[dbo].[TblPrintSizes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TblPrintSizes];
GO
IF OBJECT_ID(N'[dbo].[TblPrintSpecialServices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TblPrintSpecialServices];
GO
IF OBJECT_ID(N'[PhotographyAutomationDBModelStoreContainer].[View_GetAllPhotos]', 'U') IS NOT NULL
    DROP TABLE [PhotographyAutomationDBModelStoreContainer].[View_GetAllPhotos];
GO
IF OBJECT_ID(N'[PhotographyAutomationDBModelStoreContainer].[View_GetAllPrintSizeAndServicesInfo]', 'U') IS NOT NULL
    DROP TABLE [PhotographyAutomationDBModelStoreContainer].[View_GetAllPrintSizeAndServicesInfo];
GO
IF OBJECT_ID(N'[PhotographyAutomationDBModelStoreContainer].[View_GetDocumentsFolders]', 'U') IS NOT NULL
    DROP TABLE [PhotographyAutomationDBModelStoreContainer].[View_GetDocumentsFolders];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'TblAlbums'
CREATE TABLE [dbo].[TblAlbums] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PrintSizeId] int  NOT NULL,
    [AlbumName] nvarchar(50)  NOT NULL,
    [TotalPages] int  NOT NULL,
    [CoverTypeName] nvarchar(50)  NOT NULL,
    [Color] nvarchar(50)  NOT NULL,
    [Price] int  NOT NULL,
    [Code] varchar(50)  NULL,
    [ManufacturerId] int  NULL
);
GO

-- Creating table 'TblAllOrderStatus'
CREATE TABLE [dbo].[TblAllOrderStatus] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OrderId] int  NOT NULL,
    [OrderPrintId] int  NOT NULL,
    [StatusCode] int  NOT NULL,
    [UserId] int  NOT NULL,
    [CreatedDateTime] datetime  NOT NULL,
    [ModifiedDateTime] datetime  NULL
);
GO

-- Creating table 'TblAtelierType'
CREATE TABLE [dbo].[TblAtelierType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] int  NOT NULL,
    [AtelierName] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'TblBooking'
CREATE TABLE [dbo].[TblBooking] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CustomerId] int  NOT NULL,
    [Date] datetime  NOT NULL,
    [Time] time  NOT NULL,
    [PhotographerGender] tinyint  NOT NULL,
    [PhotographyTypeId] int  NOT NULL,
    [AtelierTypeId] int  NOT NULL,
    [PersonCount] int  NOT NULL,
    [PrepaymentIsOk] tinyint  NOT NULL,
    [Submitter] int  NOT NULL,
    [StatusId] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [ModifiedDate] datetime  NULL
);
GO

-- Creating table 'TblBookingStatus'
CREATE TABLE [dbo].[TblBookingStatus] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] int  NOT NULL,
    [StatusName] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'TblCustomer'
CREATE TABLE [dbo].[TblCustomer] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(200)  NULL,
    [LastName] nvarchar(200)  NULL,
    [Gender] tinyint  NULL,
    [Address] nvarchar(1000)  NULL,
    [Tell] char(10)  NULL,
    [Mobile] char(10)  NULL,
    [Email] varchar(200)  NULL,
    [NationalId] char(11)  NULL,
    [CustomerType] tinyint  NULL,
    [IsMarried] tinyint  NULL,
    [BirthDate] datetime  NULL,
    [WeddingDate] datetime  NULL,
    [IsActive] tinyint  NULL,
    [IsDeleted] tinyint  NULL,
    [Submitter] int  NULL,
    [CreatedDate] datetime  NULL,
    [ModifiedDate] datetime  NULL
);
GO

-- Creating table 'TblFilesError'
CREATE TABLE [dbo].[TblFilesError] (
    [Id] int  NOT NULL,
    [FileName] nvarchar(50)  NULL,
    [DateTime] datetime  NULL,
    [Submitter] int  NULL,
    [OrderId] int  NULL,
    [OrderCode] nvarchar(50)  NULL,
    [CustomerId] int  NULL,
    [BookingId] int  NULL,
    [ErrorInId] int  NULL,
    [ErrorMessage] nvarchar(max)  NULL
);
GO

-- Creating table 'TblOrder'
CREATE TABLE [dbo].[TblOrder] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OrderCode] varchar(50)  NOT NULL,
    [OrderStatusId] int  NOT NULL,
    [BookingId] int  NOT NULL,
    [PhotographyTypeId] int  NOT NULL,
    [CustomerId] int  NOT NULL,
    [PhotographerId] int  NULL,
    [PaymentIsOk] tinyint  NULL,
    [Date] datetime  NULL,
    [Time] time  NULL,
    [OrderFolderStreamId] uniqueidentifier  NULL,
    [OrderFolderPathLocator] nvarchar(max)  NULL,
    [OrderFolderParentPathLocator] nvarchar(max)  NULL,
    [TotalFiles] int  NULL,
    [IsActive] bit  NOT NULL,
    [CreatedDateTime] datetime  NOT NULL,
    [ModifiedDateTime] datetime  NULL,
    [Submitter] int  NULL,
    [UploadDate] datetime  NULL,
    [OrderPrintIssued] bit  NULL,
    [LastOrderPrintCustomerId] int  NULL
);
GO

-- Creating table 'TblOrderFiles'
CREATE TABLE [dbo].[TblOrderFiles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OrderId] int  NOT NULL,
    [StreamId] uniqueidentifier  NOT NULL,
    [FileName] nvarchar(255)  NOT NULL,
    [PathLocator] nvarchar(max)  NOT NULL,
    [UploadDate] datetime  NULL
);
GO

-- Creating table 'TblOrderPrint'
CREATE TABLE [dbo].[TblOrderPrint] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OrderPrintCode] varchar(50)  NOT NULL,
    [OrderId] int  NOT NULL,
    [OrderType] bit  NULL,
    [OrderPrintStatusId] int  NOT NULL,
    [CustomerId] int  NOT NULL,
    [RetochDescriptions] nvarchar(max)  NULL,
    [TotalPhotos] int  NULL,
    [TotalPrice] bigint  NULL,
    [Payment] bigint  NULL,
    [Deposit] bigint  NULL,
    [Remaining] bigint  NULL,
    [IsActive] bit  NOT NULL,
    [CreatedDateTime] datetime  NOT NULL,
    [ModifiedDateTime] datetime  NULL
);
GO

-- Creating table 'TblOrderPrintFiles'
CREATE TABLE [dbo].[TblOrderPrintFiles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OrderPrintId] int  NOT NULL,
    [FileName] nvarchar(255)  NOT NULL,
    [PathLocator] nvarchar(max)  NOT NULL,
    [CollectDate] datetime  NULL
);
GO

-- Creating table 'TblOrderPrintStatus'
CREATE TABLE [dbo].[TblOrderPrintStatus] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] int  NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'TblOrderStatus'
CREATE TABLE [dbo].[TblOrderStatus] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] int  NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'TblPhotographyType'
CREATE TABLE [dbo].[TblPhotographyType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] int  NOT NULL,
    [TypeName] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'TblPrintCustomerFiles'
CREATE TABLE [dbo].[TblPrintCustomerFiles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PrintSizeId] int  NOT NULL,
    [Price] int  NOT NULL
);
GO

-- Creating table 'TblPrintServicePrices'
CREATE TABLE [dbo].[TblPrintServicePrices] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] varchar(10)  NULL,
    [PrintSizeId] int  NOT NULL,
    [PrintServiceId] int  NOT NULL,
    [Price] int  NOT NULL
);
GO

-- Creating table 'TblPrintServices'
CREATE TABLE [dbo].[TblPrintServices] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(50)  NOT NULL,
    [PrintServiceName] nvarchar(50)  NOT NULL,
    [PrintServiceDescription] nvarchar(500)  NULL
);
GO

-- Creating table 'TblPrintSizePrices'
CREATE TABLE [dbo].[TblPrintSizePrices] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PrintSizeId] int  NOT NULL,
    [FirstPrintPrice] int  NULL,
    [RePrintPrice] int  NULL,
    [MedicalPrice] int  NULL,
    [MedicalRePrintPrice] int  NULL,
    [LitPrintPrice] int  NULL,
    [LitPrintRePrintPrice] int  NULL,
    [ScanAndPrintPrice] int  NULL,
    [ScanAndProcessingPrice] int  NULL,
    [ItalianAlbumPagePrice] int  NULL,
    [ItalianAlbumBoundingPrice] int  NULL
);
GO

-- Creating table 'TblPrintSizes'
CREATE TABLE [dbo].[TblPrintSizes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Width] float  NOT NULL,
    [Height] float  NOT NULL,
    [Name] nvarchar(20)  NOT NULL,
    [HasFirstPrint] bit  NOT NULL,
    [HasRePrint] bit  NOT NULL,
    [HasMedicalPhoto] bit  NOT NULL,
    [HasLitPrint] bit  NOT NULL,
    [HasScanAndProcessing] bit  NOT NULL,
    [HasAlbum] bit  NOT NULL,
    [HasItalianAlbum] bit  NOT NULL,
    [IsActive] bit  NOT NULL,
    [IsDeleted] bit  NOT NULL,
    [MinimumOrder] tinyint  NOT NULL,
    [Descriptions] nvarchar(500)  NULL
);
GO

-- Creating table 'TblPrintSpecialServices'
CREATE TABLE [dbo].[TblPrintSpecialServices] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] varchar(50)  NULL,
    [Name] nvarchar(200)  NOT NULL,
    [Price] int  NOT NULL,
    [Description] nvarchar(500)  NULL
);
GO

-- Creating table 'View_GetAllPhotos'
CREATE TABLE [dbo].[View_GetAllPhotos] (
    [StreamId] uniqueidentifier  NOT NULL,
    [FileStream] varbinary(max)  NULL,
    [FileName] nvarchar(255)  NOT NULL,
    [PathLocator] varchar(4000)  NULL,
    [ParentPathLocator] varchar(4000)  NULL,
    [UncPath] nvarchar(4000)  NULL,
    [RelativePath] nvarchar(max)  NULL,
    [FullUncPath] nvarchar(max)  NULL,
    [Level] smallint  NULL,
    [FileType] nvarchar(255)  NULL,
    [FileSize] bigint  NULL,
    [CreationTime] datetimeoffset  NOT NULL,
    [LastWriteTime] datetimeoffset  NOT NULL,
    [LastAccessTime] datetimeoffset  NULL,
    [IsOffline] bit  NOT NULL,
    [IsHidden] bit  NOT NULL,
    [IsReadonly] bit  NOT NULL,
    [IsArchive] bit  NOT NULL,
    [IsSystem] bit  NOT NULL,
    [IsTemporary] bit  NOT NULL
);
GO

-- Creating table 'View_GetAllPrintSizeAndServicesInfo'
CREATE TABLE [dbo].[View_GetAllPrintSizeAndServicesInfo] (
    [PrintSizeId] int  NOT NULL,
    [PrintServiceId] int  NULL,
    [PrintSizePriceId] int  NULL,
    [PrintServicePriceId] int  NULL,
    [PrintSizeName] nvarchar(20)  NOT NULL,
    [PrintServiceName] nvarchar(50)  NULL,
    [PrintServicePrice] int  NULL,
    [FirstPrintPrice] int  NULL,
    [RePrintPrice] int  NULL,
    [HasMedicalPhoto] bit  NOT NULL,
    [MedicalPrice] int  NULL,
    [MedicalRePrintPrice] int  NULL,
    [HasLitPrint] bit  NOT NULL,
    [LitPrintPrice] int  NULL,
    [LitPrintRePrintPrice] int  NULL,
    [HasScanAndProcessing] bit  NOT NULL,
    [ScanAndPrintPrice] int  NULL,
    [ScanAndProcessingPrice] int  NULL,
    [HasItalianAlbum] bit  NOT NULL,
    [ItalianAlbumPagePrice] int  NULL,
    [ItalianAlbumBoundingPrice] int  NULL,
    [IsActive] bit  NOT NULL,
    [IsDeleted] bit  NOT NULL,
    [MinimumOrder] tinyint  NOT NULL,
    [Width] float  NOT NULL,
    [Height] float  NOT NULL
);
GO

-- Creating table 'View_GetDocumentsFolders'
CREATE TABLE [dbo].[View_GetDocumentsFolders] (
    [StreamId] uniqueidentifier  NOT NULL,
    [FileStream] varbinary(max)  NULL,
    [FolderName] nvarchar(255)  NOT NULL,
    [PathLocator] varchar(4000)  NULL,
    [ParentPathLocator] varchar(4000)  NULL,
    [UncPath] nvarchar(4000)  NULL,
    [RelativePath] nvarchar(max)  NULL,
    [FullUncPath] nvarchar(max)  NULL,
    [Level] smallint  NULL,
    [FileType] nvarchar(255)  NULL,
    [FileSize] bigint  NULL,
    [CreationTime] datetimeoffset  NOT NULL,
    [LastWriteTime] datetimeoffset  NOT NULL,
    [LastAccessTime] datetimeoffset  NULL,
    [IsOffline] bit  NOT NULL,
    [IsHidden] bit  NOT NULL,
    [IsReadonly] bit  NOT NULL,
    [IsArchive] bit  NOT NULL,
    [IsSystem] bit  NOT NULL,
    [IsTemporary] bit  NOT NULL,
    [IsDirectory] bit  NOT NULL
);
GO

-- Creating table 'TblOrderPrintChangingElements'
CREATE TABLE [dbo].[TblOrderPrintChangingElements] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OrderPrintDetailsId] int  NULL,
    [MainPhotoStreamId] uniqueidentifier  NULL,
    [StreamId] uniqueidentifier  NULL,
    [MainPhotoFileName] nvarchar(255)  NULL,
    [FileName] nvarchar(255)  NULL,
    [Description] nvarchar(1000)  NULL
);
GO

-- Creating table 'TblOrderPrintLitPrint'
CREATE TABLE [dbo].[TblOrderPrintLitPrint] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OrderPrintDetailsId] int  NULL,
    [MainPhotoStreamId] uniqueidentifier  NULL,
    [StreamId] uniqueidentifier  NULL,
    [MainPhotoFileName] nvarchar(255)  NULL,
    [FileName] nvarchar(255)  NULL,
    [Description] nvarchar(1000)  NULL
);
GO

-- Creating table 'TblOrderPrintMultiPhotoOrder'
CREATE TABLE [dbo].[TblOrderPrintMultiPhotoOrder] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OrderPrintDetailId] int  NULL,
    [MainPhotoStreamId] uniqueidentifier  NULL,
    [StreamId] uniqueidentifier  NULL,
    [MainPhotoFileName] nvarchar(255)  NULL,
    [FileName] nvarchar(255)  NULL,
    [Description] nvarchar(500)  NULL
);
GO

-- Creating table 'TblOrderPrintDetails'
CREATE TABLE [dbo].[TblOrderPrintDetails] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OrderPrintId] int  NOT NULL,
    [StreamId] uniqueidentifier  NOT NULL,
    [CustomerId] int  NOT NULL,
    [FileName] nvarchar(255)  NOT NULL,
    [IsFirstPrint] bit  NULL,
    [HasPrintService] bit  NULL,
    [HasMultiPhoto] bit  NULL,
    [HasLitPrint] bit  NULL,
    [HasChangingElements] bit  NULL,
    [PrintSizeId] int  NULL,
    [PrintSizePriceId] int  NULL,
    [PrintServiceId] int  NULL,
    [PrintServicePriceId] int  NULL,
    [PrintSpecialServiceId] int  NULL,
    [RePrintSequence] int  NULL,
    [HasRePrintPrintService] bit  NULL,
    [HasRePrintMultiPhoto] bit  NULL,
    [HasRePrintLitPrint] bit  NULL,
    [HasRePrintChangingElements] bit  NULL,
    [RePrintPrintSizeId] int  NULL,
    [RePrintPrintSizePriceId] int  NULL,
    [RePrintPrintServiceId] int  NULL,
    [RePrintPrintServicePriceId] int  NULL,
    [RePrintPrintSpecialServiceId] int  NULL,
    [RePrintTotalPrints] int  NULL,
    [RePrintTotalPrintServices] int  NULL,
    [CreatedDateTime] datetime  NOT NULL,
    [ModifiedDateTime] datetime  NULL,
    [RetouchDescription] nvarchar(4000)  NULL,
    [TotalPricePrint] int  NULL,
    [TotalPriceMultiPhoto] int  NULL,
    [TotalPriceLitPrint] int  NULL,
    [TotalPricePrintService] int  NULL,
    [TotalPriceOriginalPrint] int  NULL,
    [TotalPriceRePrint] int  NULL,
    [TotalPriceRePrintMultiPhoto] int  NULL,
    [TotalPriceRePrintLitPrint] int  NULL,
    [TotalPrice] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'TblAlbums'
ALTER TABLE [dbo].[TblAlbums]
ADD CONSTRAINT [PK_TblAlbums]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TblAllOrderStatus'
ALTER TABLE [dbo].[TblAllOrderStatus]
ADD CONSTRAINT [PK_TblAllOrderStatus]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TblAtelierType'
ALTER TABLE [dbo].[TblAtelierType]
ADD CONSTRAINT [PK_TblAtelierType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TblBooking'
ALTER TABLE [dbo].[TblBooking]
ADD CONSTRAINT [PK_TblBooking]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TblBookingStatus'
ALTER TABLE [dbo].[TblBookingStatus]
ADD CONSTRAINT [PK_TblBookingStatus]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TblCustomer'
ALTER TABLE [dbo].[TblCustomer]
ADD CONSTRAINT [PK_TblCustomer]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TblFilesError'
ALTER TABLE [dbo].[TblFilesError]
ADD CONSTRAINT [PK_TblFilesError]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TblOrder'
ALTER TABLE [dbo].[TblOrder]
ADD CONSTRAINT [PK_TblOrder]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TblOrderFiles'
ALTER TABLE [dbo].[TblOrderFiles]
ADD CONSTRAINT [PK_TblOrderFiles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TblOrderPrint'
ALTER TABLE [dbo].[TblOrderPrint]
ADD CONSTRAINT [PK_TblOrderPrint]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TblOrderPrintFiles'
ALTER TABLE [dbo].[TblOrderPrintFiles]
ADD CONSTRAINT [PK_TblOrderPrintFiles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TblOrderPrintStatus'
ALTER TABLE [dbo].[TblOrderPrintStatus]
ADD CONSTRAINT [PK_TblOrderPrintStatus]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TblOrderStatus'
ALTER TABLE [dbo].[TblOrderStatus]
ADD CONSTRAINT [PK_TblOrderStatus]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TblPhotographyType'
ALTER TABLE [dbo].[TblPhotographyType]
ADD CONSTRAINT [PK_TblPhotographyType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TblPrintCustomerFiles'
ALTER TABLE [dbo].[TblPrintCustomerFiles]
ADD CONSTRAINT [PK_TblPrintCustomerFiles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TblPrintServicePrices'
ALTER TABLE [dbo].[TblPrintServicePrices]
ADD CONSTRAINT [PK_TblPrintServicePrices]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TblPrintServices'
ALTER TABLE [dbo].[TblPrintServices]
ADD CONSTRAINT [PK_TblPrintServices]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TblPrintSizePrices'
ALTER TABLE [dbo].[TblPrintSizePrices]
ADD CONSTRAINT [PK_TblPrintSizePrices]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TblPrintSizes'
ALTER TABLE [dbo].[TblPrintSizes]
ADD CONSTRAINT [PK_TblPrintSizes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TblPrintSpecialServices'
ALTER TABLE [dbo].[TblPrintSpecialServices]
ADD CONSTRAINT [PK_TblPrintSpecialServices]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [StreamId], [FileName], [CreationTime], [LastWriteTime], [IsOffline], [IsHidden], [IsReadonly], [IsArchive], [IsSystem], [IsTemporary] in table 'View_GetAllPhotos'
ALTER TABLE [dbo].[View_GetAllPhotos]
ADD CONSTRAINT [PK_View_GetAllPhotos]
    PRIMARY KEY CLUSTERED ([StreamId], [FileName], [CreationTime], [LastWriteTime], [IsOffline], [IsHidden], [IsReadonly], [IsArchive], [IsSystem], [IsTemporary] ASC);
GO

-- Creating primary key on [PrintSizeId], [PrintSizeName], [HasMedicalPhoto], [HasLitPrint], [HasScanAndProcessing], [HasItalianAlbum], [IsActive], [IsDeleted], [MinimumOrder], [Width], [Height] in table 'View_GetAllPrintSizeAndServicesInfo'
ALTER TABLE [dbo].[View_GetAllPrintSizeAndServicesInfo]
ADD CONSTRAINT [PK_View_GetAllPrintSizeAndServicesInfo]
    PRIMARY KEY CLUSTERED ([PrintSizeId], [PrintSizeName], [HasMedicalPhoto], [HasLitPrint], [HasScanAndProcessing], [HasItalianAlbum], [IsActive], [IsDeleted], [MinimumOrder], [Width], [Height] ASC);
GO

-- Creating primary key on [StreamId], [FolderName], [CreationTime], [LastWriteTime], [IsOffline], [IsHidden], [IsReadonly], [IsArchive], [IsSystem], [IsTemporary], [IsDirectory] in table 'View_GetDocumentsFolders'
ALTER TABLE [dbo].[View_GetDocumentsFolders]
ADD CONSTRAINT [PK_View_GetDocumentsFolders]
    PRIMARY KEY CLUSTERED ([StreamId], [FolderName], [CreationTime], [LastWriteTime], [IsOffline], [IsHidden], [IsReadonly], [IsArchive], [IsSystem], [IsTemporary], [IsDirectory] ASC);
GO

-- Creating primary key on [Id] in table 'TblOrderPrintChangingElements'
ALTER TABLE [dbo].[TblOrderPrintChangingElements]
ADD CONSTRAINT [PK_TblOrderPrintChangingElements]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TblOrderPrintLitPrint'
ALTER TABLE [dbo].[TblOrderPrintLitPrint]
ADD CONSTRAINT [PK_TblOrderPrintLitPrint]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TblOrderPrintMultiPhotoOrder'
ALTER TABLE [dbo].[TblOrderPrintMultiPhotoOrder]
ADD CONSTRAINT [PK_TblOrderPrintMultiPhotoOrder]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TblOrderPrintDetails'
ALTER TABLE [dbo].[TblOrderPrintDetails]
ADD CONSTRAINT [PK_TblOrderPrintDetails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PrintSizeId] in table 'TblAlbums'
ALTER TABLE [dbo].[TblAlbums]
ADD CONSTRAINT [FK_TblAlbums_TblPrintSizes]
    FOREIGN KEY ([PrintSizeId])
    REFERENCES [dbo].[TblPrintSizes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblAlbums_TblPrintSizes'
CREATE INDEX [IX_FK_TblAlbums_TblPrintSizes]
ON [dbo].[TblAlbums]
    ([PrintSizeId]);
GO

-- Creating foreign key on [OrderId] in table 'TblAllOrderStatus'
ALTER TABLE [dbo].[TblAllOrderStatus]
ADD CONSTRAINT [FK_TblAllOrderStatus_TblOrder]
    FOREIGN KEY ([OrderId])
    REFERENCES [dbo].[TblOrder]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblAllOrderStatus_TblOrder'
CREATE INDEX [IX_FK_TblAllOrderStatus_TblOrder]
ON [dbo].[TblAllOrderStatus]
    ([OrderId]);
GO

-- Creating foreign key on [OrderPrintId] in table 'TblAllOrderStatus'
ALTER TABLE [dbo].[TblAllOrderStatus]
ADD CONSTRAINT [FK_TblAllOrderStatus_TblOrderPrint]
    FOREIGN KEY ([OrderPrintId])
    REFERENCES [dbo].[TblOrderPrint]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblAllOrderStatus_TblOrderPrint'
CREATE INDEX [IX_FK_TblAllOrderStatus_TblOrderPrint]
ON [dbo].[TblAllOrderStatus]
    ([OrderPrintId]);
GO

-- Creating foreign key on [AtelierTypeId] in table 'TblBooking'
ALTER TABLE [dbo].[TblBooking]
ADD CONSTRAINT [FK_TblBooking_TblAtelierType]
    FOREIGN KEY ([AtelierTypeId])
    REFERENCES [dbo].[TblAtelierType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblBooking_TblAtelierType'
CREATE INDEX [IX_FK_TblBooking_TblAtelierType]
ON [dbo].[TblBooking]
    ([AtelierTypeId]);
GO

-- Creating foreign key on [StatusId] in table 'TblBooking'
ALTER TABLE [dbo].[TblBooking]
ADD CONSTRAINT [FK_TblBooking_TblBookingStatus]
    FOREIGN KEY ([StatusId])
    REFERENCES [dbo].[TblBookingStatus]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblBooking_TblBookingStatus'
CREATE INDEX [IX_FK_TblBooking_TblBookingStatus]
ON [dbo].[TblBooking]
    ([StatusId]);
GO

-- Creating foreign key on [PhotographyTypeId] in table 'TblBooking'
ALTER TABLE [dbo].[TblBooking]
ADD CONSTRAINT [FK_TblBooking_TblPhotographyType]
    FOREIGN KEY ([PhotographyTypeId])
    REFERENCES [dbo].[TblPhotographyType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblBooking_TblPhotographyType'
CREATE INDEX [IX_FK_TblBooking_TblPhotographyType]
ON [dbo].[TblBooking]
    ([PhotographyTypeId]);
GO

-- Creating foreign key on [CustomerId] in table 'TblBooking'
ALTER TABLE [dbo].[TblBooking]
ADD CONSTRAINT [FK_TblBooking_TblUser]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[TblCustomer]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblBooking_TblUser'
CREATE INDEX [IX_FK_TblBooking_TblUser]
ON [dbo].[TblBooking]
    ([CustomerId]);
GO

-- Creating foreign key on [Id] in table 'TblFilesError'
ALTER TABLE [dbo].[TblFilesError]
ADD CONSTRAINT [FK_TblFilesError_TblBooking]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[TblBooking]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [BookingId] in table 'TblOrder'
ALTER TABLE [dbo].[TblOrder]
ADD CONSTRAINT [FK_TblOrder_TblBooking]
    FOREIGN KEY ([BookingId])
    REFERENCES [dbo].[TblBooking]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblOrder_TblBooking'
CREATE INDEX [IX_FK_TblOrder_TblBooking]
ON [dbo].[TblOrder]
    ([BookingId]);
GO

-- Creating foreign key on [CustomerId] in table 'TblFilesError'
ALTER TABLE [dbo].[TblFilesError]
ADD CONSTRAINT [FK_TblFilesError_TblCustomer]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[TblCustomer]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblFilesError_TblCustomer'
CREATE INDEX [IX_FK_TblFilesError_TblCustomer]
ON [dbo].[TblFilesError]
    ([CustomerId]);
GO

-- Creating foreign key on [CustomerId] in table 'TblOrder'
ALTER TABLE [dbo].[TblOrder]
ADD CONSTRAINT [FK_TblOrder_TblCustomer]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[TblCustomer]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblOrder_TblCustomer'
CREATE INDEX [IX_FK_TblOrder_TblCustomer]
ON [dbo].[TblOrder]
    ([CustomerId]);
GO

-- Creating foreign key on [LastOrderPrintCustomerId] in table 'TblOrder'
ALTER TABLE [dbo].[TblOrder]
ADD CONSTRAINT [FK_TblOrder_TblCustomer1]
    FOREIGN KEY ([LastOrderPrintCustomerId])
    REFERENCES [dbo].[TblCustomer]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblOrder_TblCustomer1'
CREATE INDEX [IX_FK_TblOrder_TblCustomer1]
ON [dbo].[TblOrder]
    ([LastOrderPrintCustomerId]);
GO

-- Creating foreign key on [CustomerId] in table 'TblOrderPrint'
ALTER TABLE [dbo].[TblOrderPrint]
ADD CONSTRAINT [FK_TblOrderPrint_TblCustomer]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[TblCustomer]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblOrderPrint_TblCustomer'
CREATE INDEX [IX_FK_TblOrderPrint_TblCustomer]
ON [dbo].[TblOrderPrint]
    ([CustomerId]);
GO

-- Creating foreign key on [OrderId] in table 'TblFilesError'
ALTER TABLE [dbo].[TblFilesError]
ADD CONSTRAINT [FK_TblFilesError_TblOrder]
    FOREIGN KEY ([OrderId])
    REFERENCES [dbo].[TblOrder]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblFilesError_TblOrder'
CREATE INDEX [IX_FK_TblFilesError_TblOrder]
ON [dbo].[TblFilesError]
    ([OrderId]);
GO

-- Creating foreign key on [OrderId] in table 'TblOrderPrint'
ALTER TABLE [dbo].[TblOrderPrint]
ADD CONSTRAINT [FK_TblOrder_TblOrderPrint]
    FOREIGN KEY ([OrderId])
    REFERENCES [dbo].[TblOrder]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblOrder_TblOrderPrint'
CREATE INDEX [IX_FK_TblOrder_TblOrderPrint]
ON [dbo].[TblOrderPrint]
    ([OrderId]);
GO

-- Creating foreign key on [OrderStatusId] in table 'TblOrder'
ALTER TABLE [dbo].[TblOrder]
ADD CONSTRAINT [FK_TblOrder_TblOrderStatus]
    FOREIGN KEY ([OrderStatusId])
    REFERENCES [dbo].[TblOrderStatus]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblOrder_TblOrderStatus'
CREATE INDEX [IX_FK_TblOrder_TblOrderStatus]
ON [dbo].[TblOrder]
    ([OrderStatusId]);
GO

-- Creating foreign key on [PhotographyTypeId] in table 'TblOrder'
ALTER TABLE [dbo].[TblOrder]
ADD CONSTRAINT [FK_TblOrder_TblPhotographyType]
    FOREIGN KEY ([PhotographyTypeId])
    REFERENCES [dbo].[TblPhotographyType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblOrder_TblPhotographyType'
CREATE INDEX [IX_FK_TblOrder_TblPhotographyType]
ON [dbo].[TblOrder]
    ([PhotographyTypeId]);
GO

-- Creating foreign key on [OrderId] in table 'TblOrderFiles'
ALTER TABLE [dbo].[TblOrderFiles]
ADD CONSTRAINT [FK_TblOrderStreams_TblOrder]
    FOREIGN KEY ([OrderId])
    REFERENCES [dbo].[TblOrder]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblOrderStreams_TblOrder'
CREATE INDEX [IX_FK_TblOrderStreams_TblOrder]
ON [dbo].[TblOrderFiles]
    ([OrderId]);
GO

-- Creating foreign key on [OrderPrintStatusId] in table 'TblOrderPrint'
ALTER TABLE [dbo].[TblOrderPrint]
ADD CONSTRAINT [FK_TblOrderPrint_TblOrderPrintStatus]
    FOREIGN KEY ([OrderPrintStatusId])
    REFERENCES [dbo].[TblOrderPrintStatus]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblOrderPrint_TblOrderPrintStatus'
CREATE INDEX [IX_FK_TblOrderPrint_TblOrderPrintStatus]
ON [dbo].[TblOrderPrint]
    ([OrderPrintStatusId]);
GO

-- Creating foreign key on [OrderPrintId] in table 'TblOrderPrintFiles'
ALTER TABLE [dbo].[TblOrderPrintFiles]
ADD CONSTRAINT [FK_TblOrderPrintFiles_TblOrderPrint]
    FOREIGN KEY ([OrderPrintId])
    REFERENCES [dbo].[TblOrderPrint]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblOrderPrintFiles_TblOrderPrint'
CREATE INDEX [IX_FK_TblOrderPrintFiles_TblOrderPrint]
ON [dbo].[TblOrderPrintFiles]
    ([OrderPrintId]);
GO

-- Creating foreign key on [PrintSizeId] in table 'TblPrintCustomerFiles'
ALTER TABLE [dbo].[TblPrintCustomerFiles]
ADD CONSTRAINT [FK_TblCustomerFilePrint_TblPrintSizes]
    FOREIGN KEY ([PrintSizeId])
    REFERENCES [dbo].[TblPrintSizes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblCustomerFilePrint_TblPrintSizes'
CREATE INDEX [IX_FK_TblCustomerFilePrint_TblPrintSizes]
ON [dbo].[TblPrintCustomerFiles]
    ([PrintSizeId]);
GO

-- Creating foreign key on [PrintServiceId] in table 'TblPrintServicePrices'
ALTER TABLE [dbo].[TblPrintServicePrices]
ADD CONSTRAINT [FK_TblPrintServicePrices_TblPrintServices]
    FOREIGN KEY ([PrintServiceId])
    REFERENCES [dbo].[TblPrintServices]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblPrintServicePrices_TblPrintServices'
CREATE INDEX [IX_FK_TblPrintServicePrices_TblPrintServices]
ON [dbo].[TblPrintServicePrices]
    ([PrintServiceId]);
GO

-- Creating foreign key on [PrintSizeId] in table 'TblPrintServicePrices'
ALTER TABLE [dbo].[TblPrintServicePrices]
ADD CONSTRAINT [FK_TblPrintServicePrices_TblPrintSizes]
    FOREIGN KEY ([PrintSizeId])
    REFERENCES [dbo].[TblPrintSizes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblPrintServicePrices_TblPrintSizes'
CREATE INDEX [IX_FK_TblPrintServicePrices_TblPrintSizes]
ON [dbo].[TblPrintServicePrices]
    ([PrintSizeId]);
GO

-- Creating foreign key on [PrintSizeId] in table 'TblPrintSizePrices'
ALTER TABLE [dbo].[TblPrintSizePrices]
ADD CONSTRAINT [FK_TblSizePrice_TblPrintSizes1]
    FOREIGN KEY ([PrintSizeId])
    REFERENCES [dbo].[TblPrintSizes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblSizePrice_TblPrintSizes1'
CREATE INDEX [IX_FK_TblSizePrice_TblPrintSizes1]
ON [dbo].[TblPrintSizePrices]
    ([PrintSizeId]);
GO

-- Creating foreign key on [CustomerId] in table 'TblOrderPrintDetails'
ALTER TABLE [dbo].[TblOrderPrintDetails]
ADD CONSTRAINT [FK_TblOrderPrintDetails_TblCustomer]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[TblCustomer]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblOrderPrintDetails_TblCustomer'
CREATE INDEX [IX_FK_TblOrderPrintDetails_TblCustomer]
ON [dbo].[TblOrderPrintDetails]
    ([CustomerId]);
GO

-- Creating foreign key on [OrderPrintId] in table 'TblOrderPrintDetails'
ALTER TABLE [dbo].[TblOrderPrintDetails]
ADD CONSTRAINT [FK_TblOrderPrintDetails_TblOrderPrint]
    FOREIGN KEY ([OrderPrintId])
    REFERENCES [dbo].[TblOrderPrint]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblOrderPrintDetails_TblOrderPrint'
CREATE INDEX [IX_FK_TblOrderPrintDetails_TblOrderPrint]
ON [dbo].[TblOrderPrintDetails]
    ([OrderPrintId]);
GO

-- Creating foreign key on [OrderPrintDetailsId] in table 'TblOrderPrintChangingElements'
ALTER TABLE [dbo].[TblOrderPrintChangingElements]
ADD CONSTRAINT [FK_TblOrderPrintChangingElements_TblOrderPrintDetails]
    FOREIGN KEY ([OrderPrintDetailsId])
    REFERENCES [dbo].[TblOrderPrintDetails]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblOrderPrintChangingElements_TblOrderPrintDetails'
CREATE INDEX [IX_FK_TblOrderPrintChangingElements_TblOrderPrintDetails]
ON [dbo].[TblOrderPrintChangingElements]
    ([OrderPrintDetailsId]);
GO

-- Creating foreign key on [PrintServicePriceId] in table 'TblOrderPrintDetails'
ALTER TABLE [dbo].[TblOrderPrintDetails]
ADD CONSTRAINT [FK_TblOrderPrintDetails_TblPrintServicePrices]
    FOREIGN KEY ([PrintServicePriceId])
    REFERENCES [dbo].[TblPrintServicePrices]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblOrderPrintDetails_TblPrintServicePrices'
CREATE INDEX [IX_FK_TblOrderPrintDetails_TblPrintServicePrices]
ON [dbo].[TblOrderPrintDetails]
    ([PrintServicePriceId]);
GO

-- Creating foreign key on [RePrintPrintServicePriceId] in table 'TblOrderPrintDetails'
ALTER TABLE [dbo].[TblOrderPrintDetails]
ADD CONSTRAINT [FK_TblOrderPrintDetails_TblPrintServicePrices_RePrint]
    FOREIGN KEY ([RePrintPrintServicePriceId])
    REFERENCES [dbo].[TblPrintServicePrices]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblOrderPrintDetails_TblPrintServicePrices_RePrint'
CREATE INDEX [IX_FK_TblOrderPrintDetails_TblPrintServicePrices_RePrint]
ON [dbo].[TblOrderPrintDetails]
    ([RePrintPrintServicePriceId]);
GO

-- Creating foreign key on [PrintServiceId] in table 'TblOrderPrintDetails'
ALTER TABLE [dbo].[TblOrderPrintDetails]
ADD CONSTRAINT [FK_TblOrderPrintDetails_TblPrintServices]
    FOREIGN KEY ([PrintServiceId])
    REFERENCES [dbo].[TblPrintServices]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblOrderPrintDetails_TblPrintServices'
CREATE INDEX [IX_FK_TblOrderPrintDetails_TblPrintServices]
ON [dbo].[TblOrderPrintDetails]
    ([PrintServiceId]);
GO

-- Creating foreign key on [RePrintPrintServiceId] in table 'TblOrderPrintDetails'
ALTER TABLE [dbo].[TblOrderPrintDetails]
ADD CONSTRAINT [FK_TblOrderPrintDetails_TblPrintServices_RePrint]
    FOREIGN KEY ([RePrintPrintServiceId])
    REFERENCES [dbo].[TblPrintServices]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblOrderPrintDetails_TblPrintServices_RePrint'
CREATE INDEX [IX_FK_TblOrderPrintDetails_TblPrintServices_RePrint]
ON [dbo].[TblOrderPrintDetails]
    ([RePrintPrintServiceId]);
GO

-- Creating foreign key on [PrintSizePriceId] in table 'TblOrderPrintDetails'
ALTER TABLE [dbo].[TblOrderPrintDetails]
ADD CONSTRAINT [FK_TblOrderPrintDetails_TblPrintSizePrices]
    FOREIGN KEY ([PrintSizePriceId])
    REFERENCES [dbo].[TblPrintSizePrices]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblOrderPrintDetails_TblPrintSizePrices'
CREATE INDEX [IX_FK_TblOrderPrintDetails_TblPrintSizePrices]
ON [dbo].[TblOrderPrintDetails]
    ([PrintSizePriceId]);
GO

-- Creating foreign key on [RePrintPrintSizePriceId] in table 'TblOrderPrintDetails'
ALTER TABLE [dbo].[TblOrderPrintDetails]
ADD CONSTRAINT [FK_TblOrderPrintDetails_TblPrintSizePrices_RePrint]
    FOREIGN KEY ([RePrintPrintSizePriceId])
    REFERENCES [dbo].[TblPrintSizePrices]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblOrderPrintDetails_TblPrintSizePrices_RePrint'
CREATE INDEX [IX_FK_TblOrderPrintDetails_TblPrintSizePrices_RePrint]
ON [dbo].[TblOrderPrintDetails]
    ([RePrintPrintSizePriceId]);
GO

-- Creating foreign key on [PrintSizeId] in table 'TblOrderPrintDetails'
ALTER TABLE [dbo].[TblOrderPrintDetails]
ADD CONSTRAINT [FK_TblOrderPrintDetails_TblPrintSizes]
    FOREIGN KEY ([PrintSizeId])
    REFERENCES [dbo].[TblPrintSizes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblOrderPrintDetails_TblPrintSizes'
CREATE INDEX [IX_FK_TblOrderPrintDetails_TblPrintSizes]
ON [dbo].[TblOrderPrintDetails]
    ([PrintSizeId]);
GO

-- Creating foreign key on [RePrintPrintSizeId] in table 'TblOrderPrintDetails'
ALTER TABLE [dbo].[TblOrderPrintDetails]
ADD CONSTRAINT [FK_TblOrderPrintDetails_TblPrintSizes_RePrint]
    FOREIGN KEY ([RePrintPrintSizeId])
    REFERENCES [dbo].[TblPrintSizes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblOrderPrintDetails_TblPrintSizes_RePrint'
CREATE INDEX [IX_FK_TblOrderPrintDetails_TblPrintSizes_RePrint]
ON [dbo].[TblOrderPrintDetails]
    ([RePrintPrintSizeId]);
GO

-- Creating foreign key on [PrintSpecialServiceId] in table 'TblOrderPrintDetails'
ALTER TABLE [dbo].[TblOrderPrintDetails]
ADD CONSTRAINT [FK_TblOrderPrintDetails_TblPrintSpecialServices]
    FOREIGN KEY ([PrintSpecialServiceId])
    REFERENCES [dbo].[TblPrintSpecialServices]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblOrderPrintDetails_TblPrintSpecialServices'
CREATE INDEX [IX_FK_TblOrderPrintDetails_TblPrintSpecialServices]
ON [dbo].[TblOrderPrintDetails]
    ([PrintSpecialServiceId]);
GO

-- Creating foreign key on [RePrintPrintSpecialServiceId] in table 'TblOrderPrintDetails'
ALTER TABLE [dbo].[TblOrderPrintDetails]
ADD CONSTRAINT [FK_TblOrderPrintDetails_TblPrintSpecialServices_RePrint]
    FOREIGN KEY ([RePrintPrintSpecialServiceId])
    REFERENCES [dbo].[TblPrintSpecialServices]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblOrderPrintDetails_TblPrintSpecialServices_RePrint'
CREATE INDEX [IX_FK_TblOrderPrintDetails_TblPrintSpecialServices_RePrint]
ON [dbo].[TblOrderPrintDetails]
    ([RePrintPrintSpecialServiceId]);
GO

-- Creating foreign key on [OrderPrintDetailsId] in table 'TblOrderPrintLitPrint'
ALTER TABLE [dbo].[TblOrderPrintLitPrint]
ADD CONSTRAINT [FK_TblOrderPrintLitPrint_TblOrderPrintDetails]
    FOREIGN KEY ([OrderPrintDetailsId])
    REFERENCES [dbo].[TblOrderPrintDetails]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblOrderPrintLitPrint_TblOrderPrintDetails'
CREATE INDEX [IX_FK_TblOrderPrintLitPrint_TblOrderPrintDetails]
ON [dbo].[TblOrderPrintLitPrint]
    ([OrderPrintDetailsId]);
GO

-- Creating foreign key on [OrderPrintDetailId] in table 'TblOrderPrintMultiPhotoOrder'
ALTER TABLE [dbo].[TblOrderPrintMultiPhotoOrder]
ADD CONSTRAINT [FK_TblOrderPrintMultiPhotoOrder_TblOrderPrintDetails]
    FOREIGN KEY ([OrderPrintDetailId])
    REFERENCES [dbo].[TblOrderPrintDetails]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TblOrderPrintMultiPhotoOrder_TblOrderPrintDetails'
CREATE INDEX [IX_FK_TblOrderPrintMultiPhotoOrder_TblOrderPrintDetails]
ON [dbo].[TblOrderPrintMultiPhotoOrder]
    ([OrderPrintDetailId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------