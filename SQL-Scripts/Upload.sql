/************************************************************
 * Code formatted by SoftTree SQL Assistant © v9.5.444
 * Time: 1397/11/28 19:10:39
 ************************************************************/

CREATE PROCEDURE uspUploadAnalystReport
	@filename NVARCHAR(150),
	@ext NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON;
	DECLARE @name NVARCHAR(255) = @filename + @ext;
	IF @@TRANCOUNT = 0
	BEGIN
	    THROW 51000, 'Stored Proc must be called within a transaction.', 1;
	END;
	DECLARE @inserted TABLE
	        (
	            path_name NVARCHAR(MAX),
	            filestreamTxn VARBINARY(MAX),
	            path_locator_str NVARCHAR(4000)
	        );
	DECLARE @i INT = 0;
	WHILE 1 = 1
	BEGIN
	    IF EXISTS
	       (
	           SELECT 1
	           FROM   AnalystReports
	           WHERE  NAME = @name
	       )
	    BEGIN
	        SET @i += 1;
	        SET @name = @filename + '_' + CAST(@i AS VARCHAR(50)) + @ext;
	    END;
	    ELSE
	    BEGIN
	    	BREAK;
	    END;
	END;
	INSERT AnalystReports
	  (
	    NAME,
	    file_stream
	  )OUTPUT INSERTED.file_stream.PathName(), 
	   GET_FILESTREAM_TRANSACTION_CONTEXT(), 
	   CAST(INSERTED.path_locator AS NVARCHAR(4000))
	   INTO @inserted
	VALUES
	  (
	    @name,
	    (0x)
	  );
	SELECT *
	FROM   @inserted;
END;