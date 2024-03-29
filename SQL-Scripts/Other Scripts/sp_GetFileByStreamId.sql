USE [PhotographyAutomationDB]
GO
/****** Object:  StoredProcedure [dbo].[GetFileByStreamId]    Script Date: 1397/11/28 19:37:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[GetFileByStreamId] @stream_id UNIQUEIDENTIFIER
AS
     SELECT d.stream_id, 
            d.file_stream
     FROM dbo.Documents d
     WHERE d.stream_id = @stream_id;
