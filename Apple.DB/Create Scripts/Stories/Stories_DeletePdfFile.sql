SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Stories_DeletePdfFile]
	(
		@GroupID int ,
		@LangCode nvarchar(2) = null
	)
AS

	UPDATE Stories
	SET 
		[PdfFile] = NULL
	WHERE (GroupID = @GroupID) AND (LangCode = @LangCode)

GO

  