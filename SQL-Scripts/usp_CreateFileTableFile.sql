/************************************************************
 * Code formatted by SoftTree SQL Assistant � v9.5.444
 * Time: 1397/12/01 20:42:47
 ************************************************************/

ALTER PROCEDURE dbo.usp_CreateFileTableFile
	@name NVARCHAR(255),
	@parent_name NVARCHAR(255) 
	,@parent_level TINYINT
	 --,@insertedItem TABLE OUT
AS
BEGIN
	SET NOCOUNT ON;
	SET XACT_ABORT ON; --When SET XACT_ABORT is ON, if a Transact-SQL statement raises a run-time error,
	                   --the entire transaction is terminated and rolled back.
	                   --https://docs.microsoft.com/en-us/sql/t-sql/statements/set-xact-abort-transact-sql?view=sql-server-2017
	IF @@TRANCOUNT = 0
	BEGIN
	    THROW 51000, 'Stored Proc must be called within a transaction.', 1;
	END;
	DECLARE @parent_path_locator HIERARCHYID;
	DECLARE @temp_id BINARY(16);
	DECLARE @insertedTable TABLE
	        (
	            [streamId] VARCHAR(4000),
	            [name] NVARCHAR(255),
	            [parent_locator] VARCHAR(4000),
	            path_name NVARCHAR(MAX),
	            filestreamTxn VARBINARY(MAX),
	            path_locator_str NVARCHAR(4000)
	        );
	
	-- Find the path_locator of the parent of the new file
	SELECT @parent_path_locator = path_locator
	FROM   Photos AS p
	WHERE  p.name = @parent_name
	       AND path_locator.GetLevel() = @parent_level
	       AND is_directory = 1;
	-- If the parent's path_locator was found
	IF (@parent_path_locator IS NOT NULL)
	BEGIN
	    SET @temp_id = CONVERT(BINARY(16), NEWID());
	    -- Create a new path_locator value that places the new file
	    -- as a child of the parent directory
	    DECLARE @path_locator VARCHAR(675);
	    SET @path_locator = @parent_path_locator.ToString() +
	        CONVERT(VARCHAR(20), CONVERT(BIGINT, SUBSTRING(@temp_id, 1, 6))) + '.' +
	        CONVERT(VARCHAR(20), CONVERT(BIGINT, SUBSTRING(@temp_id, 7, 6))) + '.' +
	        CONVERT(VARCHAR(20), CONVERT(BIGINT, SUBSTRING(@temp_id, 13, 4))) + '/';
	    
	    BEGIN TRY
	    	BEGIN TRAN
	    	INSERT INTO Photos
	    	  (
	    	    NAME,
	    	    file_stream,
	    	    path_locator
	    	  )OUTPUT 
	    	   CAST(INSERTED.[stream_id] AS VARCHAR(4000)), 
	    	   CAST(INSERTED.[name] AS NVARCHAR(255)), 
	    	   CAST(INSERTED.[path_locator] AS VARCHAR(4000)), 
	    	   CAST(INSERTED.file_stream.PathName() AS VARCHAR(4000)), 
	    	   GET_FILESTREAM_TRANSACTION_CONTEXT(), 
	    	   CAST(INSERTED.path_locator AS NVARCHAR(4000))
	    	   INTO @insertedTable
	    	VALUES
	    	  (
	    	    @name,
	    	    0x,
	    	    @path_locator
	    	  );
	    	
	    	
	    	SELECT it.streamId,
	    	       it.name,
	    	       it.parent_locator,
	    	       it.path_name,
	    	       it.filestreamTxn,
	    	       it.path_locator_str
	    	FROM   @insertedTable it
	    	
	    	COMMIT
	    END TRY
	    BEGIN CATCH
	    	PRINT 'Failed to Insert Data';
	    	ROLLBACK
	    END CATCH;
	END;
	ELSE
	BEGIN
		-- Raise error because the specified parent folder does not exist
		RAISERROR(
		    'The parent name does not exist in the FileTable at the specified level.',
		    16,
		    1
		);
	END;
END;