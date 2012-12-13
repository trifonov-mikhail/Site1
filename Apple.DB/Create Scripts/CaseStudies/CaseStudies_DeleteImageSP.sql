IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'News_DeleteImage')
	BEGIN
		DROP  Procedure  News_DeleteImage
	END

GO

CREATE Procedure News_DeleteImage
	(
		@GroupID int ,
		@LangCode NChar (2) = null
	)
AS
	UPDATE News
	SET 
		ImageFile = null
	WHERE (GroupID = @GroupID) and (LangCode = @LangCode)
GO
