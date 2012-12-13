IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'News_AddItem')
	BEGIN
		DROP  Procedure  News_AddItem
	END

GO

CREATE Procedure News_AddItem
	(
		@GroupID int ,
		@LangCode NChar (2) = null,
		@Date datetime,
		@Title NVarChar (255) = null,
		@Notice NVarChar (1024) = null,
		@Text NVarChar (max) = null,
		@ImageFile varbinary (max) = null,
		@IsActive bit ,
		@OrderNumber int
	)
AS

	INSERT INTO News
	(
		[GroupID] ,
		[LangCode] ,
		[Date] ,
		[Title] ,
		[Notice] ,
		[Text] ,
		[ImageFile] ,
		[IsActive] ,
		[OrderNumber]
	)
	VALUES
	(
		@GroupID ,
		@LangCode ,
		@Date ,
		@Title ,
		@Notice ,
		@Text ,
		@ImageFile ,
		@IsActive ,
		@OrderNumber
	);

	select scope_identity();
GO
