IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'News_UpdateImage')
	BEGIN
		DROP  Procedure  News_UpdateImage
	END

GO

CREATE Procedure News_UpdateImage
	(
		@GroupID int ,
		@LangCode NChar (2) = null,
		@ImageFile varbinary (max) = null
	)
AS

	UPDATE News
	SET 
		ImageFile = @ImageFile
	WHERE (GroupID = @GroupID) and (LangCode = @LangCode)
GO