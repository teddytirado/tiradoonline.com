IF EXISTS (SELECT NAME FROM sysobjects WHERE NAME = 'TestType' AND TYPE = 'U')
DROP TABLE TestType;
GO

IF EXISTS (SELECT NAME FROM sysobjects WHERE NAME = 'TestType' AND TYPE = 'U')
	DROP TABLE TestType;
GO

CREATE TABLE TestType
(
	TestTypeID		IDENTITY (1001,1) INT  NOT NULL,
	UserID		 INT  NOT NULL,
	TestTypeName		 VARCHAR(50)  NOT NULL,
	create_dt		 DATETIME DEFAULT (getdate()) NOT NULL

);
GO




GO


GO

