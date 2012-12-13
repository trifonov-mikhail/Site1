IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'CaseStudies_UpdateItem')
	BEGIN
		DROP  Procedure  CaseStudies_UpdateItem
	END

GO

CREATE Procedure CaseStudies_UpdateItem
	(
		@ID int,
		@GroupID int ,
		@LangCode NChar (2) = null,
		@Date datetime ,
		@Title NVarChar (255) = null,
		@Notice NVarChar (1024) = null,
		@Text NVarChar (max) = null,
		@File varbinary (max) = null,
		@FileName NVarChar (255) = null,
		@FileMime NVarChar (255) = null,
		@FileSize NVarChar (50) = null,
		@IsActive bit ,
		@OrderNumber int ,
		@DateCreated datetime
	)
AS

	UPDATE CaseStudies
	SET 
		GroupID = @GroupID,
		LangCode = @LangCode,
		Date = @Date,
		Title = @Title,
		Notice = @Notice,
		Text = @Text,
		File = @File,
		FileName = @FileName,
		FileMime = @FileMime,
		FileSize = @FileSize,
		IsActive = @IsActive,
		OrderNumber = @OrderNumber,
		DateCreated = @DateCreated
	WHERE (ID = @ID)
GO
