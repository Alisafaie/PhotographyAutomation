USE [PhotographyAutomationDB]
GO
/****** Object:  StoredProcedure [dbo].[sp_NewSequentialId]    Script Date: 1397/11/28 19:38:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_NewSequentialId](@Id AS UNIQUEIDENTIFIER OUTPUT)
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
