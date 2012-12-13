SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE Procedure [dbo].[SuccessStories_GetImage]
	(
		@GroupID int = 0,
		@LangCode nchar(2) = 'ru'
	)
AS
	SELECT ImageFile
	FROM SuccessStories
	WHERE LangCode = @LangCode AND GroupID = @GroupID

GO

