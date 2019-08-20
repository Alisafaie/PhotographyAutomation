/************************************************************
 * Code formatted by SoftTree SQL Assistant © v9.2.349
 * Time: 8/20/2019 11:40:18 AM
 ************************************************************/

USE [master]
GO

/****** Object:  Database [PhotographyAutomationDB]    Script Date: 8/18/2019 1:25:46 PM ******/
CREATE DATABASE [PhotographyAutomationDB]
 CONTAINMENT = NONE
 ON  PRIMARY(
                NAME = N'PhotographyAutomationDB',
                FILENAME = N'C:\SQL-2017\Data\PhotographyAutomationDB.mdf',
                SIZE = 8192KB,
                MAXSIZE = UNLIMITED,
                FILEGROWTH = 65536KB
            ), 
 FILEGROUP [PhotoArchive_FG1] CONTAINS FILESTREAM  DEFAULT(
                                                              NAME = N'PhotoArchive_1',
                                                              FILENAME = 
                                                              N'c:\PhotographyAutomation_FileStores\PhotoArchive_1',
                                                              MAXSIZE = UNLIMITED
                                                          )
 LOG ON 
(
    NAME = N'PhotographyAutomationDB_log',
    FILENAME = N'C:\SQL-2017\Data\PhotographyAutomationDB_log.ldf',
    SIZE = 8192KB,
    MAXSIZE = 2048GB,
    FILEGROWTH = 65536KB
)
GO

ALTER DATABASE [PhotographyAutomationDB] ADD FILEGROUP [PhotosFileGroup]
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
BEGIN
    EXEC [PhotographyAutomationDB].[dbo].[sp_fulltext_database] @action = 'enable'
END
GO

ALTER DATABASE [PhotographyAutomationDB] 
SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [PhotographyAutomationDB] 
SET ANSI_NULLS OFF 
GO

ALTER DATABASE [PhotographyAutomationDB] 
SET ANSI_PADDING OFF 
GO

ALTER DATABASE [PhotographyAutomationDB] 
SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [PhotographyAutomationDB] 
SET ARITHABORT OFF 
GO

ALTER DATABASE [PhotographyAutomationDB] 
SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [PhotographyAutomationDB] 
SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [PhotographyAutomationDB] 
SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [PhotographyAutomationDB] 
SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [PhotographyAutomationDB] 
SET CURSOR_DEFAULT GLOBAL 
GO

ALTER DATABASE [PhotographyAutomationDB] 
SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [PhotographyAutomationDB] 
SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [PhotographyAutomationDB] 
SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [PhotographyAutomationDB] 
SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [PhotographyAutomationDB] 
SET DISABLE_BROKER 
GO

ALTER DATABASE [PhotographyAutomationDB] 
SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [PhotographyAutomationDB] 
SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [PhotographyAutomationDB] 
SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [PhotographyAutomationDB] 
SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [PhotographyAutomationDB] 
SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [PhotographyAutomationDB] 
SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [PhotographyAutomationDB] 
SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [PhotographyAutomationDB] 
SET RECOVERY SIMPLE 
GO

ALTER DATABASE [PhotographyAutomationDB] 
SET MULTI_USER 
GO

ALTER DATABASE [PhotographyAutomationDB] 
SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [PhotographyAutomationDB] 
SET DB_CHAINING OFF 
GO

ALTER DATABASE [PhotographyAutomationDB] 
SET FILESTREAM(
        NON_TRANSACTED_ACCESS = FULL,
        DIRECTORY_NAME = N'PhotographyAutomation_FileStores'
    ) 
GO

ALTER DATABASE [PhotographyAutomationDB] 
SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [PhotographyAutomationDB] 
SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [PhotographyAutomationDB] 
SET READ_WRITE 
GO





USE MASTER;
GO
ALTER DATABASE PhotographyAutomationDB
SET SINGLE_USER
    WITH

 ROLLBACK IMMEDIATE;
GO

USE MASTER;  
GO  
ALTER DATABASE PhotographyAutomationDB  
COLLATE Persian_100_CI_AI;  
GO

USE [master]
GO
ALTER DATABASE [PhotographyAutomationDB] SET RECOVERY FULL WITH NO_WAIT
GO

ALTER DATABASE PhotographyAutomationDB
SET MULTI_USER;
GO