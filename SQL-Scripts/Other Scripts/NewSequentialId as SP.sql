CREATE PROCEDURE dbo.sp_NewSequentialId(@Id AS UNIQUEIDENTIFIER OUTPUT)
AS
    BEGIN
        SET NOCOUNT ON;
        DECLARE @NextSequentialId AS TABLE(Id UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL PRIMARY KEY CLUSTERED);
        DECLARE @NewSequentialId AS TABLE
        (Id  UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL
                                         DEFAULT(NEWSEQUENTIALID())
         PRIMARY KEY CLUSTERED(Id), 
         XxX CHAR(1) NOT NULL

        /*DUMMY column*/

        );
        INSERT INTO @NewSequentialId(XxX)
        OUTPUT inserted.Id
               INTO @NextSequentialId(Id)
        VALUES('X');
        SELECT @Id = ROWGUIDCOL
        FROM @NextSequentialId;
    END;
GO



--How to use
--http://www.sqlservercentral.com/scripts/T-SQL/71427/

DECLARE @Id AS UNIQUEIDENTIFIER;
EXECUTE dbo.sp_NewSequentialId 
        @Id = @Id OUTPUT;
PRINT @Id;
GO