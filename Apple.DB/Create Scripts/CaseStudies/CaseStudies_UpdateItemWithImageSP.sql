IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'News_UpdateItemWithImage')
	BEGIN
		DROP  Procedure  News_UpdateItemWithImage
	END

GO

CREATE Procedure News_UpdateItemWithImage
	(
		@GroupID int ,
		@LangCode NChar (2) = null,
		@Date datetime ,
		@Title NVarChar (255) = null,
		@Notice NVarChar (1024) = null,
		@Text NVarChar (max) = null,
		@IsActive bit,
		@ImageFile varbinary (max) = null
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
		IsActive = @IsActive,
		ImageFile = @ImageFile
	WHERE (GroupID = @GroupID) and (LangCode = @LangCode)
GO
