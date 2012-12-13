SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[SuccessStories_DeletePdfFile]
	(
		@GroupID int ,
		@LangCode nvarchar(2) = null
	)
AS

	UPDATE SuccessStories
	SET 
		[PdfFile] = NULL
	WHERE (GroupID = @GroupID) AND (LangCode = @LangCode)

GO

  