IF EXISTS (SELECT NAME FROM sysobjects WHERE NAME = 'sp_POP3Email_get' AND TYPE = 'P')
DROP PROCEDURE sp_POP3Email_get;
GO



CREATE PROCEDURE [dbo].[sp_POP3Email_get]
	@POP3EmailID		INT = NULL

AS

	IF @POP3EmailID IS NOT NULL
		BEGIN
		
			SELECT
				*
			FROM
				POP3Email
			WHERE
				POP3EmailID = @POP3EmailID
		END
	ELSE
		BEGIN
		
			SELECT
				*
			FROM
				POP3Email
			ORDER BY 
				create_dt DESC;
		END


GO

