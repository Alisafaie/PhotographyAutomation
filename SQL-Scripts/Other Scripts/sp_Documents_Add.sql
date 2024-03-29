USE [PhotographyAutomationDB]
GO
/****** Object:  StoredProcedure [dbo].[Documents_Add]    Script Date: 1397/11/28 19:37:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Documents_Add] (@filename NVARCHAR(255), @filedata VARBINARY(MAX))
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
