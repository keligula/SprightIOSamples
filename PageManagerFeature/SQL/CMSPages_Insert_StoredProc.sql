﻿USE [C15]
GO
/****** Object:  StoredProcedure [dbo].[CMSPages_Insert]    Script Date: 6/14/16 5:13:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [dbo].[CMSPages_Insert]

		@PageName nvarchar(50),
		@PageDescription nvarchar(MAX),
		@PageTemplate int,
		@PageIsActive bit,
		@Id int OUTPUT

AS

BEGIN

		INSERT INTO dbo.CMSPages
		(
			[PageName]
			,[PageDescription]
			,[PageTemplate]
			,[PageIsActive]
			
		)

		VALUES
			(@PageName, @PageDescription, @PageTemplate, @PageIsActive)

SET		@Id = SCOPE_IDENTITY()
			
END
