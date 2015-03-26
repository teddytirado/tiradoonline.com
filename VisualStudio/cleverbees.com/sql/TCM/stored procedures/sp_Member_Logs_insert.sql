IF EXISTS (SELECT 1 FROM SYSOBJECTS WHERE ID = OBJECT_ID('sp_Member_Logs_insert'))
	DROP PROCEDURE sp_Member_Logs_insert;
GO

CREATE PROCEDURE sp_Member_Logs_insert
	@NameSpaceName			VARCHAR(100),
	@ClassName				VARCHAR(100),
	@MethodName				VARCHAR(100),
	@ExceptionMessage		VARCHAR(MAX),
	@ExceptionString		VARCHAR(MAX),
	@Comments				VARCHAR(MAX)
AS



	IF NOT EXISTS (SELECT 1 FROM SYSOBJECTS WHERE ID = OBJECT_ID('Member_Logs'))
		BEGIN
			CREATE TABLE Member_Logs
			(
				Member_LogsID			INT IDENTITY (1001, 1) NOT NULL,
				NameSpaceName			VARCHAR(100) NOT NULL,
				ClassName				VARCHAR(100) NOT NULL,
				MethodName				VARCHAR(100) NOT NULL,
				ExceptionMessage		VARCHAR(MAX) NOT NULL,
				ExceptionString			VARCHAR(MAX) NOT NULL,
				Comments				VARCHAR(MAX) NULL,
				create_dt				DATETIME DEFAULT GETDATE() NOT NULL
			);

			-- CREATE Member_Logs PRIMARY KEY
			ALTER TABLE Member_Logs ADD CONSTRAINT PK_Member_Logs_Member_LogsId PRIMARY KEY CLUSTERED (Member_LogsId);
		END


	INSERT INTO Member_Logs
		(NameSpaceName, ClassName, MethodName, ExceptionMessage, ExceptionString, Comments)
	VALUES
		(@NameSpaceName, @ClassName, @MethodName, @ExceptionMessage, @ExceptionString, @Comments);

		
GO

--EXEC sp_Member_Logs_insert 'TCM', 'Logs', 'logs', 'exceptionMessage', 'exceptionString'