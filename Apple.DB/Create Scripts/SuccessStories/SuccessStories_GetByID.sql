SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER Procedure [dbo].[SuccessStory_GetByID]
	(
		@ID int = 0
	)
AS
	SELECT 
    ID, GroupID, LangCode, [Date], Title, 
	[Text],
    CASE
		when ImageFile is NULL then 0
		else 1
	end as HasImage	,
    CASE
		when PdfFile is NULL then 0
		else 1
	end as HasPdfFile, PdfFileName
	FROM 
    SuccessStories c
	WHERE ID = @ID

GO

  