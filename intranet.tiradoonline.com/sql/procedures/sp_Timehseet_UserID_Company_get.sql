IF EXISTS (SELECT NAME FROM sysobjects WHERE NAME = 'sp_Timehseet_UserID_Company_get' AND TYPE = 'P')
DROP PROCEDURE sp_Timehseet_UserID_Company_get;
GO



CREATE PROCEDURE [dbo].[sp_Timehseet_UserID_Company_get]
	@UserID			INT
AS
	
	SELECT 
		a.TimeSheetCompanyID,
		a.TimeSheetCompanyName,
		TotalTimesheets = (SELECT COUNT(*) FROM Timesheet WHERE TimeSheetCompanyID = a.TimeSheetCompanyID),
		TotalPaychecks = (SELECT COUNT(*) FROM Paychecks WHERE TimesheetCompanyID = a.TimeSheetCompanyID)
	FROM 
		TimeSheetCompany a
	WHERE 
		a.UserID = @UserID
	ORDER BY 
		a.TimeSheetCompanyName;



GO

