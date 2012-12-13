SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER Procedure [dbo].[SuccessStories_GetByLangGroup]
	(
		@LangCode nchar(2) = 'ru',
		@GroupID int
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
	FROM SuccessStories
	WHERE LangCode = @LangCode AND GroupID = @GroupID

GO

 