BEGIN TRANSACTION deleteMembers


		DELETE FROM School_StudentMember;

		DELETE FROM Member_School;

		DELETE FROM Member;


IF @@ERROR <> 0
	BEGIN
		ROLLBACK TRANSACTION deleteMembers;
	END
ELSE
	BEGIN
		COMMIT TRANSACTION deleteMembers;
	END
