IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'Articles_AddItem')
	BEGIN
		DROP  Procedure  Articles_AddItem
	END

GO

CREATE Procedure Articles_AddItem
	(
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
		@OrderNumber int
	)
AS

	INSERT INTO Articles
	(
		[GroupID] ,
		[LangCode] ,
		[Date] ,
		[Title] ,
		[Notice] ,
		[Text] ,
		[File] ,
		[FileName] ,
		[FileMime] ,
		[FileSize] ,
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
		@File ,
		@FileName ,
		@FileMime ,
		@FileSize ,
		@IsActive ,
		@OrderNumber
	);

	select scope_identity();
GO
