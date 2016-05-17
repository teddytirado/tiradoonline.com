IF EXISTS (SELECT NAME FROM sysobjects WHERE NAME = 'CCBalance' AND TYPE = 'U')
DROP TABLE CCBalance;
GO

IF EXISTS (SELECT NAME FROM sysobjects WHERE NAME = 'CCBalance' AND TYPE = 'U')
	DROP TABLE CCBalance;
GO

CREATE TABLE CCBalance
(
	CCBalanceID		IDENTITY (1000,1) INT  NOT NULL,
	CCID		 INT  NOT NULL,
	CCDate		 SMALLDATETIME DEFAULT (getdate()) NOT NULL,
	CCDescription		 VARCHAR(100)  NOT NULL,
	CCPayment		 NUMERIC(9,2) DEFAULT (0) NOT NULL,
	update_dt		 SMALLDATETIME  NOT NULL

);
GO




GO


GO

