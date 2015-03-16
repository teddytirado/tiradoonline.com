IF EXISTS (SELECT NAME FROM sysobjects WHERE NAME = 'sp_JobCompany_New_get' AND TYPE = 'P')
DROP PROCEDURE sp_JobCompany_New_get;
GO



CREATE PROCEDURE [dbo].[sp_JobCompany_New_get]
	@UserID				INT
AS

	SELECT TOP 20 
		JobCompanyID,
		Created = create_dt,
		JobCompanyName,
		JobCompanyWebsite,
		TotalAddresses = (SELECT COUNT(*) FROM JobCompanyAddress WHERE JobCompanyID = JobCompany.JobCompanyID),
		TotalContacts = (SELECT COUNT(*) FROM JobCompanyContact WHERE JobCompanyID = JobCompany.JobCompanyID),
		TotalJobs = (SELECT COUNT(*) FROM Jobs WHERE JobCompanyID = JobCompany.JobCompanyID)
	FROM
		JobCompany
	WHERE
		UserID = @UserID
	ORDER BY
		create_dt DESC;





GO

