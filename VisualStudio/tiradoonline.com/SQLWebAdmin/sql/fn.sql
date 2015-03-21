SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

-- ================================
-- Created 
--    by: <Author_Name>
--    on: <Creation_Date>
-- Description: <Description>
-- ================================
CREATE FUNCTION <Schema_Name>.<Function_Name>
(
   -- Add the parameters for the function here
   <@Param1> <Data_Type_For_Param1>,
   <@Param2> <Data_Type_For_Param2>
)
RETURNS <Function_Data_Type>
AS
BEGIN
   -- Declare the return variable here
	DECLARE <@Result> <Function_Data_Type>

	-- Add the T-SQL statements to compute the return value here
	SELECT <@Result> = <@Param1>

	-- Return the result of the function
	RETURN <@Result>

END
