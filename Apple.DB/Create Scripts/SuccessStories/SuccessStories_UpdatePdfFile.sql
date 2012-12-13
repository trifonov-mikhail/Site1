 SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER Procedure [dbo].[SuccessStories_UpdatePdfFile]
	(
		@GroupID int ,
		@LangCode nvarchar(2) = null,
		@PdfFile varbinary (max) = null,
		@PdfFileName nvarchar(max) = null
	)
AS

	UPDATE SuccessStories
	SET 
		[PdfFile] = @PdfFile,
		[PdfFileName] = @PdfFileName
	WHERE (GroupID = @GroupID) AND LangCode = @LangCode

GO

 