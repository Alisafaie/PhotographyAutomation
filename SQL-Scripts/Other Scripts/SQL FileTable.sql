/************************************************************
 * Code formatted by SoftTree SQL Assistant © v9.5.444
 * Time: 2/4/2019 8:42:22 PM
 ************************************************************/

USE [master]

-- Enable xp_cmdshell 
-- https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/xp-cmdshell-server-configuration-option?view=sql-server-2017
-- To allow advanced options to be changed.  
EXEC sp_configure 'show advanced options',
     1;  
GO  
-- To update the currently configured value for advanced options.  
RECONFIGURE;  
GO  
-- To enable the feature.  
EXEC sp_configure 'xp_cmdshell',
     1;  
GO  
-- To update the currently configured value for this feature.  
RECONFIGURE;  
GO



EXEC xp_cmdshell 'If not exist c:\ExternalAccess MKDIR c:\ExternalAccess';

IF EXISTS (
       SELECT 1
       FROM   sys.databases
       WHERE  NAME = 'ExternalAccess'
   )
BEGIN
    ALTER DATABASE ExternalAccess 
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE ExternalAccess;
END



CREATE DATABASE ExternalAccess
WITH FileStream(
         Non_Transacted_Access = FULL,
         Directory_Name = N'ExternalAccess'
     );



ALTER DATABASE ExternalAccess
ADD FILEGROUP ExternalAccess_FG
CONTAINS FILESTREAM;





ALTER DATABASE ExternalAccess
ADD FILE(
            NAME = N'ExternalAccess_Files',
            FILENAME = N'c:\ExternalAccess\ExternalAccess_Files'
        )
TO FILEGROUP ExternalAccess_FG
GO



USE ExternalAccess
CREATE TABLE ExternalFiles AS FILETABLE
WITH
(
	FILETABLE_DIRECTORY            = N'SharedFiles',
	FILETABLE_COLLATE_FILENAME     = database_default
);
GO


-- https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/xp-cmdshell-server-configuration-option?view=sql-server-2017
-- Disable xp_cmdshell 
-- To disable the feature.  
EXEC sp_configure 'xp_cmdshell', 0;  
GO  
-- To update the currently configured value for this feature.  
RECONFIGURE;  
GO

-- To dissallow advanced options to be changed.
EXEC sp_configure 'show advanced options',
     0;  
GO  
-- To update the currently configured value for advanced options.  
RECONFIGURE;  
GO  
