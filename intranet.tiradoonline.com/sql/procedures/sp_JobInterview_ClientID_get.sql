IF EXISTS (SELECT NAME FROM sysobjects WHERE NAME = 'sp_JobInterview_ClientID_get' AND TYPE = 'P')
DROP PROCEDURE sp_JobInterview_ClientID_get;
GO




CREATE PROCEDURE [dbo].[sp_JobInterview_ClientID_get]
	@JobCompanyID			INT
AS
	
	
	SELECT
		a.JobCompanyID,
		a.JobCompanyName
	FROM
		JobCompany a
	WHERE
		a.JobCompanyID NOT IN
			(
				SELECT
					JobCompanyID
				FROM
					JobCompany
				WHERE
					UserID = a.UserID AND
					JobCompanyID <> a.JobCompanyID
			)
	ORDER BY
		a.JobCompanyName;


GO

