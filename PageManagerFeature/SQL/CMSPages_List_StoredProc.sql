USE [C15]
GO
/****** Object:  StoredProcedure [dbo].[CMSPages_List]    Script Date: 6/14/16 5:14:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [dbo].[CMSPages_List]

AS

BEGIN

SELECT
	[ID]
	,[PageName]
	,[PageDescription]
	,[PageTemplate]
	,[PageIsActive]		

FROM [dbo].[CMSPages]

ORDER BY ID ASC;

END