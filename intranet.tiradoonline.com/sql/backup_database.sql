DECLARE @DATABASE_NAME					VARCHAR(100);
DECLARE @BACKUP_DEVICE_PATH				VARCHAR(1000);


/*
***** CHANGE THESE VARIABLES ********
*/
SET @DATABASE_NAME		= 'tiradoonline';
SET @BACKUP_DEVICE_PATH		= 'C:\Storage\www\tiradoonline.com\intranet.tiradoonline.com\database\Backups';






DECLARE @SQL						NVARCHAR(1000);
DECLARE @BACKUP_FILE_NAME				VARCHAR(1000);
DECLARE @BACKUP_DATABASE_DEVICE_NAME			VARCHAR(1000);
DECLARE @BACKUP_DATABASE_DEVICE_FILENAME		VARCHAR(1000);
DECLARE @BACKUP_LOG_DEVICE_NAME				VARCHAR(1000);
DECLARE @BACKUP_LOG_DEVICE_FILENAME			VARCHAR(1000);
DECLARE @BACKUP_DATE					DATETIME;
DECLARE @BACKUP_DATE_STRING				VARCHAR(100);
DECLARE @BACKUP_TIME_STRING 				VARCHAR(100);

SET @BACKUP_DATE = GETDATE();
SET @BACKUP_TIME_STRING = '';
SET @BACKUP_DATABASE_DEVICE_NAME = @DATABASE_NAME + '_backup_database_device'
SET @BACKUP_LOG_DEVICE_NAME = @DATABASE_NAME + '_backup_log_device'


SET @SQL = 'ALTER DATABASE ' + @DATABASE_NAME + ' SET RECOVERY FULL;'
PRINT '';
PRINT @SQL;
EXEC(@SQL);

SET @BACKUP_DATE_STRING = '';
SET @BACKUP_DATE_STRING = @BACKUP_DATE_STRING + CONVERT(VARCHAR, DATEPART(MONTH, @BACKUP_DATE));
SET @BACKUP_DATE_STRING = @BACKUP_DATE_STRING + '-' + CONVERT(VARCHAR, DATEPART(DAY, @BACKUP_DATE));
SET @BACKUP_DATE_STRING = @BACKUP_DATE_STRING + '-' + CONVERT(VARCHAR, DATEPART(YEAR, @BACKUP_DATE));


-- CREATE BACKUP DATABASE DEVICE
IF NOT EXISTS (SELECT * FROM MASTER..SYSDEVICES WHERE NAME = @BACKUP_DATABASE_DEVICE_NAME)
	BEGIN
		
		SET @BACKUP_DATABASE_DEVICE_FILENAME = @BACKUP_DEVICE_PATH + '\' + @BACKUP_DATABASE_DEVICE_NAME + '.bak';
		SET @SQL = 'EXEC MASTER..sp_addumpdevice ''disk'', ''' + @BACKUP_DATABASE_DEVICE_NAME + ''', ''' + @BACKUP_DATABASE_DEVICE_FILENAME + ''';';

		BEGIN TRY
			PRINT '';
			PRINT @SQL;
			EXEC(@SQL);
		END TRY
		BEGIN CATCH
			PRINT 'ERROR: ' + @SQL			

			SELECT
			    ERROR_NUMBER() AS ErrorNumber
			    ,ERROR_SEVERITY() AS ErrorSeverity
			    ,ERROR_STATE() AS ErrorState
			    ,ERROR_PROCEDURE() AS ErrorProcedure
			    ,ERROR_LINE() AS ErrorLine
			    ,ERROR_MESSAGE() AS ErrorMessage;		

		END CATCH; 

		SET @SQL = 'BACKUP DATABASE ' + @DATABASE_NAME + ' TO ' + @BACKUP_DATABASE_DEVICE_NAME + ';'
		BEGIN TRY
			PRINT '';
			PRINT @SQL;
			EXEC(@SQL);
		END TRY
		BEGIN CATCH
			PRINT 'ERROR: ' + @SQL			

			SELECT
			    ERROR_NUMBER() AS ErrorNumber
			    ,ERROR_SEVERITY() AS ErrorSeverity
			    ,ERROR_STATE() AS ErrorState
			    ,ERROR_PROCEDURE() AS ErrorProcedure
			    ,ERROR_LINE() AS ErrorLine
			    ,ERROR_MESSAGE() AS ErrorMessage;		

		END CATCH; 
	END

-- CREATE BACKUP DATABASE LOG DEVICE
IF NOT EXISTS (SELECT * FROM MASTER..SYSDEVICES WHERE NAME = @BACKUP_LOG_DEVICE_NAME)
	BEGIN
		SET @BACKUP_LOG_DEVICE_FILENAME = @BACKUP_DEVICE_PATH + '\' + @BACKUP_LOG_DEVICE_NAME + '.bak';
		SET @SQL = 'EXEC MASTER..sp_addumpdevice ''disk'', ''' + @BACKUP_LOG_DEVICE_NAME + ''', ''' + @BACKUP_LOG_DEVICE_FILENAME + ''';';

		BEGIN TRY
			PRINT '';
			PRINT @SQL;
			EXEC(@SQL);

			SELECT
			    ERROR_NUMBER() AS ErrorNumber
			    ,ERROR_SEVERITY() AS ErrorSeverity
			    ,ERROR_STATE() AS ErrorState
			    ,ERROR_PROCEDURE() AS ErrorProcedure
			    ,ERROR_LINE() AS ErrorLine
			    ,ERROR_MESSAGE() AS ErrorMessage;		

		END TRY
		BEGIN CATCH
			PRINT 'ERROR: ' + @SQL			
		END CATCH; 

		SET @SQL = 'BACKUP LOG ' + @DATABASE_NAME + ' TO ' + @BACKUP_LOG_DEVICE_NAME + ';'
		BEGIN TRY
			PRINT '';
			PRINT @SQL;
			EXEC(@SQL);
		END TRY
		BEGIN CATCH
			PRINT 'ERROR: ' + @SQL			

			SELECT
			    ERROR_NUMBER() AS ErrorNumber
			    ,ERROR_SEVERITY() AS ErrorSeverity
			    ,ERROR_STATE() AS ErrorState
			    ,ERROR_PROCEDURE() AS ErrorProcedure
			    ,ERROR_LINE() AS ErrorLine
			    ,ERROR_MESSAGE() AS ErrorMessage;		

		END CATCH; 
	END


SET @BACKUP_FILE_NAME = @BACKUP_DEVICE_PATH + '\' + @DATABASE_NAME + '_' + @BACKUP_DATE_STRING;
DECLARE @SEARCH_TIME_STRING		VARCHAR(100);

SET @SEARCH_TIME_STRING = CONVERT(VARCHAR, DATEPART(YEAR, GETDATE())) + ' ';
SET @BACKUP_TIME_STRING = SUBSTRING(    CONVERT(VARCHAR, @BACKUP_DATE),       CHARINDEX(@SEARCH_TIME_STRING + ' ', CONVERT(VARCHAR, GETDATE())),  LEN(CONVERT(VARCHAR, @BACKUP_DATE)) + 1);
SET @BACKUP_TIME_STRING = REPLACE(@BACKUP_TIME_STRING, @SEARCH_TIME_STRING, '');
SET @BACKUP_TIME_STRING = REPLACE(@BACKUP_TIME_STRING, '   ', '');
SET @BACKUP_TIME_STRING = REPLACE(@BACKUP_TIME_STRING, ':', '_');
SET @BACKUP_TIME_STRING = REPLACE(@BACKUP_TIME_STRING, 'AM', '_AM');
SET @BACKUP_TIME_STRING = REPLACE(@BACKUP_TIME_STRING, 'PM', '_PM');
SET @BACKUP_FILE_NAME = @BACKUP_FILE_NAME + '____' + @BACKUP_TIME_STRING + '.bak';
SET @BACKUP_FILE_NAME = REPLACE(@BACKUP_FILE_NAME, ' ', '_');

SET @SQL = 'BACKUP DATABASE ' + @DATABASE_NAME + ' TO DISK = ''' + @BACKUP_FILE_NAME + ''';';
PRINT '';
PRINT @SQL;
EXEC(@SQL);
