USE [C15]
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
		@WebsiteId int,
		@Slug nvarchar(128) = null,
		@EntityId int = null,
		@ID int OUTPUT

AS

BEGIN

		INSERT INTO dbo.CMSPages
		(
			[PageName]
			,[PageDescription]
			,[PageTemplate]
			,[PageIsActive]
			,[WebsiteId]
			,[Slug]
			,[EntityId]
			
		)

		VALUES
			(@PageName, @PageDescription, @PageTemplate, @PageIsActive, @WebsiteId, @Slug, @EntityId)

SET		@ID = SCOPE_IDENTITY()
			
END
