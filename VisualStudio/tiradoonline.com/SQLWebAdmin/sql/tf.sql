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
RETURNS 
<@Table_Variable_Name> TABLE 
(
   -- Add the column definitions for the TABLE variable here
   <Column_1> <Data_Type_For_Column1>, 
   <Column_2> <Data_Type_For_Column2>
)
AS
BEGIN
   -- Fill the table variable with the rows for your result set
	
   RETURN 

END
