USE [TCM]
GO
/****** Object:  Table [Member]    Script Date: 3/16/2015 6:24:45 PM ******/

IF EXISTS (SELECT 1 FROM SYSOBJECTS WHERE ID = OBJECT_ID('School_StudentMember'))
	DROP TABLE School_StudentMember;
GO

IF EXISTS (SELECT 1 FROM SYSOBJECTS WHERE ID = OBJECT_ID('Member_School'))
	DROP TABLE Member_School;
GO

IF EXISTS (SELECT 1 FROM SYSOBJECTS WHERE ID = OBJECT_ID('School'))
	DROP TABLE School;
GO

IF EXISTS (SELECT 1 FROM SYSOBJECTS WHERE ID = OBJECT_ID('Member'))
	DROP TABLE Member;
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE TABLE School
(
	Id		UNIQUEIDENTIFIER NOT NULL,
		CONSTRAINT [PK_School] PRIMARY KEY CLUSTERED 
(
	Id ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO

INSERT INTO School
	(Id)
VALUES
	('F2044BE8-635A-4D88-A968-12027BD1CE19');
GO

CREATE TABLE [Member](
	[Id] [uniqueidentifier] NOT NULL,
	[ResourceName] [varchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUserId] [uniqueidentifier] NOT NULL,
	[UpdateDate] [datetime] NOT NULL,
	[UpdateUserId] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[Salutation] [varchar](10) NOT NULL,
	[FirstName] [varchar](20) NOT NULL,
	[MiddleName] [varchar](20) NOT NULL,
	[LastName] [varchar](20) NOT NULL,
	[FullName] [varchar](75) NOT NULL,
	[ScreenName] [varchar](50) NOT NULL,
	[Address1] [varchar](50) NOT NULL,
	[Address2] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[State] [char](2) NOT NULL,
	[Province] [varchar](50) NOT NULL,
	[Zip] [varchar](12) NOT NULL,
	[Country] [varchar](50) NOT NULL,
	[Phone1] [varchar](50) NOT NULL,
	[Phone2] [varchar](50) NOT NULL,
	[Cell] [varchar](50) NOT NULL,
	[Cell2] [varchar](50) NOT NULL,
	[Fax] [varchar](50) NOT NULL,
	[Email1] [varchar](250) NOT NULL,
	[Email2] [varchar](250) NOT NULL,
	[ImageId] [uniqueidentifier] NOT NULL,
	[ImageUrl] [varchar](255) NOT NULL,
	[OriginalImageUrl] [varchar](255) NULL,
	[Status] [tinyint] NOT NULL,
	[StatusMessage] [varchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Dob] [date] NULL,
	[IdNumber] [varchar](50) NOT NULL,
	[Aka] [nvarchar](50) NOT NULL,
	[Grade] [int] NOT NULL,
	[Sex] [char](1) NOT NULL,
	[MustChangePassword] [bit] NOT NULL,
	[CustomField1] [nvarchar](50) NULL,
	[CustomField2] [nvarchar](50) NULL,
	[FamilyCode] [varchar](50) NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Member_School]    Script Date: 3/16/2015 6:24:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Member_School](
	[MemberId] [uniqueidentifier] NOT NULL,
	[SchoolId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Member_School] PRIMARY KEY CLUSTERED 
(
	[MemberId] ASC,
	[SchoolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  Table [School_StudentMember]    Script Date: 3/16/2015 6:24:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [School_StudentMember](
	[SchoolId] [uniqueidentifier] NOT NULL,
	[StudentMemberId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_School_StudentMember] PRIMARY KEY CLUSTERED 
(
	[SchoolId] ASC,
	[StudentMemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
ALTER TABLE [Member] ADD  CONSTRAINT [DF_Member_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [Member] ADD  CONSTRAINT [DF_Member_ResourceName]  DEFAULT ('') FOR [ResourceName]
GO
ALTER TABLE [Member] ADD  CONSTRAINT [DF_Member_CreateDate]  DEFAULT (getutcdate()) FOR [CreateDate]
GO

ALTER TABLE [Member] ADD  CONSTRAINT [DF_Member_CreateUserId]  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [CreateUserId]
GO

ALTER TABLE [Member] ADD  CONSTRAINT [DF_Member_UpdateDate]  DEFAULT (getutcdate()) FOR [UpdateDate]
GO

DECLARE @ID AS UNIQUEIDENTIFIER;
SET @ID = CAST(CAST(0 AS BINARY) AS UNIQUEIDENTIFIER);
ALTER TABLE [Member] ADD  CONSTRAINT [DF_Member_UpdateUserId]  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [UpdateUserId]
GO

DECLARE @ID AS UNIQUEIDENTIFIER;
SET @ID = CAST(CAST(0 AS BINARY) AS UNIQUEIDENTIFIER);
ALTER TABLE [Member] ADD  CONSTRAINT [DF_Member_UserId]  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [UserId]
GO
ALTER TABLE [Member] ADD  CONSTRAINT [DF_Member_Salutation]  DEFAULT ('') FOR [Salutation]
GO
ALTER TABLE [Member] ADD  CONSTRAINT [DF_Member_FullName]  DEFAULT ('') FOR [FullName]
GO
ALTER TABLE [Member] ADD  CONSTRAINT [DF_Member_ScreenName]  DEFAULT ('') FOR [ScreenName]
GO
ALTER TABLE [Member] ADD  CONSTRAINT [DF_Member_Address1]  DEFAULT ('') FOR [Address1]
GO
ALTER TABLE [Member] ADD  CONSTRAINT [DF_Member_Address2]  DEFAULT ('') FOR [Address2]
GO
ALTER TABLE [Member] ADD  CONSTRAINT [DF_Member_City]  DEFAULT ('') FOR [City]
GO
ALTER TABLE [Member] ADD  CONSTRAINT [DF_Member_State]  DEFAULT ('  ') FOR [State]
GO
ALTER TABLE [Member] ADD  CONSTRAINT [DF_Member_Province]  DEFAULT ('') FOR [Province]
GO
ALTER TABLE [Member] ADD  CONSTRAINT [DF_Member_Zip]  DEFAULT ('') FOR [Zip]
GO
ALTER TABLE [Member] ADD  CONSTRAINT [DF_Member_Country]  DEFAULT ('') FOR [Country]
GO
ALTER TABLE [Member] ADD  CONSTRAINT [DF_Member_Phone1]  DEFAULT ('') FOR [Phone1]
GO
ALTER TABLE [Member] ADD  CONSTRAINT [DF_Member_Phone2]  DEFAULT ('') FOR [Phone2]
GO
ALTER TABLE [Member] ADD  CONSTRAINT [DF_Member_Cell]  DEFAULT ('') FOR [Cell]
GO
ALTER TABLE [Member] ADD  CONSTRAINT [DF_Member_Cell2]  DEFAULT ('') FOR [Cell2]
GO
ALTER TABLE [Member] ADD  CONSTRAINT [DF_Member_Fax]  DEFAULT ('') FOR [Fax]
GO
ALTER TABLE [Member] ADD  CONSTRAINT [DF_Member_Email1]  DEFAULT ('') FOR [Email1]
GO
ALTER TABLE [Member] ADD  CONSTRAINT [DF_Member_Email2]  DEFAULT ('') FOR [Email2]
GO
ALTER TABLE [Member] ADD  CONSTRAINT [DF_Member_ImageId]  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [ImageId]
GO
ALTER TABLE [Member] ADD  CONSTRAINT [DF_Member_ImageUrl]  DEFAULT ('') FOR [ImageUrl]
GO
ALTER TABLE [Member] ADD  CONSTRAINT [DF_Member_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [Member] ADD  CONSTRAINT [DF_Member_StatusMessage]  DEFAULT ('') FOR [StatusMessage]
GO
ALTER TABLE [Member] ADD  CONSTRAINT [DF_Member_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [Member] ADD  CONSTRAINT [DF_Member_IdNumber]  DEFAULT ('') FOR [IdNumber]
GO
ALTER TABLE [Member] ADD  CONSTRAINT [DF_Member_Aka]  DEFAULT ('') FOR [Aka]
GO
ALTER TABLE [Member] ADD  CONSTRAINT [DF_Member_Grade]  DEFAULT ((0)) FOR [Grade]
GO
ALTER TABLE [Member] ADD  CONSTRAINT [DF_Member_Sex]  DEFAULT (' ') FOR [Sex]
GO
ALTER TABLE [Member] ADD  CONSTRAINT [DF_Member_MustChangePassword]  DEFAULT ((0)) FOR [MustChangePassword]
GO

DECLARE @ID AS UNIQUEIDENTIFIER;
SET @ID = CAST(CAST(0 AS BINARY) AS UNIQUEIDENTIFIER);
ALTER TABLE [Member_School] ADD  CONSTRAINT [DF_Member_School_MemberId]  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [MemberId]
GO

DECLARE @ID AS UNIQUEIDENTIFIER;
SET @ID = CAST(CAST(0 AS BINARY) AS UNIQUEIDENTIFIER);
ALTER TABLE [Member_School] ADD  CONSTRAINT [DF_Member_School_SchoolId]  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [SchoolId]
GO

DECLARE @ID AS UNIQUEIDENTIFIER;
SET @ID = CAST(CAST(0 AS BINARY) AS UNIQUEIDENTIFIER);
ALTER TABLE [School_StudentMember] ADD  CONSTRAINT [DF_School_StudentMember_SchoolId]  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [SchoolId]
GO

DECLARE @ID AS UNIQUEIDENTIFIER;
SET @ID = CAST(CAST(0 AS BINARY) AS UNIQUEIDENTIFIER);
ALTER TABLE [School_StudentMember] ADD  CONSTRAINT [DF_School_StudentMember_StudentMemberId]  DEFAULT ('00000000-0000-0000-0000-000000000000') FOR [StudentMemberId]
GO
--ALTER TABLE [Member]  WITH NOCHECK ADD  CONSTRAINT [FK_Member_aspnet_Users] FOREIGN KEY([UserId])
--REFERENCES [aspnet_Users] ([UserId])
--GO
--ALTER TABLE [Member] NOCHECK CONSTRAINT [FK_Member_aspnet_Users]
--GO
ALTER TABLE [Member_School]  WITH NOCHECK ADD  CONSTRAINT [FK_Member_School_Member] FOREIGN KEY([MemberId])
REFERENCES [Member] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [Member_School] CHECK CONSTRAINT [FK_Member_School_Member]
GO
ALTER TABLE [Member_School]  WITH NOCHECK ADD  CONSTRAINT [FK_Member_School_School] FOREIGN KEY([SchoolId])
REFERENCES [School] ([Id])
GO
ALTER TABLE [Member_School] NOCHECK CONSTRAINT [FK_Member_School_School]
GO
ALTER TABLE [School_StudentMember]  WITH NOCHECK ADD  CONSTRAINT [FK_School_StudentMember_Member] FOREIGN KEY([StudentMemberId])
REFERENCES [Member] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [School_StudentMember] CHECK CONSTRAINT [FK_School_StudentMember_Member]
GO
ALTER TABLE [School_StudentMember]  WITH NOCHECK ADD  CONSTRAINT [FK_School_StudentMember_School] FOREIGN KEY([SchoolId])
REFERENCES [School] ([Id])
GO
ALTER TABLE [School_StudentMember] NOCHECK CONSTRAINT [FK_School_StudentMember_School]
GO
