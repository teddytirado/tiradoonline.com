IF EXISTS (SELECT NAME FROM sysobjects WHERE NAME = 'sp_Hospital_update' AND TYPE = 'P')
DROP PROCEDURE sp_Hospital_update;
GO



CREATE PROCEDURE [dbo].[sp_Hospital_update]
	@HospitalID				INT,
	@HospitalName 			VARCHAR(100)
AS
	
	UPDATE Hospital SET
		HospitalName = @HospitalName
	WHERE
		(HospitalID = @HospitalID);

	SELECT @@IDENTITY;



GO

