IF EXISTS (SELECT NAME FROM sysobjects WHERE NAME = 'Reminders' AND TYPE = 'U')
DROP TABLE Reminders;
GO

IF EXISTS (SELECT NAME FROM sysobjects WHERE NAME = 'Reminders' AND TYPE = 'U')
	DROP TABLE Reminders;
GO

CREATE TABLE Reminders
(
	ReminderID		IDENTITY (1000,1) INT  NOT NULL,
	UserID		 INT  NOT NULL,
	ReminderDate		 SMALLDATETIME  NULL,
	ReminderDesc		 VARCHAR(100)  NOT NULL,
	create_dt		 SMALLDATETIME DEFAULT (getdate()) NOT NULL

);
GO




GO


GO

