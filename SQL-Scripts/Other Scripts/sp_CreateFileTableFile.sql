USE [PhotographyAutomationDB]
GO
/****** Object:  StoredProcedure [dbo].[CreateFileTableFile]    Script Date: 1397/11/28 19:36:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[CreateFileTableFile]
	@name NVARCHAR(255),
	@parent_name NVARCHAR(255),
	@parent_level TINYINT
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @parent_path_locator HIERARCHYID;
	DECLARE @temp_id BINARY(16);
	
	-- Find the path locator of the parent  of the new file
	SELECT @parent_path_locator = path_locator
	FROM   Documents AS d
	WHERE  d.name = @parent_name
	       AND path_locator.GetLevel() = @parent_level
	       AND d.is_directory = 1;
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
	    
	    --Insert a new record specifying the new path_locator
	    INSERT INTO documents
	      (
	        [name],
	        file_stream,
	        path_locator
	      )
	    VALUES
	      (
	        @name,
	        0x,
	        @path_locator
	      );
	END;
	ELSE
	BEGIN
		-- Raise error becuase the specified parent folder does not exist
		RAISERROR(
		    'The parent name does not exist in the FileTable as the specified level.',
		    16,
		    1
		);
	END;
END;