﻿USE [C15]
GO
/****** Object:  StoredProcedure [dbo].[CMSPages_Delete]    Script Date: 6/14/16 5:12:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [dbo].[CMSPages_Delete]
			
	@Id int

AS

BEGIN

DELETE FROM [dbo].[CMSPages]

WHERE Id = @Id

END
