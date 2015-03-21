SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

-- ================================
-- Created 
--    by: <Author_Name>
--    on: <Creation_Date>
-- Description: <Description>
-- ================================
CREATE TRIGGER <Trigger_Name> 
   ON  ALL SERVER
   <FOR | AFTER> <event_type | event_group>
AS 
BEGIN
   SET NOCOUNT ON;
   -- Insert statements for trigger here

END
