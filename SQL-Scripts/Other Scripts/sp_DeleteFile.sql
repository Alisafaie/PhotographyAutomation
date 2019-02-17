USE [PhotographyAutomationDB]
GO
/****** Object:  StoredProcedure [dbo].[DeleteFile]    Script Date: 1397/11/28 19:36:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[DeleteFile] @stream_id UNIQUEIDENTIFIER
AS
     DELETE FROM dbo.Documents
     WHERE dbo.Documents.stream_id = @stream_id;
