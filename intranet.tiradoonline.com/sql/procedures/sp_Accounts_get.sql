IF EXISTS (SELECT NAME FROM sysobjects WHERE NAME = 'sp_Accounts_get' AND TYPE = 'P')
DROP PROCEDURE sp_Accounts_get;
GO




-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Accounts_get]
	@UserID				INT,
	@Letter				VARCHAR(3) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	 IF @Letter IS NOT NULL
		SET @Letter = @Letter + '%';

	 IF @Letter IS NOT NULL
		BEGIN
		 IF @Letter = 'ALL'
			SELECT * FROM Accounts WHERE UserID = @UserID AND Active = 1 ORDER BY AccountName;
		 ELSE
			SELECT * FROM Accounts WHERE UserID = @UserID AND LEFT(AccountName, 1) LIKE @Letter AND Active = 1 ORDER BY AccountName;
		END
	ELSE
		SELECT * FROM Accounts WHERE UserID = @UserID  AND Active = 1 ORDER BY AccountName;

END



GO

