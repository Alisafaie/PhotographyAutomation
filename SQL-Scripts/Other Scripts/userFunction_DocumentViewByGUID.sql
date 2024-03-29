
/************************************************************
 * Code formatted by SoftTree SQL Assistant © v9.5.444
 * Time: 1397/11/28 20:23:58
 ************************************************************/

USE [PhotographyAutomationDB];
GO
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
CREATE FUNCTION [dbo].[GetPhotoByGUID]
(@photo_stream_id UNIQUEIDENTIFIER
)
RETURNS TABLE
AS
     RETURN
(
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
    WHERE stream_id = @photo_stream_id
);