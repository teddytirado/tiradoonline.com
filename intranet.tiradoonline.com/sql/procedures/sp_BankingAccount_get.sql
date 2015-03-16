IF EXISTS (SELECT NAME FROM sysobjects WHERE NAME = 'sp_BankingAccount_get' AND TYPE = 'P')
DROP PROCEDURE sp_BankingAccount_get;
GO




CREATE PROCEDURE [dbo].[sp_BankingAccount_get]
	@UserID 		INT
AS
	
	
	SELECT 
		BankingAccountID,
		BankingAccountName,
		ReceiveEmails
	INTO
		#BankingAccount
	FROM
		BankingAccount
	WHERE
		UserID = @UserID AND
		Active = 1
	ORDER BY
		BankingAccountName;
	
	ALTER TABLE #BankingAccount ADD TotalBanking NUMERIC(9,2) NULL;	

	UPDATE
		#BankingAccount
	SET
		TotalBanking = (SELECT ISNULL(SUM(a.Payment), 0) FROM Banking a WHERE 
					BankingAccountID = #BankingAccount.BankingAccountID OR
					SubBankingAccountID = #BankingAccount.BankingAccountID);
					-- OR
					--#BankingAccount.BankingAccountID IN (SELECT BankingAccountID FROM Banking WHERE BankingAccountID = #BankingAccount.BankingAccountID) OR
					--#BankingAccount.BankingAccountID IN (SELECT BankingAccountID FROM Banking c WHERE SubBankingAccountID = a.BankingAccountID) OR

	SELECT
		* 
	FROM 
		#BankingAccount;
	--UPDATE Banking
		--SET 




GO

