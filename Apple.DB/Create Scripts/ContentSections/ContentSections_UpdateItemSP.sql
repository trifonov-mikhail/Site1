IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'ContentSections_UpdateItem')
	BEGIN
		DROP  Procedure  ContentSections_UpdateItem
	END

GO

CREATE Procedure ContentSections_UpdateItem
	(
		@ID int,
		@Name NVarChar (255)
	)
AS

	UPDATE ContentSections
	SET 
		[Name] = @Name
	WHERE (ID = @ID)
GO
