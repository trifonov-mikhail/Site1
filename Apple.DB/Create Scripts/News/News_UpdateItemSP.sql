IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'News_UpdateItem')
	BEGIN
		DROP  Procedure  News_UpdateItem
	END

GO

CREATE Procedure News_UpdateItem
	(
		@GroupID int ,
		@LangCode NChar (2) = null,
		@Date datetime,
		@Title NVarChar (255) = null,
		@Notice NVarChar (1024) = null,
		@Text NVarChar (max) = null,
		@IsActive bit
	)
AS

	UPDATE News
	SET 
		GroupID = @GroupID,
		LangCode = @LangCode,
		[Date] = @Date,
		Title = @Title,
		Notice = @Notice,
		[Text] = @Text,
		IsActive = @IsActive
	WHERE (GroupID = @GroupID) and (LangCode = @LangCode)
GO
