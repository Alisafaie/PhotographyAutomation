USE [PhotographyAutomationDB];
GO
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
ALTER PROC [dbo].[usp_CreateCustomerFinancialDirectory] @customerFinancialNumber NVARCHAR(255), 
                                                        @monthNumber             NVARCHAR(255), 
                                                        @parent_level            TINYINT, 
                                                        @returnValue             NVARCHAR(MAX) OUT
AS
    BEGIN
        SET NOCOUNT ON;
        DECLARE @parent_path_locator HIERARCHYID;
        DECLARE @temp_id BINARY(16);
        DECLARE @Exist INT;
        DECLARE @existPath NVARCHAR(MAX);
        SELECT @parent_path_locator = path_locator
        FROM Photos AS p
        WHERE p.name = @monthNumber
              AND p.path_locator.GetLevel() = @parent_level
              AND p.is_directory = 1;
        IF(@parent_path_locator IS NOT NULL)
            BEGIN
                SET @existPath =
                (
                    SELECT file_stream.GetFileNamespacePath(1, 2)
                    FROM photos
                    WHERE NAME = @monthNumber
                );
                IF @existPath <> NULL
                    BEGIN
                        SET @Exist = 1;
                END;
                    ELSE
                    BEGIN
                        SET @Exist = 0;
                        SET @temp_id = CONVERT(BINARY(16), NEWID());
                        DECLARE @path_locator VARCHAR(675);
                        SET @path_locator = @parent_path_locator.ToString() + CONVERT(VARCHAR(20), CONVERT(BIGINT, SUBSTRING(@temp_id, 1, 6))) + '.' + CONVERT(VARCHAR(20), CONVERT(BIGINT, SUBSTRING(@temp_id, 7, 6))) + '.' + CONVERT(VARCHAR(20), CONVERT(BIGINT, SUBSTRING(@temp_id, 13, 4))) + '/';
                        INSERT INTO Photos
                        (NAME, 
                         path_locator, 
                         is_directory
                        )
                        VALUES
                        (@customerFinancialNumber, 
                         @path_locator, 
                         1
                        );
                        SET @returnValue =
                        (
                            SELECT file_stream.GetFileNamespacePath(1, 2)
                            FROM photos
                            WHERE NAME = @customerFinancialNumber
                        );
                END;
        END;
            ELSE
            BEGIN
                RAISERROR('The parent name does not exists', 16, 1);
                SET @returnValue = NULL;
        END;
        SELECT @returnValue AS 'StreamPath';
    END;

        --DECLARE @rValue NVARCHAR(max)
        --    SET @rValue = exec  usp_CreateCustomerFinancialDirectory '1402',            'Root',             1,'';
        --    SELECT @rValue;
        --    UPDATE Photos
        --    SET
        --        name = '2425'
        --    WHERE NAME='New folder'