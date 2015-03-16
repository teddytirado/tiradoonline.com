IF EXISTS (SELECT NAME FROM sysobjects WHERE NAME = 'Test' AND TYPE = 'U')
DROP TABLE Test;
GO

IF EXISTS (SELECT NAME FROM sysobjects WHERE NAME = 'Test' AND TYPE = 'U')
	DROP TABLE Test;
GO

CREATE TABLE Test
(
	TestID		IDENTITY (1001,1) INT  NOT NULL,
	UserID		 INT  NOT NULL,
	TestTypeID		 INT  NOT NULL,
	TestResultID		 INT  NOT NULL,
	TestDate		 SMALLDATETIME  NOT NULL,
	TestLocation		 VARCHAR(50)  NOT NULL,
	TestComments		 VARCHAR(200)  NULL,
	create_dt		 DATETIME DEFAULT (getdate()) NOT NULL

);
GO




GO


GO

