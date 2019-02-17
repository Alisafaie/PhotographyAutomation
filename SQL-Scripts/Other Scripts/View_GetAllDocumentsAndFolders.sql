/************************************************************
 * Code formatted by SoftTree SQL Assistant © v9.5.444
 * Time: 1397/11/24 12:32:32
 ************************************************************/

CREATE VIEW dbo.View_GetAllDocumentsAndFolders
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