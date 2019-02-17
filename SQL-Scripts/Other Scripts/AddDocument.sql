/************************************************************
 * Code formatted by SoftTree SQL Assistant © v9.5.444
 * Time: 1397/11/25 19:24:09
 ************************************************************/

CREATE PROC [dbo].[AddDocument]
(
    @relativePath VARCHAR(MAX) = NULL,
    @name VARCHAR(512) = NULL,
    @stream VARBINARY(MAX) = NULL,
    @path_locator VARCHAR(4000) = NULL OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @path_Locator_for_file HIERARCHYID;
	SET @path_Locator_for_file = NULL;
	BEGIN TRY
		BEGIN TRAN adddocument;
		DECLARE @directories TABLE
		        (
		            ID INT IDENTITY(1, 1),
		            NAME VARCHAR(MAX),
		            Parent VARCHAR(MAX),
		            Path_Locator HIERARCHYID,
		            seq INT
		        );
		
		-- test input
		IF COALESCE(@name, '') = ''
		   THROW 50001, 'no input name given', 1
		    ;
		
		-- test/create directory
		IF @relativePath IS NOT NULL
		BEGIN
		    DECLARE @rows INT;
		    WITH directories(NAME, Pname, seq)
		    AS (
		        SELECT @relativePath  AS NAME,
		               CASE 
		                    WHEN LEFT(@relativePath, 1) = '\' THEN SUBSTRING(@relativePath, 2, LEN(@relativePath) - 1)
		                    ELSE @relativePath
		               END            AS PName,
		               0              AS seq
		        UNION
		        ALL
		        SELECT CASE 
		                    WHEN CHARINDEX('\', REVERSE(PName)) > 0 THEN RIGHT(PName, CHARINDEX('\', REVERSE(PName)) - 1)
		                    ELSE PName
		               END          AS NAME,
		               CASE 
		                    WHEN CHARINDEX('\', REVERSE(PName)) > 0 THEN LEFT(PName, LEN(PName) - CHARINDEX('\', REVERSE(PName)))
		                    ELSE ''
		               END          AS PName,
		               seq + 1      AS seq
		        FROM   directories     recurs
		        WHERE  PName > ''
		    ),
		    dirs
		    AS (
		        SELECT NAME,
		               PName,
		               LAG(NAME) OVER(ORDER BY seq DESC) AS Parent,
		               ROW_NUMBER() OVER(ORDER BY seq DESC) AS Seq
		        FROM   directories
		        WHERE  seq > 0
		               AND NAME > ''
		    )
		    INSERT INTO @directories
		      (
		        NAME,
		        Parent,
		        Path_Locator,
		        seq
		      )
		    SELECT NAME,
		           Parent,
		           NULL,
		           seq
		    FROM   dirs;
		    SET @rows = @@ROWCOUNT;
		    DECLARE @loop INT;
		    SET @loop = 1;
		    DECLARE @lname VARCHAR(MAX);
		    DECLARE @lparent VARCHAR(MAX);
		    DECLARE @lPath_Locator HIERARCHYID;
		    DECLARE @lParent_Path_Locator HIERARCHYID;
		    DECLARE @lnew_Path_Locator HIERARCHYID;
		    WHILE @loop <= @rows
		    BEGIN
		        SELECT @lPath_Locator = Path_Locator,
		               @lname       = NAME,
		               @lparent     = Parent,
		               @lParent_Path_Locator = NULL
		        FROM   @directories
		        WHERE  ID           = @loop;
		        IF (@lPath_Locator) IS NULL
		        BEGIN
		            IF @lparent IS NOT NULL
		            BEGIN
		                SET @lParent_Path_Locator = (
		                        SELECT path_locator
		                        FROM   @directories
		                        WHERE  id = @loop - 1
		                    );
		                SET @lPath_Locator = (
		                        SELECT path_locator
		                        FROM   dbo.Document
		                        WHERE  NAME = @lName
		                               AND parent_path_locator = @lParent_Path_Locator
		                    );
		                IF @lPath_Locator IS NULL
		                BEGIN
		                    SELECT @lPath_Locator = @lParent_Path_Locator.ToString() + CONVERT(
		                               VARCHAR(20),
		                               CONVERT(BIGINT, SUBSTRING(CONVERT(BINARY(16), NEWID()), 1, 6))
		                           ) + '.' + CONVERT(
		                               VARCHAR(20),
		                               CONVERT(BIGINT, SUBSTRING(CONVERT(BINARY(16), NEWID()), 7, 6))
		                           ) + '.' + CONVERT(
		                               VARCHAR(20),
		                               CONVERT(BIGINT, SUBSTRING(CONVERT(BINARY(16), NEWID()), 13, 4))
		                           ) + '/';
		                    INSERT INTO dbo.Document
		                      (
		                        NAME,
		                        is_directory,
		                        path_locator
		                      )
		                    VALUES
		                      (
		                        @lName,
		                        1,
		                        @lPath_Locator
		                      );
		                END;
		            END;
		        ELSE
		        BEGIN
		            SET @lPath_Locator = (
		                    SELECT path_locator
		                    FROM   dbo.Document
		                    WHERE  NAME = @lName
		                );
		            IF @lPath_Locator IS NULL
		            BEGIN
		                INSERT INTO dbo.Document
		                  (
		                    NAME,
		                    is_directory
		                  )
		                VALUES
		                  (
		                    @lName,
		                    1
		                  );
		                SET @lPath_Locator = (
		                        SELECT path_locator
		                        FROM   dbo.Document
		                        WHERE  NAME = @lName
		                    );
		            END;
		        END;
		        UPDATE @directories
		        SET    Path_Locator     = @lPath_Locator
		        WHERE  ID               = @loop;
		    END;
		    SET @loop = @loop + 1;
		END;
		SET @path_Locator_for_file = @lPath_Locator;
		SELECT @path_Locator_for_file = @lPath_Locator.ToString() + CONVERT(
		           VARCHAR(20),
		           CONVERT(BIGINT, SUBSTRING(CONVERT(BINARY(16), NEWID()), 1, 6))
		       ) + '.' + CONVERT(
		           VARCHAR(20),
		           CONVERT(BIGINT, SUBSTRING(CONVERT(BINARY(16), NEWID()), 7, 6))
		       ) + '.' + CONVERT(
		           VARCHAR(20),
		           CONVERT(BIGINT, SUBSTRING(CONVERT(BINARY(16), NEWID()), 13, 4))
		       ) + '/'; 
		-- create file in subdir 
		INSERT INTO dbo.Document
		  (
		    NAME,
		    file_stream,
		    path_locator
		  )
		SELECT @name,
		       @stream,
		       @path_Locator_for_file;
	END ;
	ELSE
	BEGIN
		-- create file IN ROOT 
		INSERT INTO dbo.Document
		  (
		    NAME,
		    file_stream
		  )
		SELECT @name,
		       @stream;
		SELECT @path_Locator_for_file = path_locator
		FROM   dbo.document
		WHERE  NAME = @name;
	END;
	SET @path_locator = CONVERT(VARCHAR(MAX), @path_Locator_for_file);
	COMMIT TRAN adddocument;
END TRY
BEGIN CATCH
	IF @@TRANCOUNT > 0
	    ROLLBACK TRAN adddocument;
	THROW;
END CATCH;
    END;