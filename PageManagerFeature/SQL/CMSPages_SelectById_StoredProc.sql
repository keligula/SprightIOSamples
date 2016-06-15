USE [C15]
GO
/****** Object:  StoredProcedure [dbo].[CMSPages_SelectById]    Script Date: 6/14/16 5:15:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [dbo].[CMSPages_SelectById]

@Id int

AS

BEGIN

SELECT
	[ID]
	,[PageName]
	,[PageDescription]
	,[PageTemplate]
	,[PageIsActive]
	,[WebsiteId]
	,[Slug]
	,[EntityId]
	
FROM [dbo].[CMSPages]
WHERE @Id = Id ORDER BY Id DESC

SELECT [AttributeId] as Id
      ,[Filter]

FROM [C15].[dbo].[CmsPageAttributes]
WHERE [CmsPageId] = @Id

SELECT [metaKey]
      ,[metaValue]

FROM [dbo].[CmsPageMetaTags]
WHERE [pageId] = @Id Order By Id

END
