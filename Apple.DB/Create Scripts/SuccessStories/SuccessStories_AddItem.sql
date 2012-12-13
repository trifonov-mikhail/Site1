 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'SuccessStories_AddItem')
	BEGIN
		DROP  Procedure  SuccessStories_AddItem
	END

GO

CREATE Procedure SuccessStories_AddItem
	(   @GroupID int ,
		@LangCode NChar (2) = null,
		@Date datetime  = null,
		@Title NVarChar (255) = null,
		@Text NVarChar (max) = null,
		@ImageFile varbinary (max) = null,
		@PdfFile varbinary (max) = null,
		@PdfFileName nvarchar(max) = null
)
AS

INSERT INTO [SuccessStories]
           ([GroupID]
           ,[LangCode]
           ,[Date]
           ,[Title]
           ,[Text]
           ,[ImageFile]
           ,[PdfFile],
           [PdfFileName]
           )
     VALUES
           (@GroupID
           ,@LangCode
           ,@Date
           ,@Title
           ,@Text
           ,@ImageFile
           ,@PdfFile
           ,@PdfFileName
           )
           
     select scope_identity();
GO

