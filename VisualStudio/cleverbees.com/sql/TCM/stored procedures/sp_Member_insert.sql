IF EXISTS (SELECT 1 FROM SYSOBJECTS WHERE OBJECT('ID') = 'sp_Member_insert')
	DROP PROCEDURE sp_Member_insert;
GO

CREATE PROCEDURE sp_Member_insert
	@UserID uniqueidentifier;
	@SchoolID uniqueidentifier;
	@CreateDate datetime,
	@CreateUserId uniqueidentifier,
	@UpdateDate datetime,
	@UpdateUserId uniqueidentifier,
	@UserId uniqueidentifier,
	@FirstName varchar(20),
	@LastName varchar(20),
	@Address1 varchar(50),
	@City varchar(50),
	@State char(2),
	@Zip varchar(12),
	@Phone1 varchar(50),
	@Cell varchar(50),
	@Cell2 varchar(50),
	@IsActive bit,
	@Dob date NULL,
	@FamilyCode varchar(50) NULL

AS
	DECLARE @MemberID 	UNIQUEIDENTIFIER;
	SET @MemberID = NEWID();

	DECLARE @CurrentDate 	DATETIME;
	SET @CurrentDate = GETDATE();


	-- **** CHECK IF Member EXISTS
	SELECT 
		@MemberID = Id
	FROM
		Member
	WHERE
		FirstName = @FirstName
		AND LastName = @LastName
		AND Dob = @Dob;
	);


	IF @MemberID IS NULL;
	(
		SELECT 
			1
		FROM
			Member
		WHERE
			FirstName = @FirstName
			AND LastName = @LastName
			AND Dob = @Dob
	)
		BEGIN			
			BEGIN TRANSACTION transMemberInsert


			-- *** DELETE Members from School_StudentMember 
			--DELETE FROM School_StudentMember WHERE SchoolId = @SchoolId;

			-- *** DELETE Members from School_StudentMember 
			--DELETE FROM Member_School WHERE SchoolId = @SchoolId;


			-- *** CREATE NEW Member

			INSERT INTO Member
			(
				Id,
				CreateDate,
				CreateUserId,
				UpdateDate,
				UpdateUserId,
				UserId,
				FirstName,
				LastName,
				Address1,
				City,
				State,
				Zip,
				Phone1,
				Cell,
				Cell2,
				IsActive,
				Dob,
				FamilyCode
			)
			VALUES
			(
				@MemberID,
				@CurrentDate,
				@UserId,
				@CurrentDate,
				@UserId,
				@UserId,
				@FirstName,
				@LastName,
				@Address1,
				@City,
				@State,
				@Zip,
				@Phone1,
				@Cell,
				@Cell2,
				@IsActive,
				@Dob,
				@FamilyCode
			);


			-- *** DELETE Members from School_StudentMember 
			INSERT INTO School_StudentMember
			(
				SchoolId, StudentMemberId
			)
			VALUES
			(
				@SchoolId, @MemberId
			);

			-- *** DELETE Members from School_StudentMember 
			INSERT INTO Member_School
			(
				MemberId, SchoolID
			)
			VALUES
			(
				@MemberId, @SchoolId
			);

			IF @@ERROR <> 0
				BEGIN
					ROLLBACK TRANSACTION transMemberInsert;
				END
			ELSE
				BEGIN
					COMMIT TRANSACTION transMemberInsert;
				END
		END
	ELSE
		BEGIN
			UPDATE Member SET
			WHERE
				Id = @MemberID;
		END
GO


EXEC sp_Member_insert ''