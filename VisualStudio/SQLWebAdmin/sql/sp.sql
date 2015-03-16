SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

-- ================================
-- Created 
--    by: <Author_Name>
--    on: <Creation_Date>
-- Description: <Description>
-- ================================
CREATE PROCEDURE <Schema_Name>.<Procedure_Name> 
   -- Add the parameters for the procedure here
   <@Param1> <Datatype_For_Param1> = <Default_Value_For_Param1>, 
   <@Param2> <Datatype_For_Param2> = <Default_Value_For_Param2>
AS
BEGIN
   SET NOCOUNT ON;

   -- Insert statements for procedure here
   SELECT @Param1, @Param2

END

