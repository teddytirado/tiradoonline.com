IF EXISTS (SELECT NAME FROM sysobjects WHERE NAME = 'sp_POP3Email_insert' AND TYPE = 'P')
DROP PROCEDURE sp_POP3Email_insert;
GO



CREATE PROCEDURE [dbo].[sp_POP3Email_insert]
	@POP3EmailFolderID		INT,
	@POP3EmailMessageID		VARCHAR(100),
	@POP3EmailMessageDateTime	DATETIME,
	@POP3EmailFromName		VARCHAR(500),
	@POP3EmailFromEmail		VARCHAR(500),
	@POP3EmailSubject		VARCHAR(500),
	@POP3EmailBodyText		VARCHAR(MAX)
AS

	IF NOT EXISTS (SELECT 1 FROM POP3Email WHERE POP3EmailMessageID = @POP3EmailMessageID) AND
		@POP3EmailMessageID IS NOT NULL
		BEGIN
			INSERT INTO POP3Email
				(POP3EmailFolderID, POP3EmailMessageID, POP3EmailMessageDateTime, POP3EmailFromName, POP3EmailFromEmail, POP3EmailSubject, POP3EmailBodyText)
			VALUES
				(@POP3EmailFolderID, @POP3EmailMessageID, @POP3EmailMessageDateTime, @POP3EmailFromName, @POP3EmailFromEmail, @POP3EmailSubject, @POP3EmailBodyText);
		END


GO

