USE [master]
GO
/****** Object:  Database [PhotographyAutomationDB]    Script Date: 1397/11/24 22:58:07 ******/
CREATE DATABASE [PhotographyAutomationDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PhotographyAutomationDB', FILENAME = N'C:\SQL-2017\Data\PhotographyAutomationDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB ), 
 FILEGROUP [PhotoArchive_FG1] CONTAINS FILESTREAM  DEFAULT
( NAME = N'PhotoArchive_1', FILENAME = N'c:\PhotographyAutomation_FileStores\PhotoArchive_1' , MAXSIZE = UNLIMITED)
 LOG ON 
( NAME = N'PhotographyAutomationDB_log', FILENAME = N'C:\SQL-2017\Data\PhotographyAutomationDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
ALTER DATABASE [PhotographyAutomationDB] SET QUERY_STORE = OFF
GO
USE [PhotographyAutomationDB]
GO
/****** Object:  Table [dbo].[Documents]    Script Date: 1397/11/24 22:58:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ARITHABORT ON
GO
CREATE TABLE [dbo].[Documents] AS FILETABLE ON [PRIMARY] FILESTREAM_ON [PhotoArchive_FG1]
WITH
(
FILETABLE_DIRECTORY = N'Documents', FILETABLE_COLLATE_FILENAME = Persian_100_CI_AI
)
GO
/****** Object:  View [dbo].[GetAllDocuments]    Script Date: 1397/11/24 22:58:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[GetAllDocuments]
AS

SELECT d.stream_id,
       d.file_stream,
       d.name,
       d.path_locator,
       d.parent_path_locator,
       d.file_type,
       d.cached_file_size,
       d.creation_time,
       d.last_write_time,
       d.last_access_time,
       d.is_directory,
       d.is_offline,
       d.is_hidden,
       d.is_readonly
FROM   Documents AS d
GO
/****** Object:  View [dbo].[View_GetAllDocumentsAndFolders]    Script Date: 1397/11/24 22:58:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/************************************************************
 * Code formatted by SoftTree SQL Assistant © v9.5.444
 * Time: 1397/11/24 12:32:32
 ************************************************************/

CREATE VIEW [dbo].[View_GetAllDocumentsAndFolders]
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
       creation_time AS 'CreationTime',
       last_write_time AS 'LastWriteTime',
       last_access_time AS 'LastAccessTime',
       is_directory AS 'IsDirectory',
       is_offline AS 'IsOffline',
       is_hidden AS 'IsHidden',
       is_readonly AS 'IsReadonly',
       is_archive AS 'IsArchive',
       is_system AS 'IsSystem',
       is_temporary AS 'IsTemporary'
FROM   dbo.Documents            AS d;
GO
/****** Object:  View [dbo].[DocumentsView]    Script Date: 1397/11/24 22:58:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[DocumentsView]
AS

SELECT stream_id,
       file_stream,
       NAME,
       is_directory,
       file_stream.PathName() AS unc_path
FROM   dbo.Documents
GO
/****** Object:  UserDefinedFunction [dbo].[DocumentViewByGUID]    Script Date: 1397/11/24 22:58:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[DocumentViewByGUID]
(
	@docId UNIQUEIDENTIFIER
)
RETURNS TABLE
AS
	RETURN(
	    SELECT stream_id,
	           file_stream,
	           NAME,
	           is_directory,
	           file_stream.PathName() AS unc_path
	    FROM   dbo.Documents
	    WHERE  stream_id = @docId
	);
GO
/****** Object:  Table [dbo].[FileDescriptions]    Script Date: 1397/11/24 22:58:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FileDescriptions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](255) NULL,
	[FileId] [nvarchar](50) NULL,
	[Description] [nvarchar](500) NULL,
	[CreatedTimestamp] [datetime] NOT NULL,
	[UpdatedTimestamp] [datetime] NOT NULL,
	[ContentType] [nvarchar](max) NULL,
 CONSTRAINT [PK_FileDescriptions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhotoArchive]    Script Date: 1397/11/24 22:58:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ARITHABORT ON
GO
CREATE TABLE [dbo].[PhotoArchive] AS FILETABLE ON [PRIMARY] FILESTREAM_ON [PhotoArchive_FG1]
WITH
(
FILETABLE_DIRECTORY = N'SharedFiles', FILETABLE_COLLATE_FILENAME = Persian_100_CI_AI
)
GO
/****** Object:  Table [dbo].[TblAtelierType]    Script Date: 1397/11/24 22:58:08 ******/
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
/****** Object:  Table [dbo].[TblBooking]    Script Date: 1397/11/24 22:58:08 ******/
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
/****** Object:  Table [dbo].[TblBookingStatus]    Script Date: 1397/11/24 22:58:08 ******/
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
/****** Object:  Table [dbo].[TblCustomer]    Script Date: 1397/11/24 22:58:08 ******/
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
/****** Object:  Table [dbo].[TblEmployeeType]    Script Date: 1397/11/24 22:58:08 ******/
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
/****** Object:  Table [dbo].[TblEmpRole]    Script Date: 1397/11/24 22:58:08 ******/
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
/****** Object:  Table [dbo].[TblPhotographyType]    Script Date: 1397/11/24 22:58:08 ******/
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
/****** Object:  Table [dbo].[TblRoleType]    Script Date: 1397/11/24 22:58:08 ******/
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
/****** Object:  StoredProcedure [dbo].[AddFile]    Script Date: 1397/11/24 22:58:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AddFile] @stream_id   UNIQUEIDENTIFIER, 
                    @file_stream VARBINARY(MAX), 
                    @filename    NVARCHAR(255)
AS
     INSERT INTO dbo.Documents
     (stream_id, 
      file_stream, 
      name, 
      dbo.Documents.is_directory
     )
     VALUES
     (@stream_id, 
      @file_stream, 
      @filename, 
      0
     );
GO
/****** Object:  StoredProcedure [dbo].[CreateFileTableFile]    Script Date: 1397/11/24 22:58:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/************************************************************
 * Code formatted by SoftTree SQL Assistant © v9.5.444
 * Time: 1397/11/23 12:59:19
 ************************************************************/

CREATE PROCEDURE [dbo].[CreateFileTableFile] @name         NVARCHAR(255), 
                                         @parent_name  NVARCHAR(255), 
                                         @parent_level TINYINT
AS
    BEGIN
        SET NOCOUNT ON;
        DECLARE @parent_path_locator HIERARCHYID;
        DECLARE @temp_id BINARY(16);

        -- Find the path locator of the parent  of the new file
        SELECT @parent_path_locator = path_locator
        FROM Documents AS d
        WHERE d.name = @parent_name
              AND path_locator.GetLevel() = @parent_level
              AND d.is_directory = 1;
        IF(@parent_path_locator IS NOT NULL)
            BEGIN
                SET @temp_id = CONVERT(BINARY(16), NEWID());

                -- Create a new path_locator value that places the new file
                -- as a child of the parent directory

                DECLARE @path_locator VARCHAR(675);
                SET 
					@path_locator = @parent_path_locator.ToString() + 
					CONVERT(VARCHAR(20), CONVERT(BIGINT, SUBSTRING(@temp_id, 1, 6))) + 
					'.' + 
					CONVERT(VARCHAR(20), CONVERT(BIGINT, SUBSTRING(@temp_id, 7, 6))) + 
					'.' + 
					CONVERT(VARCHAR(20), CONVERT(BIGINT, SUBSTRING(@temp_id, 13, 4))) + 
					'/';

                --Insert a new record specifying the new path_locator
               INSERT INTO documents 
                ([name],file_stream,path_locator)
                VALUES
                (@name, 0x, @path_locator);
        END;
            ELSE
            BEGIN
                -- Raise error becuase the specified parent folder does not exist
                RAISERROR('The parent name does not exist in the FileTable as the specified level.', 16, 1);
        END;
    END;
GO
/****** Object:  StoredProcedure [dbo].[DeleteFile]    Script Date: 1397/11/24 22:58:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DeleteFile] @stream_id UNIQUEIDENTIFIER
AS
     DELETE FROM dbo.Documents
     WHERE dbo.Documents.stream_id = @stream_id;
GO
/****** Object:  StoredProcedure [dbo].[Documents_Add]    Script Date: 1397/11/24 22:58:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Documents_Add] (@filename NVARCHAR(255), @filedata VARBINARY(MAX))
AS
	DECLARE @docid UNIQUEIDENTIFIER;
	BEGIN
		SET @docid = NEWID();
		INSERT INTO dbo.Documents
		  (
		    stream_id,
		    file_stream,
		    NAME
		  )
		VALUES
		  (
		    @docId,
		    @filedata,
		    @filename
		  );
		SELECT stream_id,
		       file_stream.PathName() AS unc_path
		FROM   dbo.Documents
		WHERE  stream_id = @docid;
	END
GO
/****** Object:  StoredProcedure [dbo].[Documents_Del]    Script Date: 1397/11/24 22:58:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Documents_Del] (@docId UNIQUEIDENTIFIER)
AS
BEGIN
	SET NOCOUNT ON;
	DELETE 
	FROM   Documents
	WHERE  stream_id = @docId;    
END
GO
/****** Object:  StoredProcedure [dbo].[GetFileByStreamId]    Script Date: 1397/11/24 22:58:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetFileByStreamId] @stream_id UNIQUEIDENTIFIER
AS
     SELECT d.stream_id, 
            d.file_stream
     FROM dbo.Documents d
     WHERE d.stream_id = @stream_id;
GO
/****** Object:  StoredProcedure [dbo].[sp_NewSequentialId]    Script Date: 1397/11/24 22:58:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_NewSequentialId](@Id AS UNIQUEIDENTIFIER OUTPUT)
AS
    BEGIN
        SET NOCOUNT ON;
        DECLARE @NextSequentialId AS TABLE(Id UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL PRIMARY KEY CLUSTERED);
        DECLARE @NewSequentialId AS TABLE
        (Id  UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL
                                         DEFAULT(NEWSEQUENTIALID())
         PRIMARY KEY CLUSTERED(Id), 
         XxX CHAR(1) NOT NULL

        /*DUMMY column*/

        );
        INSERT INTO @NewSequentialId(XxX)
        OUTPUT inserted.Id
               INTO @NextSequentialId(Id)
        VALUES('X');
        SELECT @Id = ROWGUIDCOL
        FROM @NextSequentialId;
    END;
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
         Top = -288
         Left = -1285
      End
      Begin Tables = 
         Begin Table = "d"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 216
               Right = 236
            End
            DisplayFlags = 280
            TopColumn = 9
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 4350
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_GetAllDocumentsAndFolders'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_GetAllDocumentsAndFolders'
GO
USE [master]
GO
ALTER DATABASE [PhotographyAutomationDB] SET  READ_WRITE 
GO
