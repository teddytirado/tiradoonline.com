IF EXISTS (SELECT NAME FROM sysobjects WHERE NAME = 'sp_JobCompany_insert' AND TYPE = 'P')
DROP PROCEDURE sp_JobCompany_insert;
GO




CREATE PROCEDURE [dbo].[sp_JobCompany_insert]
	@UserID				INT,
	@JobCompanyName			VARCHAR(50),
	@JobCompanyWebsite		VARCHAR(100),
	@JobCompanyLinkedIn		VARCHAR(500),
	@JobCompanyTwitter		VARCHAR(500),
	@JobCompanyFacebook		VARCHAR(500),
	@JobCompanyGooglePlus		VARCHAR(500),
	@JobCompanyYouTube		VARCHAR(500)
AS
	
	
	INSERT INTO JobCompany 
		(UserID, JobCompanyName, JobCompanyWebsite, JobCompanyLinkedIn, JobCompanyTwitter, JobCompanyFacebook, JobCompanyGooglePlus, JobCompanyYouTube) 
	VALUES
		(@UserID, @JobCompanyName, @JobCompanyWebsite, @JobCompanyLinkedIn, @JobCompanyTwitter, @JobCompanyFacebook, @JobCompanyGooglePlus, @JobCompanyYouTube);

	SELECT @@IDENTITY;


GO

