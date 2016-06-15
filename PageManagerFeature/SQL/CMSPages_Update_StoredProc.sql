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
		@Slug nvarchar(128) = null,
		@EntityId int = null,
		@ID int OUTPUT

AS

BEGIN

UPDATE [dbo].[CMSPages]
		
SET		[PageName]=@PageName,
		[PageDescription]=@PageDescription,
		[PageTemplate]=@PageTemplate,
		[PageIsActive]=@PageIsActive,
		[Slug]=@Slug,
		[EntityId]=@EntityId
	
WHERE [ID]=@ID
			
END
