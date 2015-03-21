SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

-- ================================
-- Created 
--    by: <Author_Name>
--    on: <Creation_Date>
-- Description: <Description>
-- ================================
CREATE TRIGGER <Schema_Name>.<Trigger_Name> 
   ON  <Schema_Name>.<Table_Name> 
   AFTER <INSERT | DELETE | UPDATE>
AS 
BEGIN
   SET NOCOUNT ON;
   -- Insert statements for trigger here

END
