USE [PhotographyAutomationDB]
GO
/****** Object:  StoredProcedure [dbo].[Documents_Del]    Script Date: 1397/11/28 19:37:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Documents_Del] (@docId UNIQUEIDENTIFIER)
AS
BEGIN
	SET NOCOUNT ON;
	DELETE 
	FROM   Documents
	WHERE  stream_id = @docId;    
END