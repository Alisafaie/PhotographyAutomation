
/************************************************************
 * Code formatted by SoftTree SQL Assistant © v9.5.444
 * Time: 1397/11/28 21:56:55
 ************************************************************/

CREATE PROC usp_CreateYearFolder @name         NVARCHAR(255), 
                                @parent_name  NVARCHAR(255), 
                                @parent_level TINYINT
AS
    BEGIN
        SET NOCOUNT ON;
        DECLARE @parent_path_locator HIERARCHYID;
        DECLARE @temp_id BINARY(16);
        SELECT @parent_path_locator = path_locator
        FROM Photos AS p
        WHERE p.name = @parent_name
              AND p.path_locator.GetLevel() = @parent_level
              AND p.is_directory = 1;
        IF(@parent_path_locator IS NOT NULL)
            BEGIN
                SET @temp_id = CONVERT(BINARY(16), NEWID());
                DECLARE @path_locator VARCHAR(675);
                SET @path_locator = @parent_path_locator.ToString() + CONVERT(VARCHAR(20), CONVERT(BIGINT, SUBSTRING(@temp_id, 1, 6))) + '.' + CONVERT(VARCHAR(20), CONVERT(BIGINT, SUBSTRING(@temp_id, 7, 6))) + '.' + CONVERT(VARCHAR(20), CONVERT(BIGINT, SUBSTRING(@temp_id, 13, 4))) + '/';
                INSERT INTO Photos
                (NAME, 
                 path_locator, 
                 is_directory
                )
                VALUES
                (@name, 
                 @path_locator, 
                 1
                );
        END
            ELSE
            BEGIN
                RAISERROR('the parent name does not exists', 16, 1);
        END
    END
/*******************************************/
/*               How to Use                */
/*******************************************/
    EXEC usp_CreateYearFolder '1397','Root',1