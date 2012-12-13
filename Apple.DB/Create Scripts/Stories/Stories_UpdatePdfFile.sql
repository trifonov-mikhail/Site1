 SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Stories_UpdatePdfFile]
	(
		@GroupID int ,
		@LangCode nvarchar(2) = null,
		@PdfFile varbinary (max) = null,
		@PdfFileName nvarchar(max) = null
	)
AS

	UPDATE Stories
	SET 
		[PdfFile] = @PdfFile,
		[PdfFileName] = @PdfFileName
	WHERE (GroupID = @GroupID) AND LangCode = @LangCode

GO

 