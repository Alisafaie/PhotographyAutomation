USE [PhotographyAutomationDB]
GO
/****** Object:  StoredProcedure [dbo].[AddFile]    Script Date: 1397/11/28 19:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[AddFile] @stream_id   UNIQUEIDENTIFIER, 
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
