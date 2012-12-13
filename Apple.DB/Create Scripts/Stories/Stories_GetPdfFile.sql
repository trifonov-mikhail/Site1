SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE Procedure [dbo].[Stories_GetPdfFile]
	(
		@GroupID int = 0,
		@LangCode nchar(2) = 'ru'
	)
AS
	SELECT PdfFile, PdfFileName
	FROM Stories
	WHERE LangCode = @LangCode AND GroupID = @GroupID

GO

 