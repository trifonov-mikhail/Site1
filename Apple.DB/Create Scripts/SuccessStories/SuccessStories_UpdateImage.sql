SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[SuccessStories_UpdateImage]
	(
		@GroupID int ,
		@ImageFile varbinary (max) = null
	)
AS

	UPDATE SuccessStories
	SET 
		[ImageFile] = @ImageFile
	WHERE (GroupID = @GroupID)

GO

 