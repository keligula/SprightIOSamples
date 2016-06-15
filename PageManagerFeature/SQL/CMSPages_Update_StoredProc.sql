USE [C15]
GO
/****** Object:  StoredProcedure [dbo].[CMSPages_Update]    Script Date: 6/14/16 5:17:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [dbo].[CMSPages_Update]

		@PageName nvarchar(50),
		@PageDescription nvarchar(MAX),
		@PageTemplate int,
		@PageIsActive bit,
		@Id int OUTPUT

AS

BEGIN

UPDATE [dbo].[CMSPages]
		
SET		[PageName] = @PageName,
		[PageDescription] = @PageDescription,
		[PageTemplate] = @PageTemplate,
		[PageIsActive] = @PageIsActive,
		
	
WHERE [Id] = @Id
			
END
