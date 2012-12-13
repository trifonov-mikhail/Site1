SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[SuccessStories_DeleteImage]
	(
		@GroupID int 
	)
AS

	UPDATE SuccessStories
	SET 
		[ImageFile] = NULL
	WHERE (GroupID = @GroupID)

GO

   