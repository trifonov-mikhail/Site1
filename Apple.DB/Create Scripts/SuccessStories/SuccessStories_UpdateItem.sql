SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[SuccessStories_UpdateItem]
	(
		@GroupID int ,
		@LangCode NChar (2) = null,
		@Date datetime  = null,
		@Title NVarChar (255) = null,
		@Text NVarChar (max) = null
	)
AS

	UPDATE SuccessStories
	SET 
		[Date] = @Date,
		Title = @Title,
		[Text] = @Text
	WHERE (GroupID = @GroupID) and (LangCode = @LangCode)

GO

