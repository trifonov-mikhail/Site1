SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER Procedure [dbo].[SuccessStories_GetPdfFile]
	(
		@GroupID int = 0,
		@LangCode nchar(2) = 'ru'
	)
AS
	SELECT PdfFile, PdfFileName
	FROM SuccessStories
	WHERE LangCode = @LangCode AND GroupID = @GroupID

GO

 